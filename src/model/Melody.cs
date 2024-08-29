namespace tunelint.model {
  internal sealed class Melody {
    private readonly MusicalTime _musicalTime;
    private readonly Clef _clef;
    private readonly List<Measure> _measures;
    
    public MusicalTime MusicalTime => _musicalTime;
    public Clef Clef => _clef;
    public List<Measure> Measures => _measures;

    public Melody(MusicalTime time, Clef clef) {
      _musicalTime = time;
      _clef = clef;
      _measures = [new(_musicalTime)];
    }

    public void AddMeasure()
      => _measures.Add(new(_musicalTime));
    public void RemoveMeasure()
      => _measures.RemoveAt(_measures.Count - 1);
  }
}
