using System;
using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Data.Entities;
using CashReconciliation.Data.Services;

namespace CashReconciliation.Data
{
	public class DenominationRepository : IDenominationRepository
	{
		private const string FILE_NAME = "denominations.xml";
		private readonly ISerializeService _serializeService;

		private readonly IEnumerable<Denomination> _defaultItems = new List<Denomination>
		{
			new Denomination{Description = "Hundred", Value = 100.00m},
			new Denomination{Description = "Fifty", Value = 50.00m},
			new Denomination{Description = "Twenty", Value = 20.00m},
			new Denomination{Description = "Ten", Value = 10.00m},
			new Denomination{Description = "Five", Value = 5.00m},
			new Denomination{Description = "Two", Value = 2.00m},
			new Denomination{Description = "One", Value = 1.00m},

			new Denomination{Description = "Dollar", Value = 1.00m},
			new Denomination{Description = "Half-Dollar", Value = 0.50m},
			new Denomination{Description = "Quarter", Value = 0.25m},
			new Denomination{Description = "Dime", Value = 0.10m},
			new Denomination{Description = "Nickel", Value = 0.05m},
			new Denomination{Description = "Penny", Value = 0.01m},			
		};

		private IList<Denomination> _items = new List<Denomination>();

		public DenominationRepository(ISerializeService serializeService) => _serializeService = serializeService ?? throw new ArgumentNullException();

		public IEnumerable<Denomination> Get()
		{
			var result = _serializeService.Deserialize<Denomination[]>(FILE_NAME);
			_items = result.Handle(r => r.ToList(), () => _defaultItems.ToList());
			return _items;
		}

		public void Insert(Denomination denomination)
		{
			if (denomination == null) throw new ArgumentNullException();
			if (_items.Contains(denomination)) throw new ArgumentException("duplicate");

			_items.Add(denomination);
			Save();
		}

		private void Save() => _serializeService.Serialize(_items.ToArray(), FILE_NAME);
	}
}