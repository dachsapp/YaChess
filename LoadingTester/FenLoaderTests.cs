using YaChess.ConApp.Classes.Pieces;
using YaChess.ConApp.Interfaces;
using YaChess.Filer;
using YaChess.Rules;

namespace LoadingTester;

public class FenLoaderTests {
  [Test]
  public void GetPieces2DArray_EmptyFenBoardIn_NoPiecesOut() {
    string[] splitFen = { "8/8/8/8/8/8/8/8", "w", "----", "-", "0", "0" };

    IPiece[][] expected = { Array.Empty<IPiece>(), Array.Empty<IPiece>() };
    IPiece[][] actual = Loader.GetPieces2DArray(splitFen);

    Assert.That(actual, Is.EqualTo(expected));
  }

  [Test]
  public void GetPieces2DArray_NullIn_NoPiecesOut() {
    IPiece[][] expected = { Array.Empty<IPiece>(), Array.Empty<IPiece>() };
    IPiece[][] actual = Loader.GetPieces2DArray(null!);

    Assert.That(actual, Is.EqualTo(expected));
  }

  [Test]
  public void GetPieces2DArray_CorrectIn_Correct2DArrayOut() {
    string[] testString = {
      "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 0",
      "8/1p6/p6k/7P/P6K/8/8/8 w ---- - 1 82"
    };

    IPiece[][][] test2DArrays = {
      new[] {
        new IPiece[] {
          new Pawn(6, 0),
          new Pawn(6, 1),
          new Pawn(6, 2),
          new Pawn(6, 3),
          new Pawn(6, 4),
          new Pawn(6, 5),
          new Pawn(6, 6),
          new Pawn(6, 7),
          
          new Rook(7, 0),
          new Knight(7, 1),
          new Bishop(7, 2),
          new Queen(7, 3),
          new King(7, 4),
          new Bishop(7, 5),
          new Knight(7, 6),
          new Rook(7, 7)
        },
        new IPiece[] {
          new Rook(0, 0),
          new Knight(0, 1),
          new Bishop(0, 2),
          new Queen(0, 3),
          new King(0, 4),
          new Bishop(0, 5),
          new Knight(0, 6),
          new Rook(0, 7),

          new Pawn(1, 0),
          new Pawn(1, 1),
          new Pawn(1, 2),
          new Pawn(1, 3),
          new Pawn(1, 4),
          new Pawn(1, 5),
          new Pawn(1, 6),
          new Pawn(1, 7),
        }
      },
      new[] {
        new IPiece[] {
          new Pawn(3, 7),
          new Pawn(4, 0),
          new King(4, 7)
        },
        new IPiece[] {
          new Pawn(1, 1),
          new Pawn(2, 0),
          new King(2, 7)
        }
      }
    };

    for (var i = 0; i < test2DArrays.Length; i++) {
      IPiece[][] expected = test2DArrays[i];
      IPiece[][] actual = Loader.GetPieces2DArray(testString[i].Split(FenNotation.FenSeparator));

      Assert.That(actual, Is.EqualTo(expected));
    }
  }
  
  [Test]
  public void GetPieces2DArray_IncorrectIn_ArgumentExceptionOut() {
    // string[] testString = {
    //   "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 0",
    // };
    //
    // IPiece[][][] test2DArrays = {
    //   new[] {
    //     new IPiece[] {
    //       new Rook(7, 7)
    //     },
    //     new IPiece[] {
    //       new Rook(0, 0),
    //       new Pawn(1, 7),
    //     }
    //   }
    // };
    //
    // for (var i = 0; i < test2DArrays.Length; i++) {
    //   IPiece[][] expected = test2DArrays[i];
    //   IPiece[][] actual = Loader.GetPieces2DArray(testString[i].Split(FenNotation.fenSeparator));
    //
    //   Assert.That(actual, Is.EqualTo(expected));
    // }
  }
}