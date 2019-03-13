using System;
using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Core.CashEntries;
using CashReconciliation.Core.CheckEntries;
using CashReconciliation.Core.Mappers;
using DTO = CashReconciliation.Data.Entities;
using CashReconciliation.Data;
using MBI.Utilities.Optional;

namespace CashReconciliation.Core.Reconciliations
{

	public class ReconciliationService : IReconciliationService
	{
		private readonly IReconciliationRepository _reconciliationRepository;
		private readonly IStartingCashRepository _startingCashRepository;
		private readonly IReconciliationMapper _reconciliationMapper;
		private readonly ICashEntryMapper _cashEntryMapper;

		public ReconciliationService(IReconciliationRepository reconciliationRepository, IStartingCashRepository startingCashRepository, IReconciliationMapper reconciliationMapper, ICashEntryMapper cashEntryMapper)
		{
			_reconciliationRepository = reconciliationRepository;
			_startingCashRepository = startingCashRepository;
			_reconciliationMapper = reconciliationMapper;
			_cashEntryMapper = cashEntryMapper;
		}

		public IEnumerable<Reconciliation> GetAll()
		{
			var todaysReconciliation = _reconciliationRepository.Get(DateTime.Now.Date);
			return todaysReconciliation.Handle(GetAll, AddToday);
		}

		private IEnumerable<Reconciliation> GetAll(DTO.Reconciliation reconciliation) =>		
			 _reconciliationRepository.GetAll().Select(_reconciliationMapper.Map).ToList();
					
		private IEnumerable<Reconciliation> AddToday()
		{			
			var startingCash = _startingCashRepository.Get().Select(_cashEntryMapper.Map).ToList();
			var reconciliation = new Reconciliation(DateTime.Now.Date, new List<CashEntry>(startingCash), new List<CashEntry>(startingCash), new List<CheckEntry>());
			Add(reconciliation);
			
			return GetAll();
		}

		public void Add(Reconciliation reconciliation)
		{
			if (reconciliation == null) throw new ArgumentNullException();

			_reconciliationRepository.Save(_reconciliationMapper.Map(reconciliation));
		}

		public IOptional<Reconciliation> Get(DateTime reconciledDate)
		{
			var result = _reconciliationRepository.Get(reconciledDate.Date);
			return result.Handle(r => Optional<Reconciliation>.Of(_reconciliationMapper.Map(r)), Optional<Reconciliation>.Empty);
		}

		public void Update(Reconciliation reconciliation)
		{
			if (reconciliation == null) throw new ArgumentNullException();

			_reconciliationRepository.Save(_reconciliationMapper.Map(reconciliation));
		}
	}
}
