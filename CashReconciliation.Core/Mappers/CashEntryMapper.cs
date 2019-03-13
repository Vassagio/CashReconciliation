using CashReconciliation.Core.CashEntries;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core.Mappers
{
	public class CashEntryMapper : ICashEntryMapper
	{
		private readonly IDenominationMapper _denominationMapper;

		public CashEntryMapper(IDenominationMapper denominationMapper) => _denominationMapper = denominationMapper;

		public CashEntry Map(DTO.CashEntry dto) => new CashEntry(dto.Denomination.Description, dto.Denomination.Value, dto.Quantity);

		public DTO.CashEntry Map(CashEntry model) => new DTO.CashEntry
		{
			Denomination = _denominationMapper.Map(model.Denomination),
			Quantity = model.Quantity
		};
	}
}