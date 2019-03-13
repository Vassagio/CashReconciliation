using System;
using System.Collections.Generic;
using CashReconciliation.Data.Entities;
using MBI.Utilities.Optional;
using MBI.Utilities.Optional.Extensions;

namespace CashReconciliation.Data
{
	public interface IReconciliationRepository
	{
		IEnumerable<Reconciliation> GetAll();
		IOptional<Reconciliation> Get(DateTime reconciledDate);				
		void Save(Reconciliation reconciliation);
	}
}