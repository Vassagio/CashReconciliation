using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Core.CheckEntries;
using CashReconciliation.Core.Reconciliations;
using CashReconciliation.WPF.ViewModels;
using Prism.Events;

namespace CashReconciliation.WPF.Mappers
{
	public class ReconciliationMapper : IReconciliationMapper
	{
		private readonly IEventAggregator _aggregator;
		private readonly ICashEntryMapper _cashEntryMapper;
		private readonly IReconciliationService _reconciliationService;

		public ReconciliationMapper(ICashEntryMapper cashEntryMapper, IReconciliationService reconciliationService, IEventAggregator aggregator)
		{
			_cashEntryMapper = cashEntryMapper;
			_reconciliationService = reconciliationService;
			_aggregator = aggregator;
		}

		public Reconciliation Map(ReconciliationViewModel viewModel)
		{
			var startOfDayCashEntries = viewModel.StartOfDayCashEntries.Select(e => _cashEntryMapper.Map(e));
			var endOfDayCashEntries = viewModel.EndOfDayCashEntries.Select(e => _cashEntryMapper.Map(e));
			return new Reconciliation(viewModel.ReconciledDate, startOfDayCashEntries, endOfDayCashEntries, new List<CheckEntry>());
		}

		public ReconciliationViewModel Map(Reconciliation model) =>
			new ReconciliationViewModel(_reconciliationService, this, _aggregator)
			{
				ReconciledDate = model.ReconciledDate,
				StartOfDayCashEntries = model.StartOfDayCashEntries.Select(_cashEntryMapper.Map),
				StartOfDayTotal = model.StartOfDayTotal,
				EndOfDayCashEntries = model.EndOfDayCashEntries.Select(_cashEntryMapper.Map),
				EndOfDayTotal = model.EndOfDayTotal
			};

		public CompactReconciliationViewModel MapCompact(Reconciliation model) =>
			new CompactReconciliationViewModel(_aggregator)
			{
				ReconciledDate = model.ReconciledDate,
				StartOfDayTotal = model.StartOfDayTotal,
				EndOfDayTotal = model.EndOfDayTotal
			};
	}
}