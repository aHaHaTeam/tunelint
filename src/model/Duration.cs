namespace tunelint.model {
  internal class Duration :
      IComparable<Duration>,
      IEquatable<Duration> {
    private readonly int _value; // in 256-th parts of the whole note

    public Duration(int value) =>
        _value = value;

    public int CompareTo(Duration? other) =>
        throw new NotImplementedException();

    public override bool Equals(object? obj) =>
        throw new NotImplementedException();

    public bool Equals(Duration? other) =>
        throw new NotImplementedException();

    public override int GetHashCode() =>
        throw new NotImplementedException();

    public static Duration operator +(Duration left, Duration right) =>
        throw new NotImplementedException();

    public static bool operator <(Duration left, Duration right) =>
        throw new NotImplementedException();

    public static bool operator >(Duration left, Duration right) =>
        throw new NotImplementedException();

    public static bool operator <=(Duration left, Duration right) =>
        throw new NotImplementedException();

    public static bool operator >=(Duration left, Duration right) =>
        throw new NotImplementedException();

    public static bool operator ==(Duration left, Duration right) =>
        throw new NotImplementedException();

    public static bool operator !=(Duration left, Duration right) =>
        throw new NotImplementedException();
  }
}
