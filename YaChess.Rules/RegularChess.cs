namespace YaChess.Rules;

public static class RegularChess {
  public const int BoardSide = 8;

  private const string BoardLetters = "abcdefgh";
  private const string BoardNumbers = "12345678";

  public const string PossibleEnPassantNumbers = "36";

  public static bool IsSimpleBoardPosition(string pos) 
    => !string.IsNullOrEmpty(pos) && pos.Length == 2 && 
       BoardLetters.Contains(pos[0]) && BoardNumbers.Contains(pos[1]);
}