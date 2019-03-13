using System;
using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.Core.CheckEntries;

namespace CashReconciliation.Core.Reconciliations
{
	public class Reconciliation
	{
		public DateTime ReconciledDate { get; internal set; }
		public IEnumerable<CashEntry> StartOfDayCashEntries { get; internal set; }
		public IEnumerable<CashEntry> EndOfDayCashEntries { get; internal set; }
		public IEnumerable<CheckEntry> EndOfDayCheckEntries { get; internal set; }
		public decimal StartOfDayTotal {get; internal set; }
		public decimal EndOfDayTotal {get; internal set; }
		internal Reconciliation() { }

		public Reconciliation(DateTime reconciledDate, IEnumerable<CashEntry> startOfDayCashEntries, IEnumerable<CashEntry> endOfDayCashEntries, IEnumerable<CheckEntry> endOfDayCheckEntries)
		{
			ReconciledDate = reconciledDate;
			StartOfDayCashEntries = startOfDayCashEntries.ToList();
			EndOfDayCashEntries = endOfDayCashEntries.ToList();
			EndOfDayCheckEntries = endOfDayCheckEntries;
			StartOfDayTotal = StartOfDayCashEntries.Sum(e => e.Total);
			EndOfDayTotal = EndOfDayCashEntries.Sum(e => e.Total);
		}
	}
}