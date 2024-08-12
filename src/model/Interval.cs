namespace tunelint.model {
  internal class Interval :
        IComparable<Interval>,
        IEquatable<Interval> {
    private readonly int _value;

    public Interval(int value) =>
        _value = value;

    public Interval Absolute() =>
        throw new NotImplementedException();

    public int CompareTo(Interval? other) =>
        throw new NotImplementedException();

    public override bool Equals(object? obj) =>
        throw new NotImplementedException();

    public bool Equals(Interval? other) =>
        throw new NotImplementedException();

    public override int GetHashCode() =>
        throw new NotImplementedException();

    public static bool operator >(Interval left, Interval right) =>
        throw new NotImplementedException();

    public static bool operator <(Interval left, Interval right) =>
        throw new NotImplementedException();

    public static bool operator >=(Interval left, Interval right) =>
        throw new NotImplementedException();

    public static bool operator <=(Interval left, Interval right) =>
        throw new NotImplementedException();

    public static bool operator ==(Interval left, Interval right) =>
        throw new NotImplementedException();

    public static bool operator !=(Interval left, Interval right) =>
        throw new NotImplementedException();
  }
}
