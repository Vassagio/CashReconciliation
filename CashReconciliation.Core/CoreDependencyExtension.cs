using CashReconciliation.Core.Mappers;
using CashReconciliation.Data;
using CashReconciliation.Data.Services;
using Prism.Unity.Ioc;

namespace CashReconciliation.Core
{
	public class CoreDependencyExtension : UnityContainerExtension
	{
		public CoreDependencyExtension()
		{
			Register(typeof(IDenominationRepository), typeof(DenominationRepository));
			Register(typeof(IStartingCashRepository), typeof(StartingCashRepository));
			Register(typeof(IReconciliationRepository), typeof(ReconciliationRepository));
			Register(typeof(IDenominationMapper), typeof(DenominationMapper));
			Register(typeof(ICashEntryMapper), typeof(CashEntryMapper));
			Register(typeof(IReconciliationMapper), typeof(ReconciliationMapper));
			Register(typeof(ISerializeService), typeof(SerializeService));
			Register(typeof(IDirectoryProxy), typeof(DirectoryProxy));
		}
	}
}