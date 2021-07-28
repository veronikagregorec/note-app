using LiteDB;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using System.Printing;
using System.Windows.Documents;

namespace Zapisnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : MetroWindow
    {
        public bool zapri;
        public Brush trenutnoIzbranaBarva;
        string connString = string.Format("MyDataNova.db");
        public string besediloPredloge;

        // filtri
        private string filterBeseda = "";
        private DateTime? filterDatum;
        
       



        public MainWindow()
        {
            InitializeComponent();
            pisava.SelectedIndex = 0;
            txtBoxVsebina.FontFamily = new FontFamily("Arial");
            PreberiVsePodatke();
        }

        public IEnumerable<Lastnosti> mojelastnosti { get; set; }


        private void Fonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBoxVsebina.FontFamily = new FontFamily(e.AddedItems[0].ToString());
            txtBoxNaslov.FontFamily = new FontFamily(e.AddedItems[0].ToString());
        }

        private void Ozadje_Click(object sender, RoutedEventArgs e)
        {
            Ozadje oz = new Ozadje();
            oz.Owner = this;
            oz.Show();
            oz.Focus();
        }
        public void ZamenjajBarvoOzadja(Brush novaBarva)
        {
            trenutnoIzbranaBarva = novaBarva;
            txtBoxVsebina.Background = novaBarva;
        }


        public void PrenesiBesediloIzPredloge(string novoBesedilo)
        {
            besediloPredloge = novoBesedilo;
            txtBoxVsebina.Text = novoBesedilo;
        }

        private void PočistiZgodovino_Click(object sender, RoutedEventArgs e)
        {
            using (var LiteDB = new LiteDatabase(connString))
            {
                Lastnosti mojaNovaLastnost = new Lastnosti();
                mojaNovaLastnost.Naslov = txtBoxNaslov.Text;
                mojaNovaLastnost.Vsebina = txtBoxVsebina.Text;
                mojaNovaLastnost.Pisava = pisava.SelectedValue.ToString();
                mojaNovaLastnost.Datum = DateTime.Now;

                var vselastnosti = LiteDB.GetCollection<Lastnosti>();
                vselastnosti.Delete(Query.All());
            }
            PreberiVsePodatke();
        }

        private void Odpri_Click(object sender, RoutedEventArgs e)
        {
            PreberiVsePodatke();
        }

        private void PreberiVsePodatke()
        {
            using (var db = new LiteDatabase(connString))
            {
                var mojelastnosti = db.GetCollection<Lastnosti>();
                var lastnosti = mojelastnosti.FindAll().ToList();
                izpisPodatkov.ItemsSource = lastnosti;
            }
        }

        private void Novo_Click(object sender, RoutedEventArgs e)
        {
            //using (var db = new LiteDatabase(connString))
            //{
            //    {
            //        var mojelastnosti = db.GetCollection<Lastnosti>();
            //        var lastnosti = new Lastnosti();
            //        mojelastnosti.Insert(lastnosti);
            //    }
            //}

            txtBoxVsebina.Clear();
            txtBoxNaslov.Clear();
        }

        private void Shrani_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(connString))
            {
                Lastnosti mojaNovaLastnost = new Lastnosti();
                mojaNovaLastnost.Naslov = txtBoxNaslov.Text;
                mojaNovaLastnost.Vsebina = txtBoxVsebina.Text;
                mojaNovaLastnost.Pisava = pisava.SelectedValue.ToString();

                if (dtPickerNovi.SelectedDate.HasValue) {
                    mojaNovaLastnost.Datum = dtPickerNovi.SelectedDate.Value;
                }
                else {
                    mojaNovaLastnost.Datum = DateTime.Now; //naj nastavi na trenutni datum
                }

                var vseLastnosti = db.GetCollection<Lastnosti>();
                var ooo = vseLastnosti.Insert(mojaNovaLastnost);
            }
            PreberiVsePodatke();
        }

        private void Izbriši_Click(object sender, RoutedEventArgs e)
        {
            if (izpisPodatkov.SelectedItem != null)
            {
                var izbraniId = (BsonValue)(izpisPodatkov.SelectedItem as Lastnosti).ID;

                using (var LiteDB = new LiteDatabase(connString))
                {
                    var vselastnosti = LiteDB.GetCollection<Lastnosti>();
                    vselastnosti.Delete(izbraniId);
                }
            }
            PreberiVsePodatke();
        }




        private void Predloga_Click(object sender, RoutedEventArgs e)
        {
            Predloga pl = new Predloga();
            pl.Owner = this;
            pl.Show();
            pl.Focus();
        }

        private void Opomnik_Click(object sender, RoutedEventArgs e)
        {
            Opomnik op = new Opomnik();
            op.Owner = this;
            op.Show();
            op.Focus();
        }

        //V asinhronem postopku lahko aplikacija nadaljuje z drugim delom, ki ni odvisno od spletnega vira, dokler se morebitna blokada ne konča.
        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (e.Cancel) return;
            // upravljam samo zapiranje
            e.Cancel = !this.zapri;
            // zaprem okno
            if (this.zapri) return;
            var mojeNastavitve = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Da",
                NegativeButtonText = "Ne",
                AnimateShow = true,
                AnimateHide = false
            };
            var result = await this.ShowMessageAsync(
                "Izhod",
                "Ste prepičani, da želite zapustiti aplikacijo?",
                MessageDialogStyle.AffirmativeAndNegative, mojeNastavitve);

            this.zapri = result == MessageDialogResult.Affirmative;

            if (this.zapri)
            {
                Close();
            }
        }

        private void IzpisPodatkov_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Lastnosti vrstica = izpisPodatkov.SelectedItem as Lastnosti;
            if (vrstica != null)
            {
                txtBoxNaslov.Text = vrstica.Naslov;
                txtBoxVsebina.Text = vrstica.Vsebina;
            }
        }

        private void DtPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtPicker.SelectedDate.HasValue)
            {
                filterDatum = dtPicker.SelectedDate;
            }
            else
            {
                filterDatum = null;
            }
            Iskanje();
        }

        private void OdstraniDatum_Click(object sender, RoutedEventArgs e)
        {
            dtPicker.SelectedDate = null;
        }

        private void IskanjePoBazi_KeyUp(object sender, KeyEventArgs e)
        {
            filterBeseda = iskanjePoBazi.Text;

            if (e.Key == Key.Enter)
            {
                Iskanje();
            }
        }
        private void Iskanje()
        {

            List<Lastnosti> lastnosti;

            using (var db = new LiteDatabase(connString))
            {
                var mojelastnosti = db.GetCollection<Lastnosti>();

                if (filterDatum == null && filterBeseda == "")
                {
                    lastnosti = mojelastnosti.FindAll().ToList();
                }
                else if (filterDatum == null)
                {
                    lastnosti = mojelastnosti.Find(x => x.Vsebina.Contains(filterBeseda)).ToList();
                }
                else if (filterBeseda == "")
                {
                    lastnosti = mojelastnosti.Find(x => x.Datum.ToString("dd.MM.YYYY").Equals(filterDatum.Value.ToString("dd.MM.YYYY"))).ToList();
                }
                else
                {
                    lastnosti = mojelastnosti.Find(x => x.Vsebina.Contains(filterBeseda) && x.Datum.ToString("dd.MM.YYYY").Equals(filterDatum.Value.ToString("dd.MM.YYYY"))).ToList();
                }

                izpisPodatkov.ItemsSource = lastnosti;
            }
        }

        private void Natisni_Click(object sender, RoutedEventArgs e)
        {
            //ne sprinta iste pisave
            PrintDialog natisni = new PrintDialog();

            FlowDocument dokument = new FlowDocument(new Paragraph(new Run(txtBoxNaslov.Text)));
            dokument.Blocks.Add(new Paragraph(new Run(txtBoxVsebina.Text)));
            IDocumentPaginatorSource idpSource = dokument;
            natisni.PrintDocument(idpSource.DocumentPaginator, " ");

            PrintQueue printer = LocalPrintServer.GetDefaultPrintQueue();
            Console.WriteLine("Status : {0}", printer.QueueStatus);         
            new PrintServer();
        }

        private void PosljiMejl_Click(object sender, RoutedEventArgs e)
        {
            ePosta ep = new ePosta();
            ep.Owner = this;
            ep.Show();
            ep.Focus();
        }
    }
}
