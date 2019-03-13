using Denomination = CashReconciliation.Core.Denominations.Denomination;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core.Mappers
{
	public class DenominationMapper : IDenominationMapper
	{
		public Denomination Map(DTO.Denomination dto) => new Denomination(dto.Description, dto.Value);
		public DTO.Denomination Map(Denomination model) => new DTO.Denomination{Description = model.Description, Value = model.Value};
	}
}