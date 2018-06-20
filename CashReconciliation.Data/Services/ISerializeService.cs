using MBI.Utilities.Optional;

namespace CashReconciliation.Data.Services
{
	public interface ISerializeService
	{
		void Serialize<T>(T obj, string fileName);
		IOptional<T> Deserialize<T>(string fileName);
	}
}