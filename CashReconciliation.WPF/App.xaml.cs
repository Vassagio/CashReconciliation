using System.Windows;
using CashReconciliation.Core;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.Core.Denominations;
using CashReconciliation.Core.Reconciliations;
using CashReconciliation.WPF.Mappers;
using CashReconciliation.WPF.ViewModels;
using CashReconciliation.WPF.Views;
using Prism.Ioc;
using Prism.Unity;

namespace CashReconciliation.WPF
{
	public partial class App: PrismApplication
	{
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<StartingCashViewModel>();
			containerRegistry.Register<IDenominationService, DenominationService>();			
			containerRegistry.Register<ICashEntryService, CashEntryService>();			
			containerRegistry.Register<IReconciliationService, ReconciliationService>();	
			containerRegistry.Register<IDenominationMapper, DenominationMapper>();	
			containerRegistry.Register<ICashEntryMapper, CashEntryMapper>();	
			containerRegistry.Register<IReconciliationMapper, ReconciliationMapper>();	
		}

		protected override IContainerExtension CreateContainerExtension() => new CoreDependencyExtension();

		protected override Window CreateShell() => Container.Resolve<MainWindow>();
	}
}