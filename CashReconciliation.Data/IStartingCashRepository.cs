using System.Collections.Generic;
using CashReconciliation.Data.Entities;

namespace CashReconciliation.Data
{
	public interface IStartingCashRepository
	{
		IEnumerable<CashEntry> Get();
		void Insert(CashEntry cashEntry);
		CashEntry Update(CashEntry cashEntry);
		void Delete(CashEntry cashEntry);		
	}
}