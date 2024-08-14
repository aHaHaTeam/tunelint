using System.Collections;

namespace tunelint.model {
  internal class Melody : IEnumerable<Note> {
    internal class NoteEnumerator : IEnumerator<Note> {
      public NoteEnumerator(Melody melody) {
        throw new NotImplementedException();
      }

      public Note Current => throw new NotImplementedException();

      object IEnumerator.Current => throw new NotImplementedException();

      public void Dispose() {
      }

      public bool MoveNext() {
        throw new NotImplementedException();
      }

      public void Reset() {
        throw new NotImplementedException();
      }
    }

    private readonly MusicalTime _musicalTime;
    public MusicalTime MusicalTime => _musicalTime;
    private List<Note> Notes;

    public Melody(MusicalTime time) {
      _musicalTime = time;
      Notes = [];
    }

    public IEnumerator<Note> GetEnumerator()
        => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
  }
}
