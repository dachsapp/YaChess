namespace YaChess.ConApp.Classes; 

public class RegularGameEngine : IGameEngine {
  private IBoard _board = new RegularBoard();
  private IPiece[] _whitePieces;
  private IPiece[] _blackPieces;
  
  public IFilledBoard GetFilledBoard() {
    throw new NotImplementedException();
  }
}