using YaChess.ConApp.Classes;
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

  [TestCase(null)]
  [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPsPP/RNBQKBNR", "w", "KQkq", "-", "0", "0")]
  [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR")]
  [TestCase]
  public void GetPieces2DArray_IncorrectIn_ArgumentExceptionOut(params string[] fenNotation)
    => Assert.Throws<ArgumentException>(() => Loader.GetPieces2DArray(fenNotation));

  [Test]
  public void GetCastingAvailability_CorrectIn_CorrectOut() {
    string[] testString = {
      "8/8/8/8/8/8/8/8 w KQkq - 0 0",
      "8/8/8/8/8/8/8/8 w KQk- - 0 0",
      "8/8/8/8/8/8/8/8 w KQ-q - 0 0",
      "8/8/8/8/8/8/8/8 w KQ-- - 0 0",
      "8/8/8/8/8/8/8/8 w K-kq - 0 0",
      "8/8/8/8/8/8/8/8 w K-k- - 0 0",
      "8/8/8/8/8/8/8/8 w K--q - 0 0",
      "8/8/8/8/8/8/8/8 w K--- - 0 0",
      "8/8/8/8/8/8/8/8 w -Qkq - 0 0",
      "8/8/8/8/8/8/8/8 w -Qk- - 0 0",
      "8/8/8/8/8/8/8/8 w -Q-q - 0 0",
      "8/8/8/8/8/8/8/8 w -Q-- - 0 0",
      "8/8/8/8/8/8/8/8 w --kq - 0 0",
      "8/8/8/8/8/8/8/8 w --k- - 0 0",
      "8/8/8/8/8/8/8/8 w ---q - 0 0",
      "8/8/8/8/8/8/8/8 w ---- - 0 0",
    };

    CastingAvailability[] test2DArrays = {
      new(true, true, true, true),
      new(true, true, true, false),
      new(true, true, false, true),
      new(true, true, false, false),
      new(true, false, true, true),
      new(true, false, true, false),
      new(true, false, false, true),
      new(true, false, false, false),
      new(false, true, true, true),
      new(false, true, true, false),
      new(false, true, false, true),
      new(false, true, false, false),
      new(false, false, true, true),
      new(false, false, true, false),
      new(false, false, false, true),
      new(false, false, false, false),
    };

    for (var i = 0; i < test2DArrays.Length; i++) {
      string[] splitFenString = testString[i].Split(FenNotation.FenSeparator);

      CastingAvailability expected = test2DArrays[i];
      CastingAvailability actual = Loader.GetCastingAvailability(splitFenString);

      Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));
    }
  }

  [TestCase(null)]
  [TestCase]
  [TestCase(null, null, null)]
  [TestCase("8/8/8/8/8/8/8/8", "w", "KQkg", "-", "0", "0")]
  [TestCase("8/8/8/8/8/8/8/8", "w", "a-", "-", "-", "0", "0")]
  [TestCase("8/8/8/8", "w", "a-", "-", "-", "0", "0")]
  [TestCase("8/8/8/8", "w", "a-", "-", "-", "0", "0f")]
  public void GetCastingAvailability_IncorrectIn_ArgumentExceptionOut(params string[] splitFenString)
    => Assert.Throws<ArgumentException>(() => Loader.GetCastingAvailability(splitFenString));

  [TestCase("-")]
  [TestCase("e4")]
  public void GetEnPassantField_CorrectIn_CorrectOut(string enPassantString) {
    string[] splitFenNotation = { "8/8/8/8/8/8/8/8", "w", "KQkq", enPassantString, "0", "0" };
    string actual = Loader.GetEnPassantField(splitFenNotation);
    Assert.That(actual, Is.EqualTo(enPassantString));
  }
}
