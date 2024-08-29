using System.Windows.Controls;
using System.Windows.Media;

namespace tunelint.view.UserControls {
  /// <summary>
  /// Interaction logic for NotationBar.xaml
  /// </summary>
  public partial class NotationBar : UserControl {

    private Brush _fill;
    public Brush Fill {
      get => _fill;
      set {
        _fill = value;
        BarRect.Fill = _fill;
      }
    }

    public NotationBar() {
      InitializeComponent();
      _fill = Brushes.Black;
    }

    public void NoteStem_Resize(object sender, EventArgs e) {
      BarCanvas.Width = Width;
      BarCanvas.Height = Height;
      BarRect.Width = Width * 0.1;
      BarRect.Height = Height * 2.5;
      Canvas.SetLeft(BarRect, Width * 0.9);
      Canvas.SetTop(BarRect, Height * -1.4);
    }
  }
}
