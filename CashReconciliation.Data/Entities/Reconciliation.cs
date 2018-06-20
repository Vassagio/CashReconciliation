using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CashReconciliation.Data.Entities
{
	public sealed class Reconciliation
	{
		[XmlElement]
		public DateTime ReconciledDate { get; set; }

		[XmlArray("StartOfDayCashEntries")]
		[XmlArrayItem("CashEntry", typeof(CashEntry))]
		public IEnumerable<CashEntry> StartOfDayCashEntries { get; set; }

		[XmlArray("EndOfDayCashEntries")]
		[XmlArrayItem("CashEntry", typeof(CashEntry))]
		public IEnumerable<CashEntry> EndOfDayCashEntries { get; set; }

		[XmlArray("EndOfDayCheckEntries")]
		[XmlArrayItem("CheckEntry", typeof(CheckEntry))]
		public IEnumerable<CashEntry> EndOfDayCheckEntries { get; set; }
	}
}