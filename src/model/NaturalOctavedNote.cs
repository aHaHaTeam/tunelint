namespace tunelint.model {
  internal sealed class NaturalOctavedNote : IEquatable<NaturalOctavedNote> {
    private readonly NaturalNote _naturalNote;
    private readonly Octave _octave;

    public NaturalNote NaturalNote => _naturalNote;
    public Octave Octave => _octave;
    public Pitch Pitch => _naturalNote.Pitch + _octave.Offset;
    
    public NaturalOctavedNote(NaturalNote naturalNote,
      Octave octave) {
      _naturalNote = naturalNote;
      _octave = octave;
    }

    public NaturalOctavedNote(NaturalNote naturalNote)
      : this(naturalNote, Octave.FirstLineOctave) { }

    public bool Equals(NaturalOctavedNote? other)
      => Pitch.Equals(other?.Pitch);
    public override string ToString()
      => _naturalNote.ToString() + _octave.ToString();
  }
}
