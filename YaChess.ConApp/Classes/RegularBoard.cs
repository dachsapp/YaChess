namespace YaChess.ConApp.Classes;

public class RegularBoard : IBoard {
  private const int BoardSide = 8;
  public bool[,] Board { get; } = new bool[BoardSide, BoardSide];

  public RegularBoard() {
    SetUpBoard();
  }

  private void SetUpBoard() {
    for (int row = 0; row < Board.GetLength(0); row++)
    for (int col = 0; col < Board.GetLength(1); col++) {
      Board[row, col] = row % 2 == col % 2;
    }
  }
}