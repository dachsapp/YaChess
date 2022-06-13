using YaChess.ConApp.Classes;
using YaChess.ConApp.Interfaces;

namespace YaChess.Filer; 

public static class RegularLoader {

  public static RegularFenProtocol GetRegularFenProfile(string fenString) {
    IFilledBoard filledBoard = GetRegularFilledBoard(fenString);
    
    IBoard board = new RegularBoard();
    List<IPiece> whitePiecesList = new();
    List<IPiece> blackPiecesList = new();
    throw new NotImplementedException();
  }
  
  private static RegularFilledBoard GetRegularFilledBoard(string fenString) {
    IBoard board = new RegularBoard();
    
    throw new NotImplementedException();
  }

}