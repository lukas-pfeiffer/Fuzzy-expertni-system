using System;
using System.Collections.Generic;
using System.IO;
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

namespace Fuzzy_expertni_system
{
    /// <summary>
    /// Interaction logic for Vypis.xaml
    /// </summary>
    public partial class Vypis : Window
    {
        int cislo = 1;

        public Vypis()
        {
            InitializeComponent();
            nacteni();
        }

        private void nacteni()
        {
            string cestaVyska = @"txt\vyska.txt";
            string cestaVek = @"txt\vek.txt";
            string cestaPostava = @"txt\postava.txt";
            string cestaZaludek = @"txt\zaludek.txt";
            string cestaNalada = @"txt\nalada.txt";
            string cestaVzdelani = @"txt\vzdelani.txt";
            string cestaKurak = @"txt\kurak.txt";
            string cestaUnava = @"txt\unava.txt";

            string s;

            switch (cislo)
            {
                case 1:
                    using (StreamReader sr = new StreamReader(cestaVyska, Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        textBlok.Text = s;
                    }
                    break;
                case 2: 
                    using (StreamReader sr = new StreamReader(cestaVek, Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        textBlok.Text = s;
                    }
                    break;
                case 3:
                    using (StreamReader sr = new StreamReader(cestaPostava, Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        textBlok.Text = s;
                    }
                    break;
                case 4:
                    using (StreamReader sr = new StreamReader(cestaZaludek, Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        textBlok.Text = s;
                    }
                    break;
                case 5:
                    using (StreamReader sr = new StreamReader(cestaNalada, Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        textBlok.Text = s;
                    }
                    break;

                case 6:
                    using (StreamReader sr = new StreamReader(cestaVzdelani, Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        textBlok.Text = s;
                    }
                    break;
                case 7:
                    using (StreamReader sr = new StreamReader(cestaKurak, Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        textBlok.Text = s;
                    }
                    break;
                case 8:
                    using (StreamReader sr = new StreamReader(cestaUnava, Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        textBlok.Text = s;
                    }
                    break;
                default:
                    break;
            }          
        }

        private void btnDoleva_Click(object sender, RoutedEventArgs e)
        {
            cislo--;
            cisla();
            nacteni();
        }

        private void btnDoprava_Click(object sender, RoutedEventArgs e)
        {
            cislo++;
            cisla();
            nacteni();
        }

        private void cisla()
        {
            if (cislo < 1)
            {
                cislo = 8;
            }
            if (cislo > 8)
            {
                cislo = 1;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
