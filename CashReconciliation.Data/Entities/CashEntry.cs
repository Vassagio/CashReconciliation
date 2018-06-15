using System.Xml.Serialization;

namespace CashReconciliation.Data.Entities
{
	public sealed class CashEntry
	{
		[XmlElement]
		public Denomination Denomination { get; set; }

		[XmlElement]
		public int Quantity { get; set; }
	}
}
