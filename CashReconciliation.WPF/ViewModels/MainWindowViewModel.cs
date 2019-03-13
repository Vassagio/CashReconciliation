using System.Collections.ObjectModel;
using CashReconciliation.Core.Reconciliations;
using CashReconciliation.WPF.EventAggregators;
using CashReconciliation.WPF.Mappers;
using Prism.Events;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IReconciliationMapper _mapper;
		private readonly IReconciliationService _service;

		private ObservableCollection<DocumentViewModelBase> _documents = new ObservableCollection<DocumentViewModelBase>();
		public ObservableCollection<DocumentViewModelBase> Documents { get => _documents; set => SetProperty(ref _documents, value); }

		public MainWindowViewModel(IEventAggregator aggregator, IReconciliationService service, IReconciliationMapper mapper)
		{
			_service = service;
			_mapper = mapper;
			aggregator.GetEvent<CompactReconciliationClicked>().Subscribe(OpenReconciliation);

			var all = new ReconciliationsViewModel(service, mapper);
			Documents.Add(all);
		}

		private void OpenReconciliation(CompactReconciliationViewModel reconciliation)
		{
			var result = _service.Get(reconciliation.ReconciledDate);
			result.Handle(r =>
			              {
				              var rec = _mapper.Map(r);
				              if (!Documents.Contains(rec))
					              Documents.Add(rec);
			              });
		}
	}
}