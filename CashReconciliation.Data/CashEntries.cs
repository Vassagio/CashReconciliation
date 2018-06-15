using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using CashReconciliation.Data.Implementation;

namespace CashReconciliation.Data
{
	[XmlRoot("CashEntries")]
	public sealed class CashEntries : ICollection<CashEntry>, ICashEntries
	{
		private readonly ISet<CashEntry> _items = new HashSet<CashEntry>();

		public int                    Count           => _items.Count;
		public bool                   IsReadOnly      => _items.IsReadOnly;
		public IEnumerator<CashEntry> GetEnumerator() => _items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public void Add(CashEntry item)
		{
			if (item == null) return;
			_items.Add(item);
		}

		public void Clear() => _items.Clear();

		public bool Contains(CashEntry item) => item != null && _items.Contains(item);

		public void CopyTo(CashEntry[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

		public bool Remove(CashEntry item) => item != null && _items.Remove(item);
	}
}