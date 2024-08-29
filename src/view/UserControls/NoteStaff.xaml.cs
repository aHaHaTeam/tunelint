using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tunelint.view.UserControls {
  /// <summary>
  /// Interaction logic for NoteStaff.xaml
  /// </summary>
  public partial class NoteStaff : UserControl {
    private Brush _fill;
    public Brush Fill {
      get => _fill;
      set {
        _fill = value;
        Rect1.Fill = _fill;
        Rect2.Fill = _fill;
        Rect3.Fill = _fill;
        Rect4.Fill = _fill;
        Rect5.Fill = _fill;
      }
    }
    public NoteStaff() {
      InitializeComponent();
      _fill = Brushes.Black;
    }
  }
}
