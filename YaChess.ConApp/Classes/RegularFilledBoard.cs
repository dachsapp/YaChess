using YaChess.ConApp.Classes.Pieces;

namespace YaChess.ConApp.Classes;

public class RegularFilledBoard : IFilledBoard {
  public IBoard Board { get; }
  public IPiece[] BlackPieces { get; }
  public IPiece[] WhitePieces { get; }

  public RegularFilledBoard(RegularBoard board, IPiece[] whitePieces, IPiece[] blackPieces) {
    Board = board;
    BlackPieces = blackPieces;
    WhitePieces = whitePieces;
  }
}