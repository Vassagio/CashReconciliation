using System;

namespace CashReconciliation.Data.Implementation
{
	public interface IReconciliation
	{
		DateTime ReconciliationDate { get; set; }
		ICashEntries StartingCashEntries { get; set; }
		ICashEntries EndingCashEntries { get; set; }
	}
}