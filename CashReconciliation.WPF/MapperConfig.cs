using System.Globalization;
using AutoMapper;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.Core.Denominations;
using CashReconciliation.WPF.ViewModels;
using Prism.Unity;

namespace CashReconciliation.WPF
{
	public class MapperConfig
	{
		public static MapperConfiguration InitializeAutoMapper(PrismApplication app)
		{
			var config = new MapperConfiguration(c =>
			                                     {
													 c.ConstructServicesUsing(t => app.Container.Resolve(t));
				                                     c.CreateMap<Denomination, DenominationViewModel>();
				                                      //.ForMember(m => m.Value, opt => opt.MapFrom(d => $"{d.Value:C}"))
				                                      //.ReverseMap()
				                                      //.ForMember(m => m.Value, opt => opt.MapFrom(d => decimal.Parse(d.Value, NumberStyles.Currency)));

				                                     c.CreateMap<CashEntry, CashEntryViewModel>()
				                                      .ConstructUsingServiceLocator();
				                                     //.ForMember(m => m.Total, opt => opt.MapFrom(d => $"{d.Total:C}"))
				                                     //.ReverseMap()
				                                     //.ForMember(m => m.Total, opt => opt.Ignore())
				                                     //.ForPath(m => m.Denomination, opt => opt.MapFrom(src => src.Denomination));

			                                     });
			return config;
		}
	}
}