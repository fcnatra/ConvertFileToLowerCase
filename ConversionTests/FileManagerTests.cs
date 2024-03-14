using ConvertFileToLowerCase;

namespace ConversionTests
{
	public class FileManagerTests
	{
		[Fact]
		public void GivenNonExistingFile_WhenReading_ReturnsEmptyList()
		{
			// ARRANGE
			var fileManager = new CustomFileManager();

			// ACT
			var lines = fileManager.ReadLinesFromFile($"imposible_file_name{DateTime.Now.Ticks}");

			// ASSERT
			Assert.Empty( lines );
		}


		[Fact]
		public void GivenInvalidPath_WhenReading_AccessException()
		{
			// ARRANGE
			var fileManager = new CustomFileManager();

			// ACT
			Action act = () => fileManager.ReadLinesFromFile($"C:\\impossibleFolderName{DateTime.Now.Ticks}\\fileName");

			// ASSERT
			Assert.Throws<InvalidOperationException>(act);
		}


		[Fact]
		public void GivenUnauthorizedPath_WhenReading_AccessException()
		{
			// ARRANGE
			var fileManager = new CustomFileManager();

			// ACT
			Action act = () => fileManager.ReadLinesFromFile($"C:\\");

			// ASSERT
			Assert.Throws<InvalidOperationException>( act );
		}
	}
}