using System.Xml.Serialization;

namespace CashReconciliation.Data.Entities
{
	public sealed class CheckEntry
	{
		[XmlElement]
		public int CheckNumber { get; set; }

		[XmlElement]
		public decimal Amount { get; set; }
	}
}