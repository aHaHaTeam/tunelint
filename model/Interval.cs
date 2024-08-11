namespace tunelint.model {
  internal class Interval :
        IComparable<Interval>,
        IEquatable<Interval> {
    private readonly int _value;

    public Interval(int value) =>
        _value = value;

    public Interval Absolute() =>
        new(Math.Abs(_value));

    public int CompareTo(Interval? other) =>
        _value.CompareTo(other?._value);

    public override bool Equals(object? obj) {
      if (obj is not Interval) return false;
      return Equals((Interval)obj);
    }

    public bool Equals(Interval? other) =>
        CompareTo(other) == 0;

    public override int GetHashCode() =>
        _value.GetHashCode();

    public static bool operator >(Interval left, Interval right) =>
        left.CompareTo(right) > 0;

    public static bool operator <(Interval left, Interval right) =>
        left.CompareTo(right) < 0;

    public static bool operator >=(Interval left, Interval right) =>
        left.CompareTo(right) >= 0;

    public static bool operator <=(Interval left, Interval right) =>
        left.CompareTo(right) <= 0;

    public static bool operator ==(Interval left, Interval right) =>
        left.CompareTo(right) == 0;

    public static bool operator !=(Interval left, Interval right) =>
        left.CompareTo(right) != 0;
  }
}
