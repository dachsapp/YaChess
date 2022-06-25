using YaChess.Rules;

namespace FenNotationTester;

public class FenStringToFenProtocolTester {
  
  
  [TestCase("8/8/8/8/8/8/8/8 w ---- - 50 0")]
  [TestCase("8/8/8/5P2/8/8/8/8 b K--q f3 35 110")]
  [TestCase("rkbqkbkr/pppppppp/8/8/8/8/PPPPPPPP/RKBQKBKR w KQkq - 0 0")]
  public void IsCorrectFenNotation_CorrectIn_TrueOut(string fenNotationString) {
    bool actualValue = FenNotation.IsNotNullAndCorrectFenNotation(fenNotationString);
    Assert.That(actualValue, Is.True);
  }
  
  [TestCase(null)]
  [TestCase("")]
  [TestCase("8/8/8/8/8/8/8/8 w ---- - 51 0")]
  [TestCase("8/8/8/8/8/8/8/8 w ---- - 51 0 ")]
  [TestCase("8/8/8/8/8/8/\n8/8 w ---- - 50 0")]
  [TestCase("8//8/8/8/8/8/8 w ---- - 50 0")]
  [TestCase("8lasaldkf alsd;jf l;sdk")]
  [TestCase("8lasaldkf alsd;jf l;ö")]
  [TestCase("8//8/8/8/8/8/8 w ---- - 50 0\nasdf")]
  public void IsCorrectFenNotation_IncorrectIn_FalseOut(string fenNotationString) {
    bool actualValue = FenNotation.IsNotNullAndCorrectFenNotation(fenNotationString);
    Assert.That(actualValue, Is.False);
  }

  [TestCase("rnbqkbnr", 8)]
  [TestCase("RNBQKBNR", 8)]
  [TestCase("RNbQKbNR", 8)]
  [TestCase("pppppppp", 8)]
  [TestCase("PPPPPPPP", 8)]
  [TestCase("4P3", 8)]
  [TestCase("1nPqq2n", 8)]
  [TestCase("8", 8)]
  [TestCase("1P", 2)]
  [TestCase("PPPPPPPPP9", 18)]
  [TestCase("3P6", 10)]
  public void BartElementsCounter_CountingCorrectly(string boardPart, int expectedValue) {
    int actualValue = FenNotation.CountFenBoardPartElements(boardPart);

    Assert.That(actualValue, Is.EqualTo(expectedValue));
  }

  [TestCase("rnbqkbnr/pppppppp/8/8/8/8/pppppppp/RNBQKBNR")]
  [TestCase("rnbqkbnr/pppppppp/8/8/3P4/8/pppppppp/RNBQKBNR")]
  [TestCase("rnbqkbnB/pppppppp/8/8/3P4/8/ppQppPpp/RNBQKBNR")]
  public void IsCorrectBoardNotation_CorrectIn_TrueOut(string boardString) {
    bool actualValue = FenNotation.IsCorrectBoardNotation(boardString);
    Assert.That(actualValue, Is.True);
  }

  [TestCase(null)]
  [TestCase("")]
  [TestCase("rnbqkbnr/pppppppp/8/8/8/8/pppppppp")]
  [TestCase("rnbqkbnr/pppppppp/8/8/3P4/8/ppPpppppp/RNBQKBNR")]
  [TestCase("rnbqkbnB/pppppppp/8/8/3P6/8/ppQppPpp/RNBQKBNR")]
  [TestCase("rnbqkbnB/pppppppp/8/8/3P6/8/ppQppPpp/RNBQKBNR/8")]
  [TestCase("rnbqkJnr/pppppppp/8/8/8/8/pppppppp/RNBQKBNR")]
  public void IsCorrectBoardNotation_IncorrectIn_FalseOut(string boardString) {
    bool actualValue = FenNotation.IsCorrectBoardNotation(boardString);
    Assert.That(actualValue, Is.False);
  }

  [TestCase("w")]
  [TestCase("b")]
  public void IsCorrectTurnNotation_CorrectIn_TrueOut(string turnString) {
    bool actualValue = FenNotation.IsCorrectTurnNotation(turnString);
    Assert.That(actualValue, Is.True);
  }

  [TestCase(null)]
  [TestCase("")]
  [TestCase("a")]
  [TestCase("wb")]
  [TestCase("132")]
  public void IsCorrectTurnNotation_IncorrectIn_FalseOut(string turnString) {
    bool actualValue = FenNotation.IsCorrectTurnNotation(turnString);
    Assert.That(actualValue, Is.False);
  }

  [TestCase("KQkq")]
  [TestCase("-Qkq")]
  [TestCase("K-kq")]
  [TestCase("--kq")]
  [TestCase("KQ-q")]
  [TestCase("-Q-q")]
  [TestCase("K--q")]
  [TestCase("---q")]
  [TestCase("KQk-")]
  [TestCase("-Qk-")]
  [TestCase("K-k-")]
  [TestCase("--k-")]
  [TestCase("KQ--")]
  [TestCase("-Q--")]
  [TestCase("K---")]
  [TestCase("----")]
  public void IsCorrectCastingAvailabilityNotation_CorrectIn_TrueOut(string castingAvailabilityString) {
    bool actualValue = FenNotation.IsCorrectCastingAvailabilityNotation(castingAvailabilityString);
    Assert.That(actualValue, Is.True);
  }

  [TestCase(null)]
  [TestCase("")]
  [TestCase("KQkqK")]
  [TestCase("asdfasdf")]
  [TestCase("KQ")]
  [TestCase("as")]
  [TestCase("KQkj")]
  [TestCase("KQkj")]
  [TestCase("kqKQ")]
  public void IsCorrectCastingAvailabilityNotation_IncorrectIn_FalseOut(string castingAvailabilityString) {
    bool actualValue = FenNotation.IsCorrectCastingAvailabilityNotation(castingAvailabilityString);
    Assert.That(actualValue, Is.False);
  }

  [TestCase("-")]
  [TestCase("e3")]
  [TestCase("h6")]
  public void IsCorrectEnPassantNotation_CorrectIn_TrueOut(string enPassantString) {
    bool actualValue = FenNotation.IsCorrectEnPassantNotation(enPassantString);
    Assert.That(actualValue, Is.True);
  }
  
  [TestCase("")]
  [TestCase(null)]
  [TestCase("--")]
  [TestCase("e")]
  [TestCase("h426")]
  [TestCase("H4")]
  public void IsCorrectEnPassantNotation_IncorrectIn_FalseOut(string enPassantString) {
    bool actualValue = FenNotation.IsCorrectEnPassantNotation(enPassantString);
    Assert.That(actualValue, Is.False);
  }

  [TestCase("0")]
  [TestCase("5")]
  [TestCase("50")]
  [TestCase("13")]
  [TestCase("43")]
  public void IsCorrectHalfmoveClockNotation_CorrectIn_TrueOut(string halfmoveClockString) {
    bool actualValue = FenNotation.IsCorrectHalfmoveClockNotation(halfmoveClockString);
    Assert.That(actualValue, Is.True);
  }

  [TestCase(null)]
  [TestCase("")]
  [TestCase("-1")]
  [TestCase("-")]
  [TestCase("51")]
  [TestCase("234023")]
  [TestCase("23j")]
  [TestCase("j")]
  [TestCase("å")]
  public void IsCorrectHalfmoveClockNotation_IncorrectIn_FalseOut(string halfmoveClockString) {
    bool actualValue = FenNotation.IsCorrectHalfmoveClockNotation(halfmoveClockString);
    Assert.That(actualValue, Is.False);
  }

  [TestCase("0")]
  [TestCase("1")]
  [TestCase("2")]
  [TestCase("3")]
  [TestCase("10")]
  [TestCase("532")]
  [TestCase("5312394")]
  [TestCase("4000000000")]
  public void IsCorrectFullmoveNumberNotation_CorrectIn_TrueOut(string fullmoveNumber) {
    bool actualValue = FenNotation.IsCorrectFullmoveNumberNotation(fullmoveNumber);
    Assert.That(actualValue, Is.True);
  }

  [TestCase(null)]
  [TestCase("")]
  [TestCase("-2")]
  [TestCase("f")]
  [TestCase("asdfa")]
  [TestCase("2000f0≈000")]
  [TestCase("5000000000")]
  public void IsCorrectFullmoveNumberNotation_IncorrectIn_FalseOut(string fullmoveNumber) {
    bool actualValue = FenNotation.IsCorrectFullmoveNumberNotation(fullmoveNumber);
    Assert.That(actualValue, Is.False);
  }
}