namespace CashReconciliation.Data.Implementation
{
	public interface IDenomination
	{
		string  Description { get; }		
		decimal Value       { get; }
	}
}
