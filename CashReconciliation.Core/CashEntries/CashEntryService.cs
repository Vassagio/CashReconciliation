using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CashReconciliation.Data;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core.CashEntries
{
	public class CashEntryService : ICashEntryService
	{
		private readonly IStartingCashRepository _repository;
		private readonly IMapper _mapper;

		public CashEntryService(IStartingCashRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<CashEntry> Get() => _repository.Get()
		                                                  .Select(i => _mapper.Map<CashEntry>(i))
		                                                  .OrderByDescending(i => i.Denomination.Value);

		public decimal GetTotal() => Get().Sum(i => i.Total);

		public void Add(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();

			_repository.Insert(_mapper.Map<DTO.CashEntry>(cashEntry));
		}

		public void Remove(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();

			_repository.Delete(_mapper.Map<DTO.CashEntry>(cashEntry));
		}

		public CashEntry Update(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();

			var item = _repository.Update(_mapper.Map<DTO.CashEntry>(cashEntry));
			return _mapper.Map<CashEntry>(item);
		}
	}
}