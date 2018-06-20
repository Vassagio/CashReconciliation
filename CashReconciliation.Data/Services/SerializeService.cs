using System.IO;
using System.Xml.Serialization;
using MBI.Utilities.Optional;

namespace CashReconciliation.Data.Services
{
	public sealed class SerializeService : ISerializeService
	{
		private readonly IDirectoryProxy _directoryProxy;

		public SerializeService(IDirectoryProxy directoryProxy) => _directoryProxy = directoryProxy;

		public void Serialize<T>(T obj, string fileName)
		{						
			var serializer = new XmlSerializer(typeof(T));
			using (var writer = new StreamWriter(GetFilePath(fileName)))
				serializer.Serialize(writer, obj);
		}

		public IOptional<T> Deserialize<T>(string fileName)
		{
			var filePath = GetFilePath(fileName);
			if (!File.Exists(filePath)) return Optional<T>.Empty();
			var serializer = new XmlSerializer(typeof(T));

			using (var reader = new StreamReader(filePath))			
				return Optional<T>.Of((T) serializer.Deserialize(reader));			
		}

		private string GetFilePath(string fileName) => Path.Combine(_directoryProxy.Folder, fileName);
	}
}