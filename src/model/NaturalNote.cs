using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunelint.model {
  internal sealed class NaturalNote {
    private static readonly Dictionary<int, string> _pitchLetters = new() {
      {0, " C" },
      {2,  "D" },
      {4,  "E" },
      {5,  "F" },
      {7,  "G" },
      {9,  "A" },
      {11, "B" }
    };

    private readonly Pitch _pitch;
    private readonly string _toString;

    public static NaturalNote C => new(0);
    public static NaturalNote D => new(2);
    public static NaturalNote E => new(4);
    public static NaturalNote F => new(5);
    public static NaturalNote G => new(7);
    public static NaturalNote A => new(9);
    public static NaturalNote B => new(11);
    public Pitch Pitch => _pitch;

    private NaturalNote(int pitch) {
      _pitch = new Pitch(pitch);
      _toString = _pitchLetters[pitch];
    }

    public override string ToString() 
      => _toString;
  }
}
