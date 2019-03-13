namespace CashReconciliation.Data.Services
{
	public interface IDirectoryProxy
	{
		string Folder { get; }

		string GetFilePath(string fileName);
		string[] GetAllFiles(string searchPattern = "*");
	}
}