namespace YaChess.ConApp.Classes; 

public class Position {
  public int X { get; set; }
  public int Y { get; set; }

  public Position(int x, int y) {
    X = x;
    Y = y;
  }

  public override bool Equals(object? other) {
    bool equals = false;
    if (other is Position otherPos)
      equals = Equals(otherPos);
    return equals;
  }

  private bool Equals(Position other) => X == other.X && Y == other.Y;
  

  public override int GetHashCode() {
    return HashCode.Combine(X, Y);
  }

  public static bool operator ==(Position a, Position b) => a.Equals(b);
  public static bool operator !=(Position a, Position b) => !a.Equals(b);
}