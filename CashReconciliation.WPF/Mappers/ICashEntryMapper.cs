using System.Collections.Generic;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.WPF.ViewModels;

namespace CashReconciliation.WPF.Mappers
{
	public interface ICashEntryMapper
	{
		CashEntry Map(CashEntryViewModel viewModel);
		CashEntryViewModel Map(CashEntry model);
	}
}