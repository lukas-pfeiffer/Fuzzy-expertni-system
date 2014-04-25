using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fuzzy_expertni_system
{
    public class HlavniMenu
    {
        Menu menu;

        public Menu vyklesleniMenu(Brush barvaMenu, Brush barvaOkraje, int vyska, int sirka)
        {
            menu = new Menu();
            menu.Background = barvaMenu;
            menu.BorderBrush = barvaOkraje;
            menu.Height = vyska;
            menu.Width = sirka;
            
            return menu;
        }

        public void tlacitkaMenu()
        {
            Separator oddelovac = new Separator();

            MenuItem soubor = new MenuItem();
            soubor.Header = "Soubor";
            //soubor.Height = 20;
            
            MenuItem konec = new MenuItem();
            konec.Header = "Konec";
            konec.Click += konec_Click;
            //-----------------------------------

            MenuItem nastaveni = new MenuItem();
            nastaveni.Header = "Nastavení";
            //--------------------------------------

            MenuItem napoveda = new MenuItem();
            napoveda.Header = "Nápověda";
            //--------------------------------------

            MenuItem oHre = new MenuItem();
            oHre.Header = "O hře";
            //--------------------------------------

            MenuItem vypocitat = new MenuItem();
            vypocitat.Header = "Vypočítat";
            vypocitat.Click += vypocitat_Click;


            menu.Items.Add(soubor);
            soubor.Items.Add(konec);
            //-----------------------------------

            menu.Items.Add(vypocitat);

        }

        void vypocitat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.hlavni();
        }

        void konec_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult odpoved = MessageBox.Show("Opravdu chcete ukončit hru?","Ukončení",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (odpoved == MessageBoxResult.Yes)
            {                
                Application.Current.Shutdown();
            }
        }
    }
}
