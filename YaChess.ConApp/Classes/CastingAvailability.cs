namespace YaChess.ConApp.Classes;

public class CastingAvailability {
  public CastingAvailability() {}

  public CastingAvailability(bool whiteCastableKingSide, bool whiteCastableQueenSide,
    bool blackCastableKingSide, bool blackCastableQueenSide) {
    WhiteCastableKingSide = whiteCastableKingSide;
    WhiteCastableQueenSide = whiteCastableQueenSide;
    BlackCastableKingSide = blackCastableKingSide;
    BlackCastableQueenSide = blackCastableQueenSide;
  }
  
  public bool WhiteCastableKingSide { get; set; }
  public bool WhiteCastableQueenSide { get; set; }
  public bool BlackCastableKingSide { get; set; }
  public bool BlackCastableQueenSide { get; set; }

  public override string ToString() => $"{WhiteCastableKingSide}{WhiteCastableQueenSide}" +
                                       $"{BlackCastableKingSide}{BlackCastableQueenSide}";
}