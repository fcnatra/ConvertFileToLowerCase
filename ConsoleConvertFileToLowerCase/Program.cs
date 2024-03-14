using ConvertFileToLowerCase;

internal class Program
{
	private static void Main(string[] args)
	{
		IFileManager fileManager = new CustomFileManager();
		ConversionOrquestator orquestator = new(fileManager);

		orquestator.Converter = new ConversionLogic();

		try
		{
			orquestator.ConvertFile(args[0]);
		}
		catch (InvalidOperationException)
		{
			Console.WriteLine("Operation could not be performed");
		}
	}
}