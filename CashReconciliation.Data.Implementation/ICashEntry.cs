namespace CashReconciliation.Data.Implementation
{
	public interface ICashEntry
	{
		IDenomination Denomination { get; }		
		int           Quantity     { get; }
	}
}