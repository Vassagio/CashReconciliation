using AutoMapper;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.Core.Denominations;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core
{
	public class MapperConfig
	{
		public static MapperConfiguration InitializeAutoMapper()
		{
			var config = new MapperConfiguration(c =>
			                                     {
				                                     c.CreateMap<CashEntry, DTO.CashEntry>();
				                                     c.CreateMap<Denomination, DTO.Denomination>();
			                                     });
			return config;
		}
	}
}
