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
  /// Interaction logic for WholeNote.xaml
  /// </summary>
  public partial class WholeNote : UserControl {
    private Brush _fill;

    public Brush Fill {
      get => _fill;
      set {
        _fill = value;
        Head.Fill = _fill;
      }
    }

    public WholeNote() {
      InitializeComponent();
      _fill = Brushes.Black;
    }
  }
}
