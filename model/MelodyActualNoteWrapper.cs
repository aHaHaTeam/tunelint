using System.Collections;

namespace tunelint.model {
  internal class MelodyActualNoteWrapper : IEnumerable<ActualNote> {
    private Melody _melody;

    public MelodyActualNoteWrapper(Melody melody)
        => _melody = melody;

    public IEnumerator<ActualNote> GetEnumerator() {
      throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
  }
}
