
namespace ConvertFileToLowerCase
{
	public class ConversionOrquestator(IFileManager FileManager)
	{
		public IConverter Converter { get; set; }

		/// <summary>
		/// Convert file content using provided Converter
		/// </summary>
		/// <exception cref="InvalidOperationException"/>"
		public void ConvertFile(string fileName)
		{
			var lines = FileManager.ReadLinesFromFile(fileName);

			List<string> result = lines.Select(x => Converter.Convert(x)).ToList();

			FileManager.SaveLinesToFile(fileName, result);
		}
	}
}