using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CashReconciliation.Data.Entities
{
	public sealed class Reconciliation: IEqualityComparer<Reconciliation>, IEquatable<Reconciliation>
	{
		[XmlElement]
		public DateTime ReconciledDate { get; set; }

		[XmlArray("StartOfDayCashEntries")]
		[XmlArrayItem("CashEntry", typeof(CashEntry))]
		public List<CashEntry> StartOfDayCashEntries { get; set; } = new List<CashEntry>();

		[XmlArray("EndOfDayCashEntries")]
		[XmlArrayItem("CashEntry", typeof(CashEntry))]
		public List<CashEntry> EndOfDayCashEntries { get; set; } = new List<CashEntry>();

		[XmlArray("EndOfDayCheckEntries")]
		[XmlArrayItem("CheckEntry", typeof(CheckEntry))]
		public List<CheckEntry> EndOfDayCheckEntries { get; set; } = new List<CheckEntry>();

		public bool Equals(Reconciliation x, Reconciliation y) =>
			y != null &&
			x != null &&
			x.ReconciledDate.Equals(y.ReconciledDate);			

		public int GetHashCode(Reconciliation obj) => obj.ReconciledDate.GetHashCode();

		public bool Equals(Reconciliation other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;

			return ReconciledDate == other.ReconciledDate;
		}		

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;

			return obj is Reconciliation reconciliation && Equals(reconciliation);
		}

		public override int GetHashCode() => GetHashCode(this);
	}
}