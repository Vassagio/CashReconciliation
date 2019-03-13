using System;
using System.Security.Claims;
using System.Windows.Input;
using CashReconciliation.WPF.EventAggregators;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class CompactReconciliationViewModel : BindableBase
	{
		private readonly IEventAggregator _aggregator;

		public CompactReconciliationViewModel(IEventAggregator aggregator) { _aggregator = aggregator; }
		

		private DateTime _reconciledDate;
		public DateTime ReconciledDate { get => _reconciledDate; set => SetProperty(ref _reconciledDate, value); }		

		private decimal _startOfDayTotal = 0;
		public decimal StartOfDayTotal { get => _startOfDayTotal; set => SetProperty(ref _startOfDayTotal, value); }		

		private decimal _endOfDayTotal;
		public decimal EndOfDayTotal { get => _endOfDayTotal; set => SetProperty(ref _endOfDayTotal, value); }

		public ICommand EditReconciliationCommand => new DelegateCommand(EditReconciliation);

		private void EditReconciliation() => _aggregator.GetEvent<CompactReconciliationClicked>().Publish(this);
	}
}
