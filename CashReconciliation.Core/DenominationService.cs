using System;
using CashReconciliation.Core.Models;
using CashReconciliation.Data;
using System.Collections.Generic;
using System.Linq;

namespace CashReconciliation.Core
{
	public class DenominationService : IDenominationService
	{
		private readonly IDenominationRepository _repository;
		private readonly IDenominaionMapper _mapper;

		public DenominationService(IDenominationRepository repository, IDenominaionMapper mapper)
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