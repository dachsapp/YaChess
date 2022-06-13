using System.Text;

namespace YaChess.Filer;

public class FileManipulator {
  private readonly string _fileName;

  public FileManipulator(string fileName) {
    _fileName = fileName;
    if (!File.Exists(_fileName))
      throw new FileNotFoundException($"The file \"{_fileName}\" doesn't exist.");
  }

  public string Read() => File.ReadAllText(_fileName, Encoding.UTF8);
  
  public void ReplacementWrite(string text) 
    => File.WriteAllText(_fileName, text, Encoding.UTF8);

  public void Attach(string text) {
    string previousText = Read();
    ReplacementWrite($"{previousText}{text}");
  }

  public void AttachInNewLine(string text) {
    Attach($"\n{text}");
  }

  public void AttachAsNewLine(string text) {
    Attach($"\n{text}\n");
  }
}