using CashReconciliation.Core;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private string _title;

		public string Title { get => _title; set => SetProperty(ref _title, value); }

		public MainWindowViewModel(ISomeService someService) => Title = someService.Get();
	}
}