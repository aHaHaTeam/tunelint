namespace tunelint.model {
  internal class ActualNote {
    private readonly int _index;
    private readonly Pitch _pitch;
    private readonly Duration _duration;

    public int Index => _index;
    public Pitch Pitch => _pitch;
    public Duration Duration => _duration;

    public ActualNote(int index, Note prototype, Accidental accidental) {
      _index = index;
      _pitch = prototype.BaseNote.Pitch + accidental.Offset;
      _duration = prototype.NoteValue.Duration;
    }
  }
}
