using System;
using System.IO;
using Xamarin.Forms;

namespace XamarinTiedonTallennus
{
    public partial class MainPage : ContentPage
    {
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder
            .LocalApplicationData), "muistio.txt");

        string text = "";

        public MainPage()
        {
            InitializeComponent();

            bool doesExist = File.Exists(fileName);

            if (doesExist == true)
            {
                text = File.ReadAllText(fileName);
                if (text.Length > 0)
                {
                    outputLabel.Text = text;
                }
                else
                {
                    outputLabel.Text = "Mitään ei ole talletettu muistioon.";
                }
                
            }
            else
            {
                outputLabel.Text = "Tervetuloa uudelle käyttäjälle!";
            }
        }

        
        private void tallennusNappi_Clicked(object sender, EventArgs e)
        {
            text = text + Environment.NewLine + inputKentta.Text;
            File.WriteAllText(fileName, text);
            text = File.ReadAllText(fileName);
            outputLabel.Text = text;
            inputKentta.Text = "";
        }

        private void poistoNappi_Clicked(object sender, EventArgs e)
        {
            poistoNappi.IsVisible = false;
            vahvistusInfo.IsVisible = true;
            vahvistusKytkin.IsVisible = true;
        }

        private void vahvistusKytkin_Toggled(object sender, ToggledEventArgs e)
        {
            File.WriteAllText(fileName, "");
            text = "";
            outputLabel.Text = "Muistiinpanot tyhjennetty.";
            poistoNappi.IsVisible = true;
            vahvistusInfo.IsVisible = false;
            vahvistusKytkin.IsVisible = false;
        }
    }
 }

