using CashReconciliation.Data;

namespace CashReconciliation.Core
{
	public class SomeService : ISomeService
	{
		private readonly ISomeRepository _repository;

		public SomeService(ISomeRepository repository) => _repository = repository;

		public string Get() => _repository.Get();
	}
}