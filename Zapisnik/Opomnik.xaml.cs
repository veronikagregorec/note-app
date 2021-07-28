using LiteDB;
using MahApps.Metro.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Zapisnik
{
    /// <summary>
    /// Interaction logic for Opomnik.xaml
    /// </summary>
    public partial class Opomnik : MetroWindow
    {
        string connString = string.Format("MyDataNova.db");

        public Opomnik()
        {
            InitializeComponent();

            // ta funkcija preverb vse iz baze
            // refresh
            PreberiVseReminderje();


        }

        private void PreberiVseReminderje()
        {
            using (var db = new LiteDatabase(connString))
            {
                var mojReminder = db.GetCollection<Reminder>();
                gridOpomnik.ItemsSource = mojReminder.FindAll().ToList();
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(connString))
            {
                Reminder mojNoviReminder = new Reminder();
                mojNoviReminder.Vsebina = txtBoxOpomnik.Text;
                var vsiReminderji = db.GetCollection<Reminder>();
                vsiReminderji.Insert(mojNoviReminder);
            }
            PreberiVseReminderje();
            txtBoxOpomnik.Clear();
        }

        private void Izbriši_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in gridOpomnik.Items)
            {
                Reminder trenutni = item as Reminder;
                if (trenutni.Izbran == true)
                {
                    using (var LiteDB = new LiteDatabase(connString))
                    {
                        var vsiReminderji = LiteDB.GetCollection<Reminder>();
                        vsiReminderji.Delete(trenutni.ID);
                    }
                }
            }

            PreberiVseReminderje();
            
        }


        private void Posodobi_Click(object sender, RoutedEventArgs e)
        {
            if (gridOpomnik.SelectedItem != null)
            {

                Reminder trenutni = gridOpomnik.SelectedItem as Reminder;
                using (var LiteDB = new LiteDatabase(connString))
                {
                    var vsiReminderji = LiteDB.GetCollection<Reminder>();
                    vsiReminderji.Update(trenutni);
                }
            }
            PreberiVseReminderje();
            txtBoxOpomnik.Clear();
        }

        private void GridOpomnik_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = (MainWindow)Application.Current.MainWindow;

            if (gridOpomnik.SelectedItem != null)
            {
                Reminder trenutni = gridOpomnik.SelectedItem as Reminder;
                mw.PrenesiBesediloIzPredloge(trenutni.Vsebina);
                Close();
            }

        }
    }
}
