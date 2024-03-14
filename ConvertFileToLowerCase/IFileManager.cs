namespace ConvertFileToLowerCase
{
	public interface IFileManager
	{
		/// <summary>
		/// Read lines from a file
		/// </summary>
		/// <exception cref="InvalidOperationException"/>
		List<string> ReadLinesFromFile(string fileName);

		void SaveLinesToFile(string fileName, List<string> lines);
	}
}