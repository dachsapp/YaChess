namespace YaChess.Rules;

public static class FenNotation {
  public static bool IsNotNullAndCorrectFenNotation(string fenString) {
    bool correctFenNotation = false;
    if (!string.IsNullOrEmpty(fenString))
      correctFenNotation = IsCorrectFenNotation(fenString);
    return correctFenNotation;
  }

  private static bool IsCorrectFenNotation(string fenString) {
    string[] splitString = fenString.Split(' ');
    return splitString.Length == 6 &&
           IsCorrectBoardNotation(splitString[0]) &&
           IsCorrectTurnNotation(splitString[1]) &&
           IsCorrectCastingAvailabilityNotation(splitString[2]) &&
           IsCorrectEnPassantNotation(splitString[3]) &&
           IsCorrectHalfmoveClockNotation(splitString[4]) &&
           IsCorrectFullmoveNumberNotation(splitString[5]);
  }

  public static string GetBoardStringFromFenNotation(string[] splitFenString)
    => splitFenString[0];

  public static string GetTurnStringFromFenNotation(string[] splitFenString)
    => splitFenString[1];

  public static string GetCastingAvailabilityStringFromFenNotation(string[] splitFenString)
    => splitFenString[2];

  public static string GetEnPassentStringFromFenNotation(string[] splitFenString)
    => splitFenString[3];

  public static string GetHalfmoveClockStringFromFenNotation(string[] splitFenString)
    => splitFenString[4];

  public static string GetFullmoveNumberNotation(string[] splitFenString)
    => splitFenString[5];

  public static bool IsCorrectBoardNotation(string boardString) {
    bool isCountCorrect = false;
    if (!string.IsNullOrEmpty(boardString)) {
      string[] splitBoardString = boardString.Split('/');
      bool correctLength = IsLengthOfBoardSide(splitBoardString.Length);
      bool onlyAllowedChars = AreOnlyAllowedChars(splitBoardString);

      if (correctLength && onlyAllowedChars)
        isCountCorrect = IsPartCountCorrect(splitBoardString);
    }

    return isCountCorrect;
  }

  private static bool IsPartCountCorrect(string[] splitBoardString) {
    bool isCountCorrect = true;

    for (var index = 0; isCountCorrect && index < splitBoardString.Length; index++) {
      string part = splitBoardString[index];
      int elementsCount = CountFenBoardPartElements(part);
      if (!IsLengthOfBoardSide(elementsCount)) isCountCorrect = false;
    }

    return isCountCorrect;
  }

  private static bool AreOnlyAllowedChars(string[] splitBoardString) {
    const string AllowedBoardChars = "rnbqkpRNBQKP123456789";
    return splitBoardString.All(part => { return part.All(element => AllowedBoardChars.Contains(element)); });
  }

  private static bool IsLengthOfBoardSide(int length) => length == RegularChessGlobals.BoardSide;

  public static int CountFenBoardPartElements(string part) {
    var intValues = from element in part
      select element - '0'
      into intElement
      select intElement is >= 0 and <= 9 ? intElement : 1;

    return intValues.Sum();
  }

  public static bool IsCorrectTurnNotation(string turnString) {
    string[] regularPossibleTurnStrings = { "w", "b" };
    return regularPossibleTurnStrings.Contains(turnString);
  }

  public static bool IsCorrectCastingAvailabilityNotation(string castingAvailableString) {
    bool correctCastingAvailabilityNotation = false;
    const string template = "KQkq";

    if (!string.IsNullOrEmpty(castingAvailableString) && castingAvailableString.Length == template.Length) {
      correctCastingAvailabilityNotation = true;
      for (int i = 0; i < template.Length; i++) {
        if (castingAvailableString[i] != template[i] && castingAvailableString[i] != '-')
          correctCastingAvailabilityNotation = false;
      }
    }

    return correctCastingAvailabilityNotation;
  }

  public static bool IsCorrectEnPassantNotation(string enPassantString) {
    const string allowedRows = "36";
    bool correctEnPassantNotation = !string.IsNullOrEmpty(enPassantString) &&
                                    (enPassantString == "-" ||
                                     enPassantString.Length == 2 &&
                                     enPassantString[0] >= 'a' &&
                                     enPassantString[0] <= 'a' + RegularChessGlobals.BoardSide &&
                                     allowedRows.Contains(enPassantString[1]));

    return correctEnPassantNotation;
  }

  public static bool IsCorrectHalfmoveClockNotation(string halfmoveClock)
    => int.TryParse(halfmoveClock, out int value) && value is <= 50 and >= 0;

  public static bool IsCorrectFullmoveNumberNotation(string fullMoveNumberString)
    => uint.TryParse(fullMoveNumberString, out uint _);
}