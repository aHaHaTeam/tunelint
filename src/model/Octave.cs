namespace tunelint.model {
  internal sealed class Octave {
    private readonly int _number;

    public static Octave SubContraOctave => new(-4);
    public static Octave ContraOctave => new(-3);
    public static Octave GreatOctave => new(-2);
    public static Octave SmallOctave => new(-1);
    public static Octave FirstLineOctave => new(0);
    public static Octave SecondLineOctave => new(1);
    public static Octave ThirdLineOctave => new(2);
    public static Octave FourthLineOctave => new(3);
    public Interval Offset => Interval.Octave * _number;

    public override string ToString()
      => (_number - SubContraOctave._number).ToString();

    private Octave(int number) {
      _number = number;
    }
  }
}
