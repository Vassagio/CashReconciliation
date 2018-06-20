using AutoMapper;
using CashReconciliation.Data;
using CashReconciliation.Data.Services;
using Prism.Unity.Ioc;

namespace CashReconciliation.Core
{
	public class CoreDependencyExtension:UnityContainerExtension
	{
		public CoreDependencyExtension()
		{
			Register(typeof(IDenominationRepository), typeof(DenominationRepository));				
			Register(typeof(IStartingCashRepository), typeof(StartingCashRepository));
			Register(typeof(ISerializeService), typeof(SerializeService));		
			Register(typeof(IDirectoryProxy), typeof(DirectoryProxy));		
			RegisterInstance(typeof(IMapper), MapperConfig.InitializeAutoMapper().CreateMapper());
		}
	}
}
