namespace tunelint.model {
  public class Pitch :
        IComparable<Pitch>,
        IEquatable<Pitch> {
    private readonly int _value;

    public Pitch(int value) =>
        _value = value;

    public int CompareTo(Pitch? other) =>
      _value.CompareTo(other?._value);

    public override string ToString() =>
      $"Pitch {_value}";

    public override bool Equals(object? o) {
      if (o is not Pitch) return false;
      return Equals((Pitch)o);
    }

    public bool Equals(Pitch? other) =>
        CompareTo(other) == 0;

    public override int GetHashCode() =>
        _value.GetHashCode();

    public static Interval operator -(Pitch left, Pitch right) =>
        new(left._value - right._value);

    public static Pitch operator +(Pitch left, Interval right) =>
        new(left._value + right.Size);

    public static bool operator >(Pitch left, Pitch right) =>
        left.CompareTo(right) > 0;

    public static bool operator <(Pitch left, Pitch right) =>
        left.CompareTo(right) < 0;

    public static bool operator >=(Pitch left, Pitch right) =>
        left.CompareTo(right) >= 0;

    public static bool operator <=(Pitch left, Pitch right) =>
        left.CompareTo(right) <= 0;

    public static bool operator ==(Pitch left, Pitch right) =>
        left.CompareTo(right) == 0;

    public static bool operator !=(Pitch left, Pitch right) =>
        left.CompareTo(right) != 0;
  }
}
