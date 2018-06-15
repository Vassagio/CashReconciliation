using CashReconciliation.Data.Implementation;
using CashReconciliation.Data.Implementation.Mocks;
using CashReconciliation.Implementation;
using CashReconciliation.Implementation.Mocks;
using Xunit;

namespace CashReconciliation.Data.Tests
{
    public class ReconciliationRepositoryTest
    {
	    [Fact]
	    public void Initialize()
	    {
			var repository = BuildReconciliationRepository();

		    Assert.IsAssignableFrom<IReconciliationRepository>(repository);
	    }

	    private static ReconciliationRepository BuildReconciliationRepository(ISerializeService serializeService = null, ITimeProvider timeProvider = null)
	    {
		    serializeService = serializeService ?? new MockSerializeService();
		    timeProvider = timeProvider ?? new MockTimeProvider();
			return new ReconciliationRepository(serializeService, timeProvider);
	    }
    }
}
