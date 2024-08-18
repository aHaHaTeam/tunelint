using System.Text;

namespace tunelint.model {
  internal sealed class Note : IEquatable<Note> {
    private readonly NaturalOctavedNote? _baseNote;
    private readonly NoteValue _noteValue;
    private readonly Accidental? _accidental;
    public Accidental? Accidental => _accidental;
    public NaturalOctavedNote? BaseNote => _baseNote;
    public NoteValue NoteValue => _noteValue;
    public Duration Duration => _noteValue.Duration;

    public Note(
      NaturalOctavedNote? baseNote,
      NoteValue noteValue,
      Accidental? accidental = null) {
      _baseNote = baseNote;
      _noteValue = noteValue;
      _accidental = accidental;
    }

    public bool Equals(Note? other) {
      bool isEqual = _noteValue.Equals(other?.NoteValue);

      if (_accidental != null)
        isEqual = isEqual && _accidental.Equals(other?.Accidental);
      else
        isEqual = (other?.Accidental == null);

      if (_baseNote != null)
        isEqual = isEqual && _baseNote.Equals(other?.BaseNote);
      else
        isEqual = (other?.BaseNote == null);

      return isEqual;
    }

    public override string ToString() {
      StringBuilder builder = new();

      if (_baseNote == null)
        builder.Append("Pause");
      else
        builder.Append(_baseNote.ToString());

      if (_accidental != null)
        builder.Append(_accidental.ToString());

      builder.Append('(');
      builder.Append(_noteValue.ToString());
      builder.Append(')');

      return builder.ToString();
    }

  }
}
