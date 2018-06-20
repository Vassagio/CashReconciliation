using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class DenominationViewModel : BindableBase
	{
		private string _description;
		public string Description { get => _description; set => SetProperty(ref _description, value); }

		private decimal _value;
		public decimal Value { get => _value; set => SetProperty(ref _value, value); }

		public override string ToString() => $"{Description} ({Value})";
	}
}
