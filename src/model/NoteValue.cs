using System.Diagnostics;
using tunelint.model.exceptions;

namespace tunelint.model {
  internal sealed class NoteValue : IEquatable<NoteValue> {
    private readonly Duration _duration;
    private readonly int _power;
    private readonly int _augmentations;

    public Duration Duration => _duration;

    public NoteValue(int power, int augmentations = 0) {
      if (augmentations < 0) 
        throw new ArgumentOutOfRangeException(
          $"{nameof(augmentations)} should be non negative integer");

      if (power < augmentations) throw new TooMuchAugmentationsException(power, augmentations);

      _power = power;
      int duration_value = 1 << power;
      _augmentations = augmentations;

      while (augmentations > 0) {
        --power;
        --augmentations;
        duration_value += (1 << power);
      }

      _duration = new(duration_value);
    }

    public override string ToString() {
      string power_signature = _power switch {
        < 4 => $"{1 << (8 - _power)}",
        4 => "S",
        5 => "E",
        6 => "Q",
        7 => "H",
        8 => "W",
        9 => "D",
        10 => "DD",
        11 => "DDD",
        _ => throw new UnreachableException()
      };
      return power_signature + (
        _augmentations > 0   ? 
        $"+{_augmentations}" :
        "");
    }

    public NoteValue WithAugmentations(int augmentations) =>
      new(_power, augmentations);


    public static NoteValue OctupleWhole => new(11);
    public static NoteValue QuadrupleWhole => new(10);
    public static NoteValue DoubleWhole => new(9);
    public static NoteValue Whole => new(8);
    public static NoteValue Half => new(7);
    public static NoteValue Quater => new(6);
    public static NoteValue Eighth => new(5);
    public static NoteValue Sixteenth => new(4);
    public static NoteValue ThirtySecond => new(3);
    public static NoteValue SixtyFourth => new(2);
    public static NoteValue HundredTwentyEighth => new(1);
    public static NoteValue TwoHundredFiftySixth => new(0);

    public bool Equals(NoteValue? other)
      => Duration.Equals(other?.Duration);

  }
}
