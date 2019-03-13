using System;

namespace CashReconciliation.Core.CheckEntries
{
	public class CheckEntry
	{

		public int CheckNumber { get; internal set; }
		
		public decimal Amount { get; internal set; }

		public CheckEntry(int checkNumber, decimal amount)
		{
			CheckNumber = checkNumber > 0 ? checkNumber : throw new ArgumentException($"{nameof(checkNumber)} must be greater than 0");
			Amount = amount > 0 ? amount : throw new ArgumentException($"{nameof(amount)} must be greater than 0");
		}
	}
}
