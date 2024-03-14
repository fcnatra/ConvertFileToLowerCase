
namespace ConvertFileToLowerCase
{
	public class CustomFileManager : IFileManager
	{
		public List<string> ReadLinesFromFile(string fileName)
		{
			List<string> resultLines = [];

			try
			{
				resultLines = File.ReadAllLines(fileName).ToList();

			}
			catch (FileNotFoundException)
			{ /* empty list is returned */}
			catch (DirectoryNotFoundException ex1)
			{
				var newException = new InvalidOperationException("Directory not found", ex1);
				throw newException;
			}
			catch (UnauthorizedAccessException ex2)
			{
				var newException = new InvalidOperationException("Unauthorized access", ex2);
				throw newException;
			}

			return resultLines;
		}

		public void SaveLinesToFile(string fileName, List<string> lines)
		{
			File.WriteAllLines(fileName, lines);
		}
	}
}
