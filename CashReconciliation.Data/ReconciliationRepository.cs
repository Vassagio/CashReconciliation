using System;
using System.Collections.Generic;
using CashReconciliation.Data.Implementation;
using CashReconciliation.Implementation;

namespace CashReconciliation.Data
{
	public class ReconciliationRepository
	{		
		private readonly ISerializeService _serializeService;
		private readonly ITimeProvider _timeProvider;

		public ReconciliationRepository(ISerializeService serializeService, ITimeProvider timeProvider)
		{
			_serializeService = serializeService;
			_timeProvider = timeProvider;
		}

		public void Save(Reconciliation reconciliation)
		{
			if (reconciliation == null) throw new ArgumentNullException($"{nameof(reconciliation)} cannot be null");
			_serializeService.Serialize(reconciliation, $"Reconciliation on {_timeProvider.Now:yyyy-MM-dd}");
		}

		public Reconciliation Get(DateTime dateTime) =>		
			_serializeService.Deserialize<Reconciliation>($"Reconciliation on {dateTime:yyyy-MM-dd}");

		public IEnumerable<Reconciliation> GetAll()
		{

		}
			
	}
}
