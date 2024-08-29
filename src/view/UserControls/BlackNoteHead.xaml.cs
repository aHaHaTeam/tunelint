using System.Windows.Controls;
using System.Windows.Media;

namespace tunelint.view.UserControls {
  /// <summary>
  /// Interaction logic for BlackNoteHead.xaml
  /// </summary>
  public partial class BlackNoteHead : UserControl {
    private Brush _fill;
    public Brush Fill {
      get => _fill;
      set {
        _fill = value;
        NoteEllipse.Fill = _fill;
      }
    }

    public BlackNoteHead() {
      InitializeComponent();
      _fill = Brushes.Black;
    }
  }
}
