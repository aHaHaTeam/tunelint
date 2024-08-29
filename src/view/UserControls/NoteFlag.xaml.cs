using System.Windows.Controls;
using System.Windows.Media;

namespace tunelint.view.UserControls {
  /// <summary>
  /// Interaction logic for NoteFlag.xaml
  /// </summary>
  public partial class NoteFlag : UserControl {
    private Brush _fill;

    public Brush Fill {
      get => _fill;
      set {
        _fill = value;
        FlagPath.Fill = _fill;
      }
    }

    public NoteFlag() {
      InitializeComponent();
      _fill = Brushes.Black;
    }
  }
}
