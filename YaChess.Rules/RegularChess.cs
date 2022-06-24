namespace YaChess.Rules;

public static class RegularChess {
  public const int BoardSide = 8;

  public const string BoardLetters = "abcdefgh";
  public const string BoardNumbers = "12345678";

  public static bool IsSimpleBoardPosition(string pos) 
    => !string.IsNullOrEmpty(pos) && pos.Length == 2 && 
       BoardLetters.Contains(pos[0]) && BoardNumbers.Contains(pos[1]);
}