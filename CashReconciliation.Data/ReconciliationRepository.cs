using System;
using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Data.Entities;
using CashReconciliation.Data.Services;
using MBI.Utilities.Optional;

namespace CashReconciliation.Data
{
	public class ReconciliationRepository : IReconciliationRepository
	{
		private const string EXTENSION = ".tpf";
		private readonly IDirectoryProxy _directoryProxy;
		private readonly ISerializeService _serializeService;

		public ReconciliationRepository(ISerializeService serializeService, IDirectoryProxy directoryProxy)
		{
			_serializeService = serializeService ?? throw new ArgumentNullException();
			_directoryProxy = directoryProxy;
		}

		public IEnumerable<Reconciliation> GetAll()
		{
			var items = new List<Reconciliation>();
			var fileNames = _directoryProxy.GetAllFiles($"*{EXTENSION}");
			foreach (var result in fileNames.Select(fileName => _serializeService.Deserialize<Reconciliation>(fileName)))
				result.Handle(r => items.Add(r));

			return items;
		}

		public IOptional<Reconciliation> Get(DateTime reconciledDate)
		{
			var fileName = $"Reconciliation-{reconciledDate:yyyyMMdd}{EXTENSION}";
			return _serializeService.Deserialize<Reconciliation>(fileName);			
		}
		
		private Reconciliation Update(Reconciliation newReconciliation) =>
			new Reconciliation
			{
				ReconciledDate = newReconciliation.ReconciledDate,
				EndOfDayCashEntries = newReconciliation.EndOfDayCashEntries,
				StartOfDayCashEntries = newReconciliation.StartOfDayCashEntries,
				EndOfDayCheckEntries = newReconciliation.EndOfDayCheckEntries
			};

		public void Save(Reconciliation reconciliation)
		{
			if (reconciliation == null) throw new ArgumentNullException();

			var item = Get(reconciliation.ReconciledDate);
			var itemToSave = item.Handle(i => Update(reconciliation), () => reconciliation);
			_serializeService.Serialize(itemToSave, $"Reconciliation-{itemToSave.ReconciledDate:yyyyMMdd}{EXTENSION}");
		}
			
	}
}