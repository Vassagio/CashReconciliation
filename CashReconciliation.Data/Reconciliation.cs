using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CashReconciliation.Data.Implementation;

namespace CashReconciliation.Data
{
	[XmlRoot("Reconciliation")]
	public sealed class Reconciliation : IEqualityComparer<Reconciliation>, IEquatable<Reconciliation>
	{
		[XmlElement]
		public DateTime ReconciliationDate { get; set; }
		
		[XmlArray("StartingCashEntries")]
		[XmlArrayItem("CashEntry", typeof(CashEntry))]
		public CashEntries StartingCashEntries { get; set; }
		
		[XmlArray("EndingCashEntries")]
		[XmlArrayItem("CashEntry", typeof(CashEntry))]
		public CashEntries EndingCashEntries { get; set; }

		public Reconciliation() { }

		public Reconciliation(DateTime reconciliationDate, CashEntries startingCashEntries, CashEntries endingCashEntries)
		{
			ReconciliationDate = reconciliationDate;
			StartingCashEntries = startingCashEntries ?? throw new ArgumentNullException($"{nameof(startingCashEntries)} cannot be null");
			EndingCashEntries = endingCashEntries ?? throw new ArgumentNullException($"{nameof(endingCashEntries)} cannot be null");
		}

		public bool Equals(Reconciliation x, Reconciliation y) =>
			y != null && 
			x != null && 
			x.ReconciliationDate.Equals(y.ReconciliationDate);

		public int GetHashCode(Reconciliation obj) => obj.ReconciliationDate.GetHashCode();

		public bool Equals(Reconciliation other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return ReconciliationDate.Equals(other.ReconciliationDate);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;

			return obj is Reconciliation reconciliation && Equals(reconciliation);
		}

		public override int GetHashCode() => ReconciliationDate.GetHashCode();
	}
}
