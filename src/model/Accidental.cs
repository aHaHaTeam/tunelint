namespace tunelint.model {
  internal sealed class Accidental : IEquatable<Accidental> {
    private static readonly Dictionary<int, string> _accidentalSigns = new() {
      {-2, "bb" },
      {-1, "b" },
      {0, "n" },
      {1, "#" },
      {2, "##" }
    };

    private readonly Interval _offset;
    private readonly string _toString;

    public Interval Offset => _offset;

    private Accidental(int offset) {
      _offset = new Interval(offset);
      _toString = _accidentalSigns[offset];
    }

    public static Accidental DoubleSharp() => new(2);
    public static Accidental Sharp() => new(1);
    public static Accidental Natural() => new(0);
    public static Accidental Flat() => new(-1);
    public static Accidental DoubleFlat() => new(-2);

    public bool Equals(Accidental? other) =>
      _offset.Equals(other?._offset);
    public override bool Equals(object? obj) {
      if (obj is not Accidental) return false;
      
      return Equals((Accidental)obj);
    }
    public override string ToString()
      => _toString;

  }
}
