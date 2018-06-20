using CashReconciliation.Core.Denominations;

namespace CashReconciliation.Core.CashEntries
{
	public class CashEntry
	{
		public Denomination Denomination { get; internal set; }		
		public int Quantity { get; internal set; }
		public decimal Total => Denomination.Value * Quantity;
		internal CashEntry() { }

		public CashEntry(string description, decimal value, int quantity)
		{
			Denomination = new Denomination(description, value);
			Quantity = quantity;
		}

		public override string ToString() => $"{Denomination}) * {Quantity} = {Total}";
	}
}