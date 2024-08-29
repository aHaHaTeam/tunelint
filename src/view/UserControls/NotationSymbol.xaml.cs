using System.Windows.Controls;
using tunelint.model;

namespace tunelint.view.UserControls {
  /// <summary>
  /// Interaction logic for NotationSymbol.xaml
  /// </summary>
  public partial class NotationSymbol : UserControl {
    

    private Note? _note;
    private Clef _clef;

    private NoteHead _noteHead;
    private NoteStem _noteStem;

    internal Note? Note { 
      set {
        _note = value;
        _noteHead.Note = value;
      } 
    }

    internal Clef Clef {
      set {
        _clef = value;
      }
    }

    public NotationSymbol() {
      InitializeComponent();
      _clef = Clef.Treble;
      _noteHead = new();
    }

    private void Rebuild() {
      if (_note == null) {
        return;
      }

      var offset = _note.BaseNote.Pitch - _clef.FirstLinePitch;
    }
  }
}
