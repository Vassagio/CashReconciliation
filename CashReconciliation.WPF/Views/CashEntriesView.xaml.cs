using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CashReconciliation.WPF.ViewModels;

namespace CashReconciliation.WPF.Views
{
	/// <summary>
	///     Interaction logic for CashEntriesView.xaml
	/// </summary>
	public partial class CashEntriesView : UserControl
	{
		public static readonly DependencyProperty CashEntriesProperty =
			DependencyProperty.Register("CashEntries", typeof(IEnumerable<CashEntryViewModel>), typeof(CashEntriesView), new PropertyMetadata(new List<CashEntryViewModel>()));

		public IEnumerable<CashEntryViewModel> CashEntries { get => (IEnumerable<CashEntryViewModel>) GetValue(CashEntriesProperty); set => SetValue(CashEntriesProperty, value); }

		public static readonly DependencyProperty TotalProperty =
			DependencyProperty.Register("Total", typeof(decimal), typeof(CashEntriesView), new PropertyMetadata(0m));

		public decimal Total { get => (decimal) GetValue(TotalProperty); set => SetValue(TotalProperty, value); }

		public CashEntriesView() { InitializeComponent(); }
	}
}