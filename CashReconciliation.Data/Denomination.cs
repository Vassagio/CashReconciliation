using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CashReconciliation.Data
{
	public sealed class Denomination : IEqualityComparer<Denomination>, IEquatable<Denomination>
	{
		[XmlAttribute]
		public string Description { get; set; }
		[XmlAttribute]
		public decimal Value { get; set; }

		public Denomination() { }

		public Denomination(string description, decimal value)
		{
			Description = !string.IsNullOrEmpty(description) ? description : throw new ArgumentNullException($"{nameof(description)} cannot be null or empty");
			Value = value > 0 ? value : throw new ArgumentException($"{nameof(value)} cannot be less than or equal to zero");
		}

		public override string ToString() => $"{Description} - {Value:C}";

		public bool Equals(Denomination x, Denomination y) =>
			y != null && 
			x != null && 
			x.Description.Equals(y.Description) &&
			x.Value.Equals(y.Value);

		public int GetHashCode(Denomination obj)
		{
			unchecked
			{
				return (obj.Description != null ? obj.Description.GetHashCode() : 0) * 397 ^
				       obj.Value.GetHashCode();
			}
		}

		public bool Equals(Denomination other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return string.Equals(Description, other.Description) && Value == other.Value;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;

			return obj is Denomination denomination && Equals(denomination);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Description != null ? Description.GetHashCode() : 0) * 397) ^ 
				       Value.GetHashCode();
			}
		}
	}
}