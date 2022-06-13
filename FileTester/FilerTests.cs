namespace FileTester; 

public class FilerTests {
  [Test]
  public void GivenIncorrectFile_ThrowFileNotFoundException() {
    Assert.Throws<FileNotFoundException>(CreateInvalidFileManipulator);
  }

  private static void CreateInvalidFileManipulator() {
    const string incorrectFileName = ".non_existingFile";
    if (File.Exists(incorrectFileName)) File.Delete(incorrectFileName);
    var _ = new FileManipulator(incorrectFileName);
  } 
}