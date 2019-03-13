using CashReconciliation.Core.Denominations;
using CashReconciliation.WPF.ViewModels;

namespace CashReconciliation.WPF.Mappers
{
	public interface IDenominationMapper
	{
		Denomination Map(DenominationViewModel viewModel);
		DenominationViewModel Map(Denomination model);
	}
}