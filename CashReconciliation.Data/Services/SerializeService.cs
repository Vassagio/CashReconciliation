﻿using System;
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
			try
			{
				var serializer = new XmlSerializer(typeof(T));
				using (var writer = new StreamWriter(_directoryProxy.GetFilePath(fileName)))
					serializer.Serialize(writer, obj);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			
		}

		public IOptional<T> Deserialize<T>(string fileName)
		{
			var filePath = _directoryProxy.GetFilePath(fileName);
			if (!File.Exists(filePath)) return Optional<T>.Empty();
			var serializer = new XmlSerializer(typeof(T));

			using (var reader = new StreamReader(filePath))			
				return Optional<T>.Of((T) serializer.Deserialize(reader));			
		}		
	}
}