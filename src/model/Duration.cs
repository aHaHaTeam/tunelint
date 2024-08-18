namespace tunelint.model {
  internal sealed class Duration :
      IComparable<Duration>,
      IEquatable<Duration> {
    private readonly int _value; // in 256-th parts of the whole note

    public int Value => _value;

    public Duration(int value) =>
        _value = value;
    public Duration(Duration other) :
      this(other._value) { }

    public int CompareTo(Duration? other) =>
        _value.CompareTo(other?._value);

    public override bool Equals(object? obj) {
      if (obj is not Duration) return false;
      return Equals((Duration)obj);
    }

    public bool Equals(Duration? other) =>
        CompareTo(other) == 0;

    public override int GetHashCode() =>
        _value.GetHashCode();

    public override string ToString() =>
      _value.ToString();

    public static Duration operator +(Duration left, Duration right) =>
        new(left._value + right._value);

    public static Duration operator -(Duration left, Duration right) =>
      new(left._value - right._value);

    public static bool operator <(Duration left, Duration right) =>
        left.CompareTo(right) < 0;

    public static bool operator >(Duration left, Duration right) =>
        left.CompareTo(right) > 0;

    public static bool operator <=(Duration left, Duration right) =>
        left.CompareTo(right) <= 0;
    
    public static bool operator >=(Duration left, Duration right) =>
        left.CompareTo(right) >= 0;

    public static bool operator ==(Duration left, Duration right) =>
        left.CompareTo(right) == 0;

    public static bool operator !=(Duration left, Duration right) =>
        left.CompareTo(right) != 0;
  }
}
