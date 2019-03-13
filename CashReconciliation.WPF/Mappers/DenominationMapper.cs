using CashReconciliation.Core.Denominations;
using CashReconciliation.WPF.ViewModels;

namespace CashReconciliation.WPF.Mappers
{
	public class DenominationMapper : IDenominationMapper
	{
		public Denomination Map(DenominationViewModel viewModel) => new Denomination(viewModel.Description, viewModel.Value);
		public DenominationViewModel Map(Denomination model) => new DenominationViewModel {Description = model.Description, Value = model.Value};
	}
}