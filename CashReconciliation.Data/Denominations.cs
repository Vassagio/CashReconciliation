using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CashReconciliation.Data
{
	[XmlRoot("Denominations")]
	public class Denominations : ICollection<Denomination>
	{
		private readonly ISet<Denomination> _items = new HashSet<Denomination>();

		public int                       Count           => _items.Count;
		public bool                      IsReadOnly      => _items.IsReadOnly;
		public IEnumerator<Denomination> GetEnumerator() => _items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public void Add(Denomination item)
		{
			if (item == null) return;
			_items.Add(item);
		}

		public void Clear() => _items.Clear();

		public bool Contains(Denomination item) => item != null && _items.Contains(item);

		public void CopyTo(Denomination[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

		public bool Remove(Denomination item) => item != null && _items.Remove(item);
	}
}