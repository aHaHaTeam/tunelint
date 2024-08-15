using System.Text;

namespace tunelint.model {
  internal sealed class Interval :
        IComparable<Interval>,
        IEquatable<Interval> {
    private readonly int _value;
    private const int _octaveSize = 12;

    public int Size => _value;
    public Interval(int value) =>
        _value = value;

    public Interval Absolute() =>
        new(Math.Abs(_value));

    public int CompareTo(Interval? other) =>
        _value.CompareTo(other?._value);

    public override string ToString() {
      if (_value < 0)
        return $"-{Absolute()}";

      int octaves = _value / Octave.Size;
      int remainder = _value % Octave.Size;

      string octavesAmount = octaves > 0 ? $"{octaves}O+" : "";

      if (remainder == 0)
        return octavesAmount + "P1";
      if (remainder < 5)
        return octavesAmount +
          (remainder % 2 == 0 ? "M" : "m") +
          $"{(remainder + 1) / 2 + 1}";
      if (remainder == 5)
        return octavesAmount + "P4";
      if (remainder == 6)
        return octavesAmount + "TT";
      if (remainder == 7)
        return octavesAmount + "P5";
      return octavesAmount +
          (remainder % 2 == 1 ? "M" : "m") +
          $"{remainder / 2 + 2}";
    }

    public override bool Equals(object? obj) {
      if (obj is not Interval) return false;
      return Equals((Interval)obj);
    }

    public bool Equals(Interval? other) =>
        CompareTo(other) == 0;

    public override int GetHashCode() =>
        _value.GetHashCode();

    public static Interval operator* (Interval left, int right) =>
      new(left.Size * right);

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

    public static Interval Octave => new(_octaveSize);
  }
}
