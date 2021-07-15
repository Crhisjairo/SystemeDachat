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
using System.Windows.Shapes;

namespace SystemeDachat.Views.Windows
{
    /// <summary>
    /// Logique d'interaction pour HelpWindows.xaml
    /// </summary>
    public partial class HelpWindows : Window
    {
        public HelpWindows()
        {
            InitializeComponent();
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
