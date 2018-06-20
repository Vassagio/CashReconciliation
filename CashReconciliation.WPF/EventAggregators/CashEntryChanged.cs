using CashReconciliation.WPF.ViewModels;
using Prism.Events;

namespace CashReconciliation.WPF.EventAggregators
{
	public sealed class CashEntryChanged : PubSubEvent<CashEntryViewModel>{}
}
