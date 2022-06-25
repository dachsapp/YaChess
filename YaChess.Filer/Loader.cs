using YaChess.ConApp.Classes;
using YaChess.ConApp.Classes.Pieces;
using YaChess.ConApp.Interfaces;
using YaChess.Rules;

namespace YaChess.Filer;

public static class Loader {
  private const string FenFile = "current_profile.fen";

  public static IFenProtocol LoadCurrentFenProtocol() {
    string fenNotation = new FileManipulator(FenFile).Read();
    IFenProtocol fenProtocol;

    if (FenNotation.IsNotNullAndCorrectFenNotation(fenNotation)) {
      string[] splitFenNotation = fenNotation.Split(FenNotation.FenSeparator);

      IPiece[][] pieces = GetPieces2DArray(splitFenNotation);
      
      fenProtocol = new RegularFenProtocol(
        new RegularFilledBoard(new RegularBoard(), pieces[0], pieces[1]),
        GetCastingAvailability(splitFenNotation),
        GetEnPassantField(splitFenNotation),
        GetHalfmoveClock(splitFenNotation),
        GetFullmoveNumber(splitFenNotation)
      );
    }
    else throw new ArgumentException($"PROVIDED FEN NOTATION INCORRECT!!\n: {fenNotation}");

    return fenProtocol;
  }

  public static int GetFullmoveNumber(string[] splitFenNotation) {
    ArgumentException argumentException = new ArgumentException("FEN NOTATION WAS NOT CORRECT!");
    if (!FenNotation.IsNotNullAndCorrectFenNotation(string.Join(FenNotation.FenSeparator, splitFenNotation)))
      throw argumentException;

    string FullmoveNumber = FenNotation.GetFullmoveNumberNotation(splitFenNotation);

    if (!int.TryParse(FullmoveNumber, out int fullMoveNumber)) throw argumentException;

    return fullMoveNumber;
  }

  public static int GetHalfmoveClock(string[] splitFenNotation) {
    ArgumentException argumentException = new ArgumentException("FEN NOTATION WAS NOT CORRECT!");
    if (!FenNotation.IsNotNullAndCorrectFenNotation(string.Join(FenNotation.FenSeparator, splitFenNotation)))
      throw argumentException;

    string halfMoveString = FenNotation.GetHalfmoveClockStringFromFenNotation(splitFenNotation);

    if (!int.TryParse(halfMoveString, out int halfMove)) throw argumentException;

    return halfMove;
  }

  public static string GetEnPassantField(string[] splitFenNotation) {
    string enPassantString = FenNotation.GetEnPassentStringFromFenNotation(splitFenNotation);

    bool isSimpleBoardPosition = RegularChess.IsSimpleBoardPosition(enPassantString);
    bool isEnPassantField = !(isSimpleBoardPosition && 
                              RegularChess.PossibleEnPassantNumbers.Contains(enPassantString[1]));
    
    if (isEnPassantField && enPassantString != "-")
      throw new ArgumentException("FEN NOTATION WAS NOT CORRECT!");

    return enPassantString;
  }

  public static IPiece[][] GetPieces2DArray(string[] splitFenNotation) {
    if (!FenNotation.IsNotNullAndCorrectFenNotation(string.Join(FenNotation.FenSeparator, splitFenNotation)))
      throw new ArgumentException("FEN NOTATION WAS NOT CORRECT!");

    List<IPiece> whitePieces = new();
    List<IPiece> blackPieces = new();

    string boardString = FenNotation.GetBoardStringFromFenNotation(splitFenNotation);
    string[] splitBoardString = boardString.Split(FenNotation.BoardSeparator);

    for (int row = 0; row < splitBoardString.Length; row++)
      SetPiecesRow(whitePieces, blackPieces, row, splitBoardString);

    return new[] { whitePieces.ToArray(), blackPieces.ToArray() };
  }

  public static CastingAvailability GetCastingAvailability(string[] splitFenNotation) {
    string fenString = string.Join(FenNotation.FenSeparator, splitFenNotation);
    if (!FenNotation.IsNotNullAndCorrectFenNotation(fenString))
      throw new ArgumentException("Incorrect splitFenNotation");

    CastingAvailability castingAvailability = new();
    string strCastingAvailability = FenNotation.GetCastingAvailabilityStringFromFenNotation(splitFenNotation);

    if (FenNotation.IsCorrectCastingAvailabilityNotation(strCastingAvailability)) {
      castingAvailability.WhiteCastableKingSide = strCastingAvailability[0] == 'K';
      castingAvailability.WhiteCastableQueenSide = strCastingAvailability[1] == 'Q';
      castingAvailability.BlackCastableKingSide = strCastingAvailability[2] == 'k';
      castingAvailability.BlackCastableQueenSide = strCastingAvailability[3] == 'q';
    }

    return castingAvailability;
  }

  private static void SetPiecesRow(List<IPiece> whitePieces, List<IPiece> blackPieces, int row, string[] splitBoard) {
    int pieceCol = 0;

    foreach (char element in splitBoard[row]) {
      const int startPos = 1;
      int intChar = element - '0';
      int adder = intChar is >= startPos and <= RegularChess.BoardSide ? intChar : 1;

      if (IsWhiteChessPiece(element))
        whitePieces.Add(GetChessPiece(element, row, pieceCol));
      if (IsBlackChessPiece(element))
        blackPieces.Add(GetChessPiece(element, row, pieceCol));

      pieceCol += adder;
    }
  }

  private static IPiece GetChessPiece(char chr, int row, int col) {
    return char.ToUpper(chr) switch {
      'R' => new Rook(row, col),
      'N' => new Knight(row, col),
      'B' => new Bishop(row, col),
      'Q' => new Queen(row, col),
      'K' => new King(row, col),
      _ => new Pawn(row, col)
    };
  }

  private static bool IsWhiteChessPiece(char chr) {
    const string whitePiecesChars = "RNBQKP";
    return whitePiecesChars.Contains(chr);
  }

  private static bool IsBlackChessPiece(char chr) {
    const string whitePiecesChars = "rnbqkp";
    return whitePiecesChars.Contains(chr);
  }
}