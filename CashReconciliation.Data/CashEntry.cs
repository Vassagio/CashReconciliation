using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CashReconciliation.Data
{
	public sealed class CashEntry: IEqualityComparer<CashEntry>, IEquatable<CashEntry>
	{
		[XmlElement]
		public Denomination Denomination { get; set; }

		[XmlElement]
		public int Quantity { get; set; }

		public CashEntry() { }

		public CashEntry(Denomination denomination, int quantity)
		{
			Denomination = denomination ?? throw new ArgumentNullException($"{nameof(denomination)} cannot be null");
			Quantity = quantity >= 0 ? quantity : throw new ArgumentException($"{nameof(quantity)} cannot be less than zero");
		}

		public bool Equals(CashEntry x, CashEntry y) =>
			y != null && 
			x != null && 
			x.Denomination.Equals(y.Denomination);

		public int GetHashCode(CashEntry obj) => obj.Denomination != null ? obj.Denomination.GetHashCode() : 0;

		public bool Equals(CashEntry other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return Denomination.Equals(other.Denomination);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;

			return obj is CashEntry entry && Equals(entry);
		}

		public override int GetHashCode() => Denomination != null ? Denomination.GetHashCode() : 0;

		public override string ToString() => $"{Denomination} ({Quantity})";
	}
}