using ConvertFileToLowerCase;
using FakeItEasy;

namespace ConversionTests
{
	public class CoreLogicTests
	{
		[Fact]
		public void GivenFileName_FileLinesAreRead()
		{
			// ARRANGE
			IFileManager fakeFileManager = A.Fake<IFileManager>();
			var orquestator = new ConversionOrquestator(fakeFileManager);

			// ACT
			orquestator.ConvertFile("Any FileName");

			// ASSERT
			A.CallTo(() => fakeFileManager.ReadLinesFromFile(A<string>._)).MustHaveHappenedOnceExactly();
		}

		[Fact]
		public void GivenFileNameToLoad_FileNameIsOverwrittenWithConvertedLines()
		{
			// ARRANGE
			string fileName = "Any file name";

			IFileManager fakeFileManager = A.Fake<IFileManager>();
			IConverter fakeConverter = A.Fake<IConverter>();

			var orquestator = new ConversionOrquestator(fakeFileManager);
			orquestator.Converter = fakeConverter;

			// ACT
			orquestator.ConvertFile(fileName);

			// ASSERT
			A.CallTo(() => fakeFileManager
				.SaveLinesToFile(A<string>.That.IsEqualTo(fileName), A<List<string>>._))
				.MustHaveHappenedOnceExactly();
		}

		[Fact]
		public void GivenLinesReadFromFile_LinesAreParsed()
		{
			// ARRANGE
			List<string> linesRead = new List<string> { "Line 1", "Content 2", "Paragraph 3" };

			IFileManager fakeFileManager = A.Fake<IFileManager>();
			A.CallTo(() => fakeFileManager.ReadLinesFromFile(A<string>._)).Returns(linesRead); 
			
			IConverter fakeConverter = A.Fake<IConverter>();

			var orquestator = new ConversionOrquestator(fakeFileManager);
			orquestator.Converter = fakeConverter;
			// ACT
			orquestator.ConvertFile("Any FileName");

			// ASSERT
			A.CallTo(() => fakeConverter.Convert(A<string>._)).MustHaveHappened(3, Times.Exactly);
			A.CallTo(() => fakeConverter.Convert(A<string>.That.IsEqualTo("Line 1"))).MustHaveHappenedOnceExactly();
			A.CallTo(() => fakeConverter.Convert(A<string>.That.IsEqualTo("Content 2"))).MustHaveHappenedOnceExactly();
			A.CallTo(() => fakeConverter.Convert(A<string>.That.IsEqualTo("Paragraph 3"))).MustHaveHappenedOnceExactly();
		}

		[Fact]
		public void GivenLinesReadFromFile_ConvertedLinesAreSaved()
		{
			// ARRANGE
			List<string> linesRead = new List<string> { "Line 1", "Content 2", "Paragraph 3" };
			List<string> linesToSave = new List<string> { "line 1", "content 2", "paragraph 3" };

			IFileManager fakeFileManager = A.Fake<IFileManager>();
			A.CallTo(() => fakeFileManager.ReadLinesFromFile(A<string>._)).Returns(linesRead);

			IConverter fakeConverter = A.Fake<IConverter>();
			A.CallTo(() => fakeConverter.Convert(A<string?>._)).ReturnsNextFromSequence(linesToSave.ToArray());

			var orquestator = new ConversionOrquestator(fakeFileManager);
			orquestator.Converter = fakeConverter;
			// ACT
			orquestator.ConvertFile("Any FileName");

			// ASSERT
			A.CallTo(() => fakeFileManager
				.SaveLinesToFile(A<string>._, A<List<string>>.That.IsSameSequenceAs(linesToSave)))
				.MustHaveHappenedOnceExactly();
		}
	}
}