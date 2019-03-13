using DTO = CashReconciliation.Data.Entities;
using Reconciliation = CashReconciliation.Core.Reconciliations.Reconciliation;

namespace CashReconciliation.Core.Mappers
{
	public interface IReconciliationMapper
	{
		Reconciliation Map(DTO.Reconciliation dto);
		DTO.Reconciliation Map(Reconciliation model);
	}
}