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
		
		public StartingCashViewModel(ICashEntryService service, IMapper mapper, IEventAggregator aggregator)
		{
			aggregator.GetEvent<CashEntryChanged>().Subscribe(Update);
			_service = service;
			_mapper = mapper;
			Refresh();
		}

		private void Refresh() => StartingCash = _service.Get().Select(_mapper.Map<CashEntryViewModel>);

		private void Update(CashEntryViewModel cashEntry)
		{			
			_service.Update(_mapper.Map<CashEntry>(cashEntry));	
		}
	}
}