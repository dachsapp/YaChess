namespace FileTester;

public class ReadingTester {

  [Test]
  public void GivenEmptyFile_ReadEmptyString() {
    const string fileName = ".testingFile";
    CreateFileWithText(fileName, string.Empty);

    FileManipulator fileManipulator = new(fileName);

    string expectedValue = string.Empty;
    string actualValue = fileManipulator.Read();
    
    Assert.That(actualValue, Is.EqualTo(expectedValue));
  }
  
  [Test]
  [TestCase("Hello World!")]
  [TestCase("¡Hola Mundo!")]
  [TestCase("مرجباً يا عالـــــم")]
  [TestCase("こんにちは世界")]
  [TestCase("😂👩🏾‍🚒🚒👩‍👩‍👦‍👦👩‍👩‍👦‍👦👨‍👩‍👧‍👦")]
  public void GivenFileWithOneLine_ReadOneFileCorrectly(string expectedValue) {
    const string fileName = ".testingFile";
    CreateFileWithText(fileName, expectedValue);

    FileManipulator fileManipulator = new(fileName);

    string actualValue = fileManipulator.Read();
    
    Assert.That(actualValue, Is.EqualTo(expectedValue));
  }

  [Test]
  [TestCase(@"Hello World!
        Today I'm q
uite Happy to inform y'all that this
        meeting's come to an end. Sooooo, GOOD BYE!!!!!

")]
  [TestCase(@"Hallo Welt!
        Heute bin ich froh Ihnen mitteilen zu dürfen, dass
        dieses Gespräch zu 

einem Ende gekommen ist. Alsooo,
        TSCHÜÜSSSSS!!!!!!!!")]
  [TestCase(@"¡Hola Mundo!
¡Hola Mundo!
¡Hola Mundo!")]
  [TestCase(@"مرجباً يا عالـــــم
مرجباً يا عالـــــم
مرجباً يا عالـــــممرجباً يا عا

لـــــممرجباً يا عالـــــم
مرجباً يا عالـــــم
")]
  [TestCase(@"こんにちは世界
こんにちは世界
こんにちは世界
こんにちは世界

")]
  [TestCase("😂👩🏾‍🚒🚒 👩‍👩‍👦‍👦 👩‍👩‍👦‍👦 👨‍👩‍👧‍👦" +
            "😂👩🏾‍🚒🚒 👩‍👩‍👦‍👦 👩‍👩‍👦‍👦 👨‍👩‍👧‍👦😂👩🏾‍🚒🚒 👩‍👩‍👦‍👦 👩‍👩‍👦‍👦 👨‍👩‍👧‍👦"+
            "😂👩🏾‍🚒🚒 👩‍👩‍👦‍👦 👩‍👩‍👦‍👦 👨‍👩‍👧‍👦"+
            "😂👩🏾‍🚒🚒 👩‍👩‍👦‍👦 👩‍👩‍👦‍👦 👨‍👩‍👧‍👦")]
  public void GivenFileWithMultipleLines_ReadAllLinesCorrectly(string expectedValue) {

    const string fileName = ".testingFile";
    CreateFileWithText(fileName, expectedValue);

    FileManipulator fileManipulator = new(fileName);

    string actualValue = fileManipulator.Read();
    
    Assert.That(actualValue, Is.EqualTo(expectedValue));
  }
  
  private static void CreateFileWithText(string fileName, string text) {
    File.WriteAllText(fileName, text);
  }
}