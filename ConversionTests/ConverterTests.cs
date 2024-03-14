using ConvertFileToLowerCase;

namespace ConversionTests
{
	public class ConverterTests
	{
		[Fact]
		public void GivenCamelCaseString_ReturnsAllInLowerCase()
		{
			// ARRANGE
			var text = "This is an Input String";
			var expectedResult = "this is an input string";

			ConversionLogic converter = new();

			// ACT
			string result = converter.Convert(text);

			// ASSERT
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void GivenNullString_ReturnsEmptyString()
		{
			// ARRANGE
			string? text = null;
			var expectedResult = string.Empty;

			ConversionLogic converter = new();

			// ACT
			string result = converter.Convert(text);

			// ASSERT
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void GivenStringEndingWithNewLine_ReturnsStringEndingWithNewLine()
		{
			// ARRANGE
			string text = "This is an example of Input String\n";
			var expectedResult = "this is an example of input string\n";

			ConversionLogic converter = new();

			// ACT
			string result = converter.Convert(text);

			// ASSERT
			Assert.Equal(expectedResult, result);
			Assert.EndsWith("\n", result);
		}
	}
}