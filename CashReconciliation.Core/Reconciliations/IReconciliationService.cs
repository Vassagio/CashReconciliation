using System;
using System.Collections.Generic;
using MBI.Utilities.Optional;

namespace CashReconciliation.Core.Reconciliations
{
	public interface IReconciliationService
	{
		IEnumerable<Reconciliation> GetAll();
		void Add(Reconciliation reconciliation);
		IOptional<Reconciliation> Get(DateTime reconciledDate);
		void Update(Reconciliation reconciliation);
	}
}
