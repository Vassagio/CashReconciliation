using System.Collections.Generic;
using CashReconciliation.Data.Entities;

namespace CashReconciliation.Data
{
	public interface IDenominationRepository
	{
		IEnumerable<Denomination> Get();		
		void Insert(Denomination denomination);
	}
}