namespace GameTester;

public class InitialBoardTests {
  [Test]
  public void InitialBoard_ChessStyle() {
    IBoard board = new RegularBoard();
    
    bool[,] expectedBoard = {
      { true, false, true, false, true, false, true, false },
      { false, true, false, true, false, true, false, true },
      { true, false, true, false, true, false, true, false },
      { false, true, false, true, false, true, false, true },
      { true, false, true, false, true, false, true, false },
      { false, true, false, true, false, true, false, true },
      { true, false, true, false, true, false, true, false },
      { false, true, false, true, false, true, false, true },
    };

    bool[,] actualBoard = board.Board;
    
    Assert.That(actualBoard, Is.EqualTo(expectedBoard));
  }
}