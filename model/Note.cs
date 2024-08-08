namespace tunelint.model {
  internal class Note {
    private readonly Pitch _basePitch;
    private readonly Duration _baseDuration;
    private readonly Accidental? _accidental;
    public Pitch BasePitch => _basePitch;
    public Duration BaseDuration => _baseDuration;
    public Accidental? Accidental => _accidental;

    public Note(Pitch pitch, Duration duration, Accidental? accidental = null) {
      _basePitch = pitch;
      _baseDuration = duration;
      _accidental = accidental;
    }

    public Note WithAccidental(Accidental? accidental) {
      return new Note(BasePitch, BaseDuration, accidental);
    }
  }
}
