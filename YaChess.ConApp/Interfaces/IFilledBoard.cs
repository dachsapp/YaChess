namespace YaChess.ConApp.Interfaces; 

public interface IFilledBoard {
  IBoard Board { get; }
  IPiece[] BlackPieces { get; }
  IPiece[] WhitePieces { get; }
}
