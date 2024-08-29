namespace tunelint.model {
  class Clef : IEquatable<Clef> {
    private readonly Pitch _firstLinePitch;
    public Pitch FirstLinePitch => _firstLinePitch;

    public Clef(Pitch firstLinePitch) {
      _firstLinePitch = firstLinePitch;
    }

    public static Clef Treble => new(new(2));
    public static Clef Alto => new(new(-4));
    public static Clef Bass => new(new(-15));

    public bool Equals(Clef? other)
      => _firstLinePitch.Equals(other?._firstLinePitch);
    public static bool operator ==(Clef left, Clef right)
      => left.Equals(right);
    public static bool operator !=(Clef left, Clef right)
      => !left.Equals(right);

    public override bool Equals(object? obj) {
      if (obj is not Clef) return false;

      return Equals(obj as Clef);
    }

    public override int GetHashCode() 
      => _firstLinePitch.GetHashCode();
  }
}
