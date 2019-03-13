using Denomination = CashReconciliation.Core.Denominations.Denomination;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core.Mappers
{
	public interface IDenominationMapper
	{
		Denomination Map(DTO.Denomination dto);
		DTO.Denomination Map(Denomination model);
	}
}