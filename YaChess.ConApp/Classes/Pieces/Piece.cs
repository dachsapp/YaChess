namespace YaChess.ConApp.Classes.Pieces;

public abstract class RegularPiece : IPiece {
  public Position Position { get; set; }

  protected RegularPiece(int x, int y) => Position = new Position(x, y);

  public override string ToString() => $"{GetType()} {Position.X}:{Position.Y} ";

  public override bool Equals(object? obj)
    => obj is RegularPiece otherPiece && Equals(otherPiece);


  private bool Equals(RegularPiece other)
    => GetType() == other.GetType() && Position == other.Position;

  public override int GetHashCode() => Position.GetHashCode();
}