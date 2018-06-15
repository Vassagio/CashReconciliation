using CashReconciliation.Data;
using Prism.Unity.Ioc;

namespace CashReconciliation.Core
{
	public class CoreDependencyExtension:UnityContainerExtension
	{
		public CoreDependencyExtension()
		{
			Register(typeof(ISomeRepository), typeof(SomeRepository));
		}
	}
}
