using System;
using System.IO;

namespace CashReconciliation.Data.Services
{
	public sealed class DirectoryProxy: IDirectoryProxy
	{
		public string Folder => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
		public string GetFilePath(string fileName) => Path.Combine(Folder, fileName);
		public string[] GetAllFiles(string searchPattern = "*") => Directory.GetFiles(Folder, searchPattern);
	}
}