namespace YaChess.ConApp.Classes;

public class RegularFenProtocol : IFenProtocol {
  public IFilledBoard FilledBoard { get; }
  public CastingAvailability CastingAvailability { get; }
  public string EnPassantField { get; }
  public int HalfmoveClock { get; }
  public int FullmoveNumber { get; }

  public RegularFenProtocol(
    RegularFilledBoard filledBoard,
    CastingAvailability castingAvailability,
    string enPassantField,
    int halfmoveClock,
    int fullmoveNumber
  ) {
    FilledBoard = filledBoard;
    CastingAvailability = castingAvailability;
    EnPassantField = enPassantField;
    HalfmoveClock = halfmoveClock;
    FullmoveNumber = fullmoveNumber;
  }
}