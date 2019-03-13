using CashEntry = CashReconciliation.Core.CashEntries.CashEntry;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core.Mappers
{
	public interface ICashEntryMapper
	{
		CashEntry Map(DTO.CashEntry dto);
		DTO.CashEntry Map(CashEntry model);
	}
}