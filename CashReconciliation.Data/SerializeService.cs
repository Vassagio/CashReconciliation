using System.IO;
using System.Xml.Serialization;
using CashReconciliation.Data.Implementation;

namespace CashReconciliation.Data
{
	internal class SerializeService : ISerializeService
	{
		public void Serialize<T>(T obj, string fileName)
		{
			var serializer = new XmlSerializer(typeof(T));
			using (var writer = new StreamWriter(fileName))			
				serializer.Serialize(writer, obj);			
		}

		public T Deserialize<T>(string fileName)
		{
			var serializer = new XmlSerializer(typeof(T));
			using (var reader = new StreamReader(fileName))			
				return (T) serializer.Deserialize(reader);			
		}
	}
}