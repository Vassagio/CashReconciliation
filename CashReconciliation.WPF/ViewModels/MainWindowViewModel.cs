using System.Collections.Generic;
using CashReconciliation.Core;
using CashReconciliation.Core.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IDenominationService _denominationService;

		private IEnumerable<Denomination> _denominations;
		public IEnumerable<Denomination> Denominations
		{
			get => _denominations;
			set => SetProperty(ref _denominations, value);
		}

		public DelegateCommand AddDenominationCommand => new DelegateCommand(AddDenomination);


		public MainWindowViewModel(IDenominationService denominationService)
		{
			_denominationService = denominationService;
			Denominations = _denominationService.Get();
		}

		private void AddDenomination()
		{
			_denominationService.Add(new Denomination("William", 100000));
			Denominations = _denominationService.Get();
		}
	}
}