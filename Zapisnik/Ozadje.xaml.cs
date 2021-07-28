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
using MahApps.Metro.Controls;

namespace Zapisnik
{
    /// <summary>
    /// Interaction logic for Ozadje.xaml
    /// </summary>
    public partial class Ozadje : MetroWindow
    {
        public Brush IzbranaBarva;

        public Ozadje()
        {
            InitializeComponent();
        }
        private void ClickIzbranaBarva(object sender, RoutedEventArgs e)
        {
            IzbranaBarva = (sender as Button).Background;
            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            mw.ZamenjajBarvoOzadja(IzbranaBarva);
            Close();
        }
    }
}
