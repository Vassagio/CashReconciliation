using CashReconciliation.WPF.ViewModels;
using Prism.Events;

namespace CashReconciliation.WPF.EventAggregators
{
	public class CompactReconciliationClicked : PubSubEvent<CompactReconciliationViewModel>
	{
	}
}