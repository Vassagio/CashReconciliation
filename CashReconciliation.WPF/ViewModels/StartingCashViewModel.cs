using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.WPF.EventAggregators;
using Prism.Events;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class StartingCashViewModel : BindableBase
	{
		private readonly IMapper _mapper;
		private readonly ICashEntryService _service;

		private IEnumerable<CashEntryViewModel> _startingCash;
		public IEnumerable<CashEntryViewModel> StartingCash { get => _startingCash; set => SetProperty(ref _startingCash, value); }

		private decimal _total;
		public decimal Total { get => _total; set => SetProperty(ref _total, value); }
		
		public StartingCashViewModel(ICashEntryService service, IMapper mapper, IEventAggregator aggregator)
		{
			aggregator.GetEvent<CashEntryChanged>().Subscribe(Update);
			_service = service;
			_mapper = mapper;
			Initialize();
		}

		private void Initialize()
		{
			StartingCash = _service.Get().Select(_mapper.Map<CashEntryViewModel>);
			Refresh();
		}

		private void Refresh() => Total = _service.GetTotal();

		private void Update(CashEntryViewModel cashEntry)
		{
			_service.Update(_mapper.Map<CashEntry>(cashEntry));
			Refresh();
		}
	}
}