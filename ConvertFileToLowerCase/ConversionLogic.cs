
namespace ConvertFileToLowerCase
{
	public class ConversionLogic : IConverter
	{
		public string Convert(string? text)
		{
			return text?.ToLower() ?? string.Empty;
		}
	}
}
