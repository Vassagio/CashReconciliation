using CashReconciliation.Core.Reconciliations;
using CashReconciliation.WPF.ViewModels;

namespace CashReconciliation.WPF.Mappers
{
	public interface IReconciliationMapper
	{
		Reconciliation Map(ReconciliationViewModel viewModel);
		ReconciliationViewModel Map(Reconciliation model);		
		CompactReconciliationViewModel MapCompact(Reconciliation model);
	}
}