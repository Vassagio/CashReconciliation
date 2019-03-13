using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.WPF.ViewModels;
using Prism.Events;

namespace CashReconciliation.WPF.Mappers
{
	public class CashEntryMapper : ICashEntryMapper
	{
		private readonly IEventAggregator _aggregator;
		private readonly IDenominationMapper _denominationMapper;

		public CashEntryMapper(IDenominationMapper denominationMapper, IEventAggregator aggregator)
		{
			_denominationMapper = denominationMapper;
			_aggregator = aggregator;
		}

		public CashEntry Map(CashEntryViewModel viewModel) => new CashEntry(viewModel.Denomination.Description, viewModel.Denomination.Value, viewModel.Quantity);

		public CashEntryViewModel Map(CashEntry model) => new CashEntryViewModel(_aggregator)
		{
			Denomination = _denominationMapper.Map(model.Denomination),
			Quantity = model.Quantity,
			Total = model.Total
		};
	}
}