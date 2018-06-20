using CashReconciliation.WPF.EventAggregators;
using Prism.Events;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class CashEntryViewModel: BindableBase
	{		
		private readonly IEventAggregator _aggregator;

		public CashEntryViewModel(IEventAggregator aggregator) => _aggregator = aggregator;

		private DenominationViewModel _denomination;
		public DenominationViewModel Denomination { get => _denomination; set => SetProperty(ref _denomination, value); }
		
		private int _quantity;
		public int Quantity
		{
			get => _quantity;
			set => SetProperty(ref _quantity, value, OnQuantityChanged);
		}

		private void OnQuantityChanged()
		{
			Total = _quantity * _denomination.Value;
			_aggregator.GetEvent<CashEntryChanged>().Publish(this);
		} 

		private decimal _total;
		public decimal Total { get => _total; set => SetProperty(ref _total, value); }

		public override string ToString() => $"{Denomination}) * {Quantity} = {Total}";
	}
}
