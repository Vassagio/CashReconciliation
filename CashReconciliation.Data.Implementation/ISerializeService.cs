namespace CashReconciliation.Data.Implementation
{
	public interface ISerializeService
	{
		T Deserialize<T>(string fileName);
		void Serialize<T>(T obj,string fileName);
	}
}