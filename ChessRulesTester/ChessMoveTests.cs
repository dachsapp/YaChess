using YaChess.Rules;

namespace ChessRulesTester;

public class ChessMoveTests {
  [TestCase("a1")]
  [TestCase("b2")]
  [TestCase("c3")]
  [TestCase("d4")]
  [TestCase("e5")]
  [TestCase("f6")]
  [TestCase("g7")]
  [TestCase("h8")]
  public void IsSimpleBoardPosition_CorrectIn_TrueOut(string posString) {
    bool actual = RegularChess.IsSimpleBoardPosition(posString);
    Assert.That(actual, Is.True);
  }
  
  [TestCase("-")]
  [TestCase(null)]
  [TestCase("")]
  [TestCase("1a")]
  [TestCase("9a")]
  [TestCase("8i")]
  public void IsSimpleBoardPosition_IncorrectIn_FalseOut(string posString) {
    bool actual = RegularChess.IsSimpleBoardPosition(posString);
    Assert.That(actual, Is.False);
  }
}