using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunelint.model {
  internal sealed class NaturalNote {
    private readonly Pitch _pitch;

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
    }
  }
}
