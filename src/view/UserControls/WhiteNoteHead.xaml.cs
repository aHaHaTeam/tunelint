using System.Windows.Controls;
using System.Windows.Media;

namespace tunelint.view.UserControls {
  /// <summary>
  /// Interaction logic for WhiteNoteHead.xaml
  /// </summary>
  public partial class WhiteNoteHead : UserControl {
    private Brush _fill;

    public Brush Fill {
      get => _fill;
      set {
        _fill = value;
        NotePath.Fill = _fill;
      }
    }

    public WhiteNoteHead() {
      InitializeComponent();
      _fill = Brushes.Black;
    }
  }
}
