using System;

namespace CashReconciliation.Data.Services
{
	public sealed class DirectoryProxy: IDirectoryProxy
	{
		public string Folder => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
	}
}