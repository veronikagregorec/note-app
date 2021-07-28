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
using LiteDB;

namespace Zapisnik
{
    /// <summary>
    /// Interaction logic for Predloga.xaml
    /// </summary>
    public partial class Predloga : MetroWindow
    {
        string connString = string.Format("MyDataNova.db");
        public Predloga()
        {
            InitializeComponent();
            PreberiVsePredloge();
        }

        private void PreberiVsePredloge()
        {
            using (var db = new LiteDatabase(connString))
            {
                var mojaPredloga = db.GetCollection<Template>();
                gridPredloga.ItemsSource = mojaPredloga.FindAll().ToList();
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new LiteDatabase(connString))
            {
                Template mojaNovaPredloga = new Template();
                
                mojaNovaPredloga.Vsebina = txtBoxPredloga.Text;
                var vsePredloge = db.GetCollection<Template>();
                vsePredloge.Insert(mojaNovaPredloga);
                
                
            }
            PreberiVsePredloge();
            txtBoxPredloga.Clear();
        }

        private void Izbriši_Click(object sender, RoutedEventArgs e)
        {
           
            if (gridPredloga.SelectedItem != null)
            {
                var izbraniId = (BsonValue)(gridPredloga.SelectedItem as Template).ID;

                using (var LiteDB = new LiteDatabase(connString))
                {
                    var vselastnosti = LiteDB.GetCollection<Template>();
                    vselastnosti.Delete(izbraniId);
                }
            }
            PreberiVsePredloge();
            
        }

        private void GridPredloga_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = (MainWindow)Application.Current.MainWindow;

            if (gridPredloga.SelectedItem != null)
            {
                Template trenutni = gridPredloga.SelectedItem as Template;
                mw.PrenesiBesediloIzPredloge(trenutni.Vsebina);
                Close();
            }
        }
    }
}
