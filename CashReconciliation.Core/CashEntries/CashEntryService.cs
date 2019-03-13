using System;
using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Core.Mappers;
using CashReconciliation.Data;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core.CashEntries
{
	public class CashEntryService : ICashEntryService
	{
		private readonly IStartingCashRepository _repository;
		private readonly ICashEntryMapper _mapper;

		public CashEntryService(IStartingCashRepository repository, ICashEntryMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<CashEntry> Get() => _repository.Get()
		                                                  .Select(i => _mapper.Map(i))
		                                                  .OrderByDescending(i => i.Denomination.Value);

		public decimal GetTotal() => Get().Sum(i => i.Total);

		public void Add(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();

			_repository.Insert(_mapper.Map(cashEntry));
		}

		public void Remove(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();

			_repository.Delete(_mapper.Map(cashEntry));
		}

		public CashEntry Update(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();

			var item = _repository.Update(_mapper.Map(cashEntry));
			return _mapper.Map(item);
		}
	}
}