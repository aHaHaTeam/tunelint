namespace tunelint.model {
  internal sealed class Note {
    private readonly NaturalOctavedNote _baseNote;
    private readonly NoteValue _noteValue;
    private readonly Accidental? _accidental;
    public NaturalOctavedNote BaseNote => _baseNote;
    public NoteValue NoteValue => _noteValue;
    public Accidental? Accidental => _accidental;

    public Note(NaturalOctavedNote baseNote, NoteValue noteValue, Accidental? accidental = null) {
      _baseNote = baseNote;
      _noteValue = noteValue;
      _accidental = accidental;
    }
  }
}
