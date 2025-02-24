using IrodalomProjekt.Models;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IrodalomProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<Kerdes> kerdesek=new List<Kerdes>();
        private static int aktualisIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private static void KerdeseketFeltolt(string fileName)
        {
            {
                kerdesek.Clear();
                try
                {
                    StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
                    while (!sr.EndOfStream)
                    {
                        string KerdesSzovege = sr.ReadLine();
                        string ValaszA = sr.ReadLine();
                        string ValaszB = sr.ReadLine();
                    }
                }
             catch ( IOException ex)
                {
                    throw new IOException("Hiba a fájl olvasása közben: " + ex.Message);
                }
                
            }
        }

        private void BetoltesClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT fájlok (*.txt)| *.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    KerdeseketFeltolt(openFileDialog.FileName);
                    MessageBox.Show("Sikeres betöltés!", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (kerdesek.Count > 0)

                    {
                        aktualisIndex = 0;
                        MutatKerdes(aktualisIndex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MutatKerdes(int index)
        {
           if(kerdesek.Count>index)
            {
                Kerdes kerdes=kerdesek[index];
                tbkKerdesSzovege.Text = kerdes.KerdesSzovege;
                ValaszA.Content=kerdes.ValaszA;
                ValaszB.Content = kerdes.ValaszB;
                ValaszC.Content = kerdes.ValaszC;
                switch(kerdes.FelhasznaloValasza)
                {
                    case "A":
                        ValaszA.IsChecked = true;
                        ValaszB.IsChecked = false;
                        ValaszC.IsChecked = false;
                        break;
                    case "B":
                        ValaszB.IsChecked = true;
                        ValaszA.IsChecked = false;
                        ValaszC.IsChecked = false;
                        break;
                    case "C":
                        ValaszC.IsChecked = true;
                        ValaszB.IsChecked = false;
                        ValaszA.IsChecked = false;
                        break;
                    default:
                        ValaszA.IsChecked = false;
                        ValaszB.IsChecked = false;
                        ValaszC.IsChecked = false;
                        break;
                }


            }
        }

        private void KilepesClick(object sender, RoutedEventArgs e)
        {

        }

        private void KiertekelesClick(object sender, RoutedEventArgs e)
        {

        }

        private void ElozoClick(object sender, RoutedEventArgs e)
        {
            if (aktualisIndex > 0)
            {
                aktualisIndex--;
                MutatKerdes(aktualisIndex);
            }
        }

        private void ValaszMenteseClick(object sender, RoutedEventArgs e)
        {
            if(aktualisIndex < kerdesek.Count)
            {
                if(ValaszA.IsChecked==true)
                {
                    kerdesek[aktualisIndex].FelhasznaloValasza = "A";
                }
                else if (ValaszB.IsChecked==true)
                {
                    kerdesek[aktualisIndex].FelhasznaloValasza="B";
                }
                else if(ValaszC.IsChecked==true)
                {
                    kerdesek[aktualisIndex].FelhasznaloValasza="C";
                }
            }
            MessageBox.Show("Válasz mentve!", "Információ");
        }

        private void KovetkezoClick(object sender, RoutedEventArgs e)
        {
            if(aktualisIndex <kerdesek.Count-1)
            {
                aktualisIndex++;
                MutatKerdes(aktualisIndex);
            }
        }
    }
}