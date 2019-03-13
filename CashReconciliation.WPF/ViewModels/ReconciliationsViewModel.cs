using System.Collections.Generic;
using System.Linq;
using CashReconciliation.WPF.Mappers;
using CashReconciliation.Core.Reconciliations;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class ReconciliationsViewModel : DocumentViewModelBase
	{
		private readonly IReconciliationMapper _mapper;
		private readonly IReconciliationService _reconciliationService;

		private IEnumerable<CompactReconciliationViewModel> _reconciliations = new List<CompactReconciliationViewModel>();

		public IEnumerable<CompactReconciliationViewModel> Reconciliations { get => _reconciliations; set => SetProperty(ref _reconciliations, value); }

		public override string DisplayName => "History";

		public ReconciliationsViewModel(IReconciliationService reconciliationService, IReconciliationMapper mapper)
		{
			_reconciliationService = reconciliationService;
			_mapper = mapper;
			Refresh();
		}

		private void Refresh() => Reconciliations = _reconciliationService.GetAll().Select(i => _mapper.MapCompact(i));
	}
}