using Model = CashReconciliation.Core.Models;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core
{
	public class DenominaionMapper : IDenominaionMapper
	{
		public Model.Denomination Map(DTO.Denomination denomination) =>
			new Model.Denomination
			{
				Description = denomination.Description,
				Value = denomination.Value
			};

		public DTO.Denomination Map(Model.Denomination denomination) =>		
			new DTO.Denomination
			{
				Description = denomination.Description,
				Value = denomination.Value
			};		
	}
}