namespace tunelint.model {
  internal class Pitch :
        IComparable<Pitch>,
        IEquatable<Pitch> {
    private readonly int _value;

    public Pitch(int value) =>
        _value = value;

    public int CompareTo(Pitch? other) =>
        throw new NotImplementedException();

    public override bool Equals(object? o) =>
        throw new NotImplementedException();

    public bool Equals(Pitch? other) =>
        throw new NotImplementedException();

    public override int GetHashCode() =>
        throw new NotImplementedException();

    public static Interval operator -(Pitch left, Pitch right) =>
        throw new NotImplementedException();

    public static Pitch operator +(Pitch left, Interval right) =>
        throw new NotImplementedException();

    public static bool operator >(Pitch left, Pitch right) =>
        throw new NotImplementedException();

    public static bool operator <(Pitch left, Pitch right) =>
        throw new NotImplementedException();

    public static bool operator >=(Pitch left, Pitch right) =>
        throw new NotImplementedException();

    public static bool operator <=(Pitch left, Pitch right) =>
        throw new NotImplementedException();

    public static bool operator ==(Pitch left, Pitch right) =>
        throw new NotImplementedException();

    public static bool operator !=(Pitch left, Pitch right) =>
        throw new NotImplementedException();
  }
}
