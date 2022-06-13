namespace FileTester; 

public class WritingTester {
  [Test]
  [TestCase("Hello World!")]
  [TestCase("¡Hola Mundo!")]
  [TestCase("مرجباً يا عالـــــم")]
  [TestCase("こんにちは世界")]
  [TestCase("😂👩🏾‍🚒🚒👩‍👩‍👦‍👦👩‍👩‍👦‍👦👨‍👩‍👧‍👦")]  
  public void WritingOneLine_WritesOneLineCorrectly(string expectedValue) {
    const string fileName = ".testingFile";
    var fileManipulator = new FileManipulator(fileName);
    
    fileManipulator.ReplacementWrite(expectedValue);
    string actualValue = ReadFile(fileName);
    
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
  public void WritingMultipleLines_WritesAllLinesCorrectly(string expectedValue) {
    const string fileName = ".testingFile";
    var fileManipulator = new FileManipulator(fileName);
    
    fileManipulator.ReplacementWrite(expectedValue);
    string actualValue = ReadFile(fileName);
    
    Assert.That(actualValue, Is.EqualTo(expectedValue));
  }

  [Test]
  [TestCase("Hello World!")]
  [TestCase("¡Hola Mundo!")]
  [TestCase("مرجباً يا عالـــــم")]
  [TestCase("こんにちは世界")]
  [TestCase("😂👩🏾‍🚒🚒👩‍👩‍👦‍👦👩‍👩‍👦‍👦👨‍👩‍👧‍👦")]  
  public void AttachingText_AttachedTextCorrectly(string attachmentValue) {
    const string fileName = ".testingFile";
    var fileManipulator = new FileManipulator(fileName);

    const string originalText = "Ohhhh, Makarena!";
    string expectedValue = originalText + attachmentValue;

    WriteFile(fileName, originalText);
    fileManipulator.Attach(attachmentValue);
    string actualValue = ReadFile(fileName);
    
    Assert.That(actualValue, Is.EqualTo(expectedValue));
  }

  [Test]
  [TestCase("Hello World!")]
  [TestCase("¡Hola Mundo!")]
  [TestCase("مرجباً يا عالـــــم")]
  [TestCase("こんにちは世界")]
  [TestCase("😂👩🏾‍🚒🚒👩‍👩‍👦‍👦👩‍👩‍👦‍👦👨‍👩‍👧‍👦")]  
  public void AttachingOneLine_AttachedOneLineCorrectly(string attachmentValue) {
    const string fileName = ".testingFile";
    var fileManipulator = new FileManipulator(fileName);

    const string originalText = "Ohhhh, Makarena!";
    string expectedValue = $"{originalText}\n{attachmentValue}";

    WriteFile(fileName, originalText);
    fileManipulator.AttachInNewLine(attachmentValue);
    string actualValue = ReadFile(fileName);
    
    Assert.That(actualValue, Is.EqualTo(expectedValue));
  }

  [Test]
  [TestCase("Hello World!")]
  [TestCase("¡Hola Mundo!")]
  [TestCase("مرجباً يا عالـــــم")]
  [TestCase("こんにちは世界")]
  [TestCase("😂👩🏾‍🚒🚒👩‍👩‍👦‍👦👩‍👩‍👦‍👦👨‍👩‍👧‍👦")]  
  public void AttachOneLineAsNewLine_AttachedLineCorrectly(string attachmentValue) {
    const string fileName = ".testingFile";
    var fileManipulator = new FileManipulator(fileName);

    const string originalText = "Ohhhh, Makarena!";
    string expectedValue = $"{originalText}\n{attachmentValue}\n";

    WriteFile(fileName, originalText);
    fileManipulator.AttachAsNewLine(attachmentValue);
    string actualValue = ReadFile(fileName);
    
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
  public void AttachMultipleLines_AttachMultipleLinesCorrectly(string attachmentValue) {
    const string fileName = ".testingFile";
    var fileManipulator = new FileManipulator(fileName);

    const string originalText = "Ohhhh, Makarena!";
    string expectedValue = originalText + attachmentValue;

    WriteFile(fileName, originalText);
    fileManipulator.Attach(attachmentValue);
    string actualValue = ReadFile(fileName);
    
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
  public void AttachMultipleNewLines_AttachMultipleNewLinesCorrectly(string attachmentValue) {
    const string fileName = ".testingFile";
    var fileManipulator = new FileManipulator(fileName);

    const string originalText = "Ohhhh, Makarena!";
    string expectedValue = $"{originalText}\n{attachmentValue}";

    WriteFile(fileName, originalText);
    fileManipulator.AttachInNewLine(attachmentValue);
    string actualValue = ReadFile(fileName);
    
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
  public void AttachMultipleLinesAsNewLies_AttachMultipleLinesCorrectly(string attachmentValue) {
    const string fileName = ".testingFile";
    var fileManipulator = new FileManipulator(fileName);

    const string originalText = "Ohhhh, Makarena!";
    string expectedValue = $"{originalText}\n{attachmentValue}\n";

    WriteFile(fileName, originalText);
    fileManipulator.AttachAsNewLine(attachmentValue);
    string actualValue = ReadFile(fileName);
    
    Assert.That(actualValue, Is.EqualTo(expectedValue));
  }
  
  private static void WriteFile(string fileName, string text) {
    File.WriteAllText(fileName, text);
  }
  private static string ReadFile(string fileName) {
    string fileContent = string.Empty;
    
    if (File.Exists(fileName))
      fileContent = File.ReadAllText(fileName);

    return fileContent;
  }
}

