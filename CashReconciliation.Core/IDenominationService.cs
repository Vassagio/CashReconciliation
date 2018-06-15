using System.Collections.Generic;
using CashReconciliation.Core.Models;

namespace CashReconciliation.Core
{
	public interface IDenominationService
	{
		IEnumerable<Denomination> Get();
		void Add(Denomination denomination);
	}
}