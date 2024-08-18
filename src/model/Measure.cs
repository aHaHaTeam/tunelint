using System.Collections;
using tunelint.model.exceptions;

namespace tunelint.model {
  internal sealed class Measure : IEnumerable<Note>, IEquatable<Measure> {
    private readonly MusicalTime _musicalTime;
    private readonly List<Note> _notes;
    private Duration _durationLeft;

    public Measure(MusicalTime musicalTime) {
      _musicalTime = musicalTime;
      _notes = [];
      _durationLeft = musicalTime.Duration;
    }
    public Measure(Measure other) :
      this(other._musicalTime) {

      foreach (Note note in other._notes)
        Add(note);
    }

    public void Add(Note note) {
      if (note.Duration > _durationLeft)
        throw new MeasureOverfullException(_durationLeft, note);

      _durationLeft -= note.Duration;
      _notes.Add(note);
    }
    public void AddRange(IEnumerable<Note> notes) {
      Duration totalDuration = new(0);

      foreach (Note note in notes)
        totalDuration += note.Duration;

      if (totalDuration > _durationLeft)
        throw new MeasureOverfullException(_durationLeft, notes);

      foreach (Note note in notes)
        Add(note);
    }
    public void Insert(int index, Note note) {
      ArgumentOutOfRangeException.ThrowIfLessThan(index, 0);

      if (note.Duration > _durationLeft)
        throw new MeasureOverfullException(_durationLeft, note);

      if (index <= _notes.Count) {
        _durationLeft -= note.Duration;
        _notes.Insert(index, note);
        return;
      }

      index -= _notes.Count;
      List<Note> finalPauses = FinalPauses();
      ArgumentOutOfRangeException.ThrowIfGreaterThan(index, finalPauses.Count);

      Duration pausesDuration = new(0);

      foreach (Note pause in finalPauses.Take(index))
        pausesDuration += pause.Duration;

      if (pausesDuration + note.Duration > _durationLeft)
        throw new MeasureOverfullException(_durationLeft - pausesDuration, note);

      AddRange(finalPauses.Take(index));
      Add(note);
    }
    public void RemoveAt(int index) {
      try {
        Note note = _notes[index];
        _notes.RemoveAt(index);
        _durationLeft += note.Duration;
      } catch (ArgumentOutOfRangeException) {
        throw new ArgumentOutOfRangeException(nameof(index));
      }
    }
    public IEnumerator<Note> GetEnumerator() {
      List<Note> finalPauses = FinalPauses();

      foreach (Note note in _notes)
        yield return note;

      foreach (Note note in finalPauses)
        yield return note;
    }
    IEnumerator IEnumerable.GetEnumerator() {
      return this.GetEnumerator();
    }
    public override string ToString()
      => _musicalTime.ToString();
    public bool Equals(Measure? other) {
      if (other == null) return false;

      if (!_musicalTime.Equals(other._musicalTime))
        return false;

      if (_notes.Count != other._notes.Count) return false;

      for (int i = 0; i < _notes.Count; ++i)
        if (!_notes[i].Equals(other._notes[i])) return false;

      return true;
    }

    private List<Note> FinalPauses() {
      int power = 0;
      Duration durationLeft = new(_durationLeft);
      Duration currentDuration = new NoteValue(power).Duration;
      List<Note> pauses = [];

      while (durationLeft.Value > 0 && currentDuration < NoteValue.OctupleWhole.Duration) {
        if ((durationLeft.Value & currentDuration.Value) > 0) {
          pauses.Add(new(null, new NoteValue(power)));
          durationLeft -= currentDuration;
        }
        ++power;
        currentDuration = new NoteValue(power).Duration;
      }

      while (durationLeft.Value > 0) {
        pauses.Add(new(null, new NoteValue(power)));
        durationLeft -= currentDuration;
      }

      return pauses;
    }
  }
}
