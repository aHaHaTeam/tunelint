using System.Windows.Controls;
using System.Windows.Media;

namespace tunelint.view.UserControls {
  /// <summary>
  /// Interaction logic for UserControl1.xaml
  /// </summary>
  public partial class NoteStem : UserControl {
    private Brush _fill;
    public Brush Fill {
      get => _fill;
      set {
        _fill = value;
        BarRect.Fill = _fill;
        BarPoly.Fill = _fill;
      }
    }
    public NoteStem() {
      InitializeComponent();
      _fill = Brushes.Black;
    }
  }
}
