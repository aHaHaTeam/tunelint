namespace tunelint.model {
  internal sealed class MusicalTime : IEquatable<MusicalTime> {
    private readonly int _upperNumber;
    private readonly int _lowerNumber;
    private readonly Duration _duration;
    private readonly string _toString;

    public int UpperNumber => _upperNumber;
    public int LowerNumber => _lowerNumber;
    public Duration Duration => _duration;

    public MusicalTime(int amount, int valuePower) {
      ArgumentOutOfRangeException.ThrowIfLessThan(amount, 1);
      ArgumentOutOfRangeException.ThrowIfLessThan(valuePower, 0);
      ArgumentOutOfRangeException.ThrowIfGreaterThan(valuePower, 8);

      _upperNumber = amount;
      _lowerNumber = 1 << valuePower;
      _duration = new(amount * (1 << (8 - valuePower)));
      _toString = $"{_upperNumber}|{_lowerNumber}";
    }

    public override string ToString() 
      => _toString;
    public bool Equals(MusicalTime? other) =>
      _upperNumber.Equals(other?._upperNumber) &&
      _lowerNumber.Equals(other?._lowerNumber);
  }
}
