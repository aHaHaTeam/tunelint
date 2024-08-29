using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using tunelint.model;

namespace tunelint.view.UserControls {
  /// <summary>
  /// Interaction logic for NoteHead.xaml
  /// </summary>
  public partial class NoteHead : UserControl {
    public enum NoteHeadType {
      Black,
      White,
      Whole,
      None
    };

    private static readonly Dictionary<bool, Visibility> _visibility = new() {
      { true, Visibility.Visible },
      { false, Visibility.Hidden }
    };

    private NoteHeadType _type;
    private Brush _fill;

    internal Note? Note {
      set {
        _type = HeadTypeOf(value);
        Rebuild();
      }
    }
    public Brush Fill {
      get => _fill;
      set {
        _fill = value;
        BlackHead.Fill = value;
        WhiteHead.Fill = value;
        WholeHead.Fill = value;
      }
    }

    public NoteHead() {
      InitializeComponent();
      _fill = Brushes.Black;
      _type = NoteHeadType.Black;
    }

    private void Rebuild() {
      BlackHead.Visibility = _visibility[_type == NoteHeadType.Black];
      WhiteHead.Visibility = _visibility[_type == NoteHeadType.White];
      WholeHead.Visibility = _visibility[_type == NoteHeadType.Whole];
    }

    private static NoteHeadType HeadTypeOf(Note? note) {
      if (note == null) return NoteHeadType.None;

      if (note.NoteValue == NoteValue.Half) return NoteHeadType.White;

      if (note.NoteValue.Duration > NoteValue.Half.Duration) return NoteHeadType.Whole;

      return NoteHeadType.Black;
    }
  }
}
