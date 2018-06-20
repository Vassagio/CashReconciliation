using System.Collections.Generic;

namespace CashReconciliation.Core.Denominations
{
	public interface IDenominationService
	{
		IEnumerable<Denomination> Get();
		void Add(Denomination denomination);
	}
}