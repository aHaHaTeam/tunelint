using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunelint.model {
  internal class NaturalOctavedNote {
    private readonly NaturalNote _naturalNote;
    private readonly Octave _octave;

    public NaturalNote NaturalNote => _naturalNote;
    public Octave Octave => _octave;
    public Pitch Pitch => _naturalNote.Pitch + _octave.Offset;

    public NaturalOctavedNote(NaturalNote naturalNote, Octave octave) {
      _naturalNote = naturalNote;
      _octave = octave;
    }
  }
}
