using YaChess.ConApp.Classes;

namespace YaChess.ConApp.Interfaces; 

public interface IFenProtocol {
  IFilledBoard FilledBoard { get; }
  CastingAvailability CastingAvailability { get; }
  string EnPassantField { get; }
  int HalfmoveClock { get; }
  int FullmoveNumber { get; }
}