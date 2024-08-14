namespace tunelint.model {
  internal class Note {
    private readonly NaturalOctavedNote _baseNote;
    private readonly Duration _baseDuration;
    private readonly Accidental? _accidental;
    public NaturalOctavedNote BaseNote => _baseNote;
    public Duration BaseDuration => _baseDuration;
    public Accidental? Accidental => _accidental;

    public Note(NaturalOctavedNote baseNote, Duration duration, Accidental? accidental = null) {
      _baseNote = baseNote;
      _baseDuration = duration;
      _accidental = accidental;
    }
  }
}
