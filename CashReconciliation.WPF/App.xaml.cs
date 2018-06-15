using System.Windows;
using CashReconciliation.Core;
using CashReconciliation.WPF.Views;
using Prism.Ioc;

namespace CashReconciliation.WPF
{
	public partial class App
	{
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<IDenominationService, DenominationService>();
			containerRegistry.Register<IDenominaionMapper, DenominaionMapper>();
		}

		protected override IContainerExtension CreateContainerExtension() => new CoreDependencyExtension();

		protected override Window CreateShell() => Container.Resolve<MainWindow>();
	}
}