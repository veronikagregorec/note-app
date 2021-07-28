using MahApps.Metro.Controls;
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

using Microsoft.Win32;
using System.IO;

//async
using MahApps.Metro.Controls.Dialogs;

namespace Zapisnik
{
    /// <summary>
    /// Interaction logic for ePosta.xaml
    /// </summary>
    public partial class ePosta : MetroWindow
    {

        string PriponkaPot = string.Empty;
        

        public ePosta()
        {
            InitializeComponent();
        }


        private void Priponka_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            PriponkaPot = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            txtBoxPriponka.Text = openFileDialog.SafeFileName;
            txtBoxPriponka.Text = Convert.ToString(openFileDialog.FileName);
        }

        private void Izbriši_Click(object sender, RoutedEventArgs e)
        {
            PriponkaPot = string.Empty;
            txtBoxPriponka.Text = "Dodaj priponko";
        }

        private async void Poslji_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Net.Mail.MailMessage sporočilo = new System.Net.Mail.MailMessage();
                sporočilo.Subject = txtZadeva.Text;
                sporočilo.From = new System.Net.Mail.MailAddress(txtBoxUporabiskoIme.Text);
                sporočilo.Body = txtBoxVsebinaePoste.Text;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(txtBoxPriponka.Text);
                sporočilo.Attachments.Add(attachment);


                foreach (string za in txtZa.Text.Split(','))
                {
                    sporočilo.To.Add(txtZa.Text);
                }

                //dovoliš pošiljanje e pošte gmail: https://myaccount.google.com/lesssecureapps
                //System.Net.Mail.SmtpClient klijent = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                System.Net.Mail.SmtpClient klijent = new System.Net.Mail.SmtpClient("smtp-mail.outlook.com");

                klijent.Credentials = new System.Net.NetworkCredential(txtBoxUporabiskoIme.Text, pswBoxPassword.Password);
                klijent.EnableSsl = true;
                klijent.Port = 587;
                klijent.Send(sporočilo);

                await this.ShowMessageAsync ("Elektronska pošta","e-Pošta je uspešno poslana.", MessageDialogStyle.Affirmative);

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync ("Napaka", ex.Message, MessageDialogStyle.Affirmative);
            }
        }
    }
}
