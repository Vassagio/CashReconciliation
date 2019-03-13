using System;
using System.Collections.Generic;
using System.Linq;
using CashReconciliation.WPF.Mappers;
using CashReconciliation.Core.Reconciliations;
using CashReconciliation.WPF.EventAggregators;
using Prism.Events;

namespace CashReconciliation.WPF.ViewModels
{
	public class ReconciliationViewModel : DocumentViewModelBase
	{
		private readonly IReconciliationService _reconciliationService;
		private readonly IReconciliationMapper _mapper;

		private IEnumerable<CashEntryViewModel> _endOfDayCashEntries;
		private decimal _endOfDayTotal;
		private DateTime _reconciledDate;
		private IEnumerable<CashEntryViewModel> _startOfDayCashEntries;
		private decimal _startOfDayTotal;

		public DateTime ReconciledDate { get => _reconciledDate; set => SetProperty(ref _reconciledDate, value); }
		public IEnumerable<CashEntryViewModel> StartOfDayCashEntries { get => _startOfDayCashEntries; set => SetProperty(ref _startOfDayCashEntries, value); }
		public decimal StartOfDayTotal { get => _startOfDayTotal; set => SetProperty(ref _startOfDayTotal, value); }
		public IEnumerable<CashEntryViewModel> EndOfDayCashEntries { get => _endOfDayCashEntries; set => SetProperty(ref _endOfDayCashEntries, value); }
		public decimal EndOfDayTotal { get => _endOfDayTotal; set => SetProperty(ref _endOfDayTotal, value); }
		public override string DisplayName => ReconciledDate.ToShortDateString();

		public ReconciliationViewModel(IReconciliationService reconciliationService, IReconciliationMapper mapper, IEventAggregator aggregator)
		{
			_reconciliationService = reconciliationService;
			_mapper = mapper;
			aggregator.GetEvent<CashEntryChanged>().Subscribe(Update);			
		}

		private void Update(CashEntryViewModel cashEntryViewModel)
		{
			_reconciliationService.Update(_mapper.Map(this));
		}
	}
}