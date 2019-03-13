using System;
using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Core.Mappers;
using CashReconciliation.Data;
using DTO = CashReconciliation.Data.Entities;

namespace CashReconciliation.Core.Denominations
{
	public class DenominationService : IDenominationService
	{
		private readonly IDenominationRepository _repository;
		private readonly IDenominationMapper _mapper;

		public DenominationService(IDenominationRepository repository, IDenominationMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<Denomination> Get() => _repository.Get().Select(i => _mapper.Map(i));

		public void Add(Denomination denomination)
		{
			if (denomination == null) throw new ArgumentNullException();
			_repository.Insert(_mapper.Map(denomination));			
		}
	}
}