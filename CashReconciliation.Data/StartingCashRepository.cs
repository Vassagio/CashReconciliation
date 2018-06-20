using System;
using System.Collections.Generic;
using System.Linq;
using CashReconciliation.Data.Entities;
using CashReconciliation.Data.Services;
using MBI.Utilities.Optional.Extensions;

namespace CashReconciliation.Data
{
	public class StartingCashRepository : IStartingCashRepository
	{
		private const string FILE_NAME = "startingCash.xml";

		private readonly IEnumerable<CashEntry> _defaultItems = new List<CashEntry>
		{
			new CashEntry {Denomination = new Denomination {Description = "Hundred", Value = 100.00m}, Quantity = 0},
			new CashEntry {Denomination = new Denomination {Description = "Fifty", Value = 50.00m}, Quantity = 0},
			new CashEntry {Denomination = new Denomination {Description = "Twenty", Value = 20.00m}, Quantity = 10},
			new CashEntry {Denomination = new Denomination {Description = "Ten", Value = 10.00m}, Quantity = 10},
			new CashEntry {Denomination = new Denomination {Description = "Five", Value = 5.00m}, Quantity = 20},
			new CashEntry {Denomination = new Denomination {Description = "Two", Value = 2.00m}, Quantity = 0},
			new CashEntry {Denomination = new Denomination {Description = "One", Value = 1.00m}, Quantity = 20},

			new CashEntry {Denomination = new Denomination {Description = "Dollar", Value = 1.00m}, Quantity = 0},
			new CashEntry {Denomination = new Denomination {Description = "Half-Dollar", Value = 0.50m}, Quantity = 0},
			new CashEntry {Denomination = new Denomination {Description = "Quarter", Value = 0.25m}, Quantity = 20},
			new CashEntry {Denomination = new Denomination {Description = "Dime", Value = 0.10m}, Quantity = 20},
			new CashEntry {Denomination = new Denomination {Description = "Nickel", Value = 0.05m}, Quantity = 20},
			new CashEntry {Denomination = new Denomination {Description = "Penny", Value = 0.01m}, Quantity = 100}
		};

		private readonly ISerializeService _serializeService;

		private IList<CashEntry> _items = new List<CashEntry>();

		public StartingCashRepository(ISerializeService serializeService) => _serializeService = serializeService ?? throw new ArgumentNullException();

		public IEnumerable<CashEntry> Get()
		{
			var result = _serializeService.Deserialize<CashEntry[]>(FILE_NAME);
			_items = result.Handle(r => r.ToList(), () => _defaultItems.ToList());
			return _items;
		}

		public void Insert(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();
			if (_items.Contains(cashEntry)) throw new ArgumentException("duplicate");

			InsertItem(cashEntry);
			Save();
		}

		public void Delete(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();

			RemoveItem(cashEntry);
			Save();
		}

		public CashEntry Update(CashEntry cashEntry)
		{
			if (cashEntry == null) throw new ArgumentNullException();

			var item = _items.FirstOrOptional(i => i.Equals(cashEntry));
			var itemToInsert = item.Handle(i => UpdateItem(i, cashEntry), () => cashEntry);
			InsertItem(itemToInsert);
			Save();
			return itemToInsert;
		}

		private void InsertItem(CashEntry cashEntry) => _items.Add(cashEntry);

		private void RemoveItem(CashEntry cashEntry) => _items.Remove(cashEntry);

		private CashEntry UpdateItem(CashEntry oldCashEntry, CashEntry newCashEntry)
		{
			RemoveItem(oldCashEntry);
			return new CashEntry
			{
				Denomination = newCashEntry.Denomination,
				Quantity = newCashEntry.Quantity
			};
		}

		private void Save() => _serializeService.Serialize(_items.ToArray(), FILE_NAME);
	}
}