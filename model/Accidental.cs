namespace tunelint.model {
  internal class Accidental {
    private readonly Interval _offset;
    public Interval Offset => _offset;

    private Accidental(int offset) {
      _offset = new Interval(offset);
    }

    public static Accidental DoubleSharp() => new(2);
    public static Accidental Sharp() => new(1);
    public static Accidental Natural() => new(0);
    public static Accidental Flat() => new(-1);
    public static Accidental DoubleFlat() => new(-2);
  }
}
