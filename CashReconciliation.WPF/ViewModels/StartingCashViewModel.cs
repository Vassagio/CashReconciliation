using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.WPF.Mappers;
using CashReconciliation.WPF.EventAggregators;
using Prism.Events;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class StartingCashViewModel : BindableBase
	{
		private readonly ICashEntryMapper _mapper;
		private readonly ICashEntryService _service;

		private IEnumerable<CashEntryViewModel> _cashEntries;
		public IEnumerable<CashEntryViewModel> CashEntries { get => _cashEntries; set => SetProperty(ref _cashEntries, value); }

		private decimal _total;
		public decimal Total { get => _total; set => SetProperty(ref _total, value); }
		
		public StartingCashViewModel(ICashEntryService service, ICashEntryMapper mapper, IEventAggregator aggregator)
		{			
			aggregator.GetEvent<CashEntryChanged>().Subscribe(Update);
			_service = service;
			_mapper = mapper;
			Initialize();
		}

		private void Initialize()
		{
			CashEntries = _service.Get().Select(i => _mapper.Map(i));
			Refresh();
		}

		private void Refresh() => Total = _service.GetTotal();

		private void Update(CashEntryViewModel cashEntry)
		{
			_service.Update(_mapper.Map(cashEntry));
			Refresh();
		}
	}
}