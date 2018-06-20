using System.Windows;
using AutoMapper;
using CashReconciliation.Core;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.Core.Denominations;
using CashReconciliation.WPF.Views;
using Prism.Ioc;
using Prism.Unity;

namespace CashReconciliation.WPF
{
	public partial class App: PrismApplication
	{
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<IDenominationService, DenominationService>();			
			containerRegistry.Register<ICashEntryService, CashEntryService>();			
			containerRegistry.RegisterInstance(MapperConfig.InitializeAutoMapper(this).CreateMapper());
		}

		protected override IContainerExtension CreateContainerExtension() => new CoreDependencyExtension();

		protected override Window CreateShell() => Container.Resolve<MainWindow>();
	}
}