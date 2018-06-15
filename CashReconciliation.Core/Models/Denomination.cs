using System;

namespace CashReconciliation.Core.Models
{
	public class Denomination
	{
		internal Denomination() { }

		public Denomination(string description, decimal value)
		{
			Description = !string.IsNullOrWhiteSpace(description) ? description : throw new ArgumentNullException($"{nameof(description)} cannot e null");
			Value = value > 0 ? value : throw new ArgumentException($"{nameof(value)} must be greater than 0");
		}

		public string Description { get; internal set; }
		public decimal Value { get; internal set; }

		public override string ToString() => $"{Description} ({Value:C})";
	}
}