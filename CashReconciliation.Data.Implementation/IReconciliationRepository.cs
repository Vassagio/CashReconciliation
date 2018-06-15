using System;
using System.Collections.Generic;

namespace CashReconciliation.Data.Implementation
{
	public interface IReconciliationRepository
	{
		void Save(IReconciliation reconciliation);
		IReconciliation Get(DateTime dateTime);
		IEnumerable<IReconciliation> GetAll();
	}
}