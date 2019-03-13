using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Core.CheckEntries;
using CashReconciliation.Core.Reconciliations;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core.Mappers
{
	public class ReconciliationMapper : IReconciliationMapper
	{
		private readonly ICashEntryMapper _cashEntryMapper;

		public ReconciliationMapper(ICashEntryMapper cashEntryMapper) => _cashEntryMapper = cashEntryMapper;

		public Reconciliation Map(DTO.Reconciliation dto)
		{
			var startOfDayCashEntries = dto.StartOfDayCashEntries.Select(e => _cashEntryMapper.Map(e));
			var endOfDayCashEntries = dto.EndOfDayCashEntries.Select(e => _cashEntryMapper.Map(e));
			return new Reconciliation(dto.ReconciledDate, startOfDayCashEntries, endOfDayCashEntries, new List<CheckEntry>());
		}

		public DTO.Reconciliation Map(Reconciliation model)
		{
			var startOfDayCashEntities = model.StartOfDayCashEntries.Select(e => _cashEntryMapper.Map(e));
			var endOfDayCashEntities = model.EndOfDayCashEntries.Select(e => _cashEntryMapper.Map(e));
			return new DTO.Reconciliation
			{
				ReconciledDate = model.ReconciledDate,
				StartOfDayCashEntries = startOfDayCashEntities.ToList(),
				EndOfDayCashEntries = endOfDayCashEntities.ToList(),
				EndOfDayCheckEntries = new List<DTO.CheckEntry>()
			};
		}
	}
}