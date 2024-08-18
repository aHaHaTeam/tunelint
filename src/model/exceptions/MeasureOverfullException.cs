using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunelint.model.exceptions {
  internal class MeasureOverfullException : Exception {
    public MeasureOverfullException() : base() { }

    public MeasureOverfullException(string message) : base(message) { }

    public MeasureOverfullException(Duration durationLeft, Note note) :
      base($"Note {note} doesn't fit in measure with {durationLeft} duration left") { }

    public MeasureOverfullException(Duration durationLeft, IEnumerable<Note> notes) :
      base($"Note {notes} doesn't fit in measure with {durationLeft} duration left") { }
  }
}
