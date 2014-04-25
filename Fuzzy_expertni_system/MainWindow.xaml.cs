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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotFuzzy;

namespace Fuzzy_expertni_system
{
    public partial class MainWindow : Window
    {
        #region Deklarace proměných

        string jmeno;
        int vaha;
        double faktor;
        double beta;

        int iPostava;
        int iVyska;
        int iVek;
        int iVzdelani;
        int iZaludek;
        int iNalada;
        int iPovaha;
        int iKurak;
        int iUnava;

        int iPivo10;
        int iPivo12;
        int iAlkoholSlaby;
        int iAlkoholStredni;
        int iAlkoholSilny;
        int iVinoBile;
        int iVinoCervene;

        double vPostava;
        double vVyska;
        double vVaha;
        double vPohlavi;
        double vVek;
        double vVzdelani;
        double vZaludek;
        double vNalada;
        double vPovaha;
        double vKurak;
        double vUnava;

        double vPivo10;
        double vPivo12;
        double vAlkoholSlaby;
        double vAlkoholStredni;
        double vAlkoholSilny;
        double vVinoBile;
        double vVinoCervene;
        
        LinguisticVariable postava; 
        LinguisticVariable vyska;
        LinguisticVariable vek;
        LinguisticVariable vzdelani;
        LinguisticVariable zaludek;
        LinguisticVariable nalada;
        LinguisticVariable kurak;
        LinguisticVariable unava;
        LinguisticVariable hodnota;
        
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            //menu();
        }

        private void menu()
        {
            HlavniMenu hlavniMenu = new HlavniMenu();
            platnoMenu.Children.Add(hlavniMenu.vyklesleniMenu(Brushes.WhiteSmoke, Brushes.Black, 20, 300));
            hlavniMenu.tlacitkaMenu();
        }

        #region Fuzzy

        private void fuzifikace()
        {
            //  vstup
            postava = new LinguisticVariable("Postava");
            postava.MembershipFunctionCollection.Add(new MembershipFunction("Drobna", -51, 0, 0, 100));
            postava.MembershipFunctionCollection.Add(new MembershipFunction("Normalni", 0, 100, 100, 200));
            postava.MembershipFunctionCollection.Add(new MembershipFunction("Urostla", 100, 200, 200, 251));

            vyska = new LinguisticVariable("Vyska");
            vyska.MembershipFunctionCollection.Add(new MembershipFunction("Mala", -100, 150, 170, 180));
            vyska.MembershipFunctionCollection.Add(new MembershipFunction("Stredni", 170, 180, 190, 200));
            vyska.MembershipFunctionCollection.Add(new MembershipFunction("Vysoka", 190, 200, 200, 300));

            vek = new LinguisticVariable("Vek");
            vek.MembershipFunctionCollection.Add(new MembershipFunction("Mlady", -100, 18, 20, 27));
            vek.MembershipFunctionCollection.Add(new MembershipFunction("Stredni", 25, 30, 45, 50));
            vek.MembershipFunctionCollection.Add(new MembershipFunction("Stary", 45, 50, 80, 150));

            vzdelani = new LinguisticVariable("Vzdelani");
            vzdelani.MembershipFunctionCollection.Add(new MembershipFunction("Zakladni", -50, 0, 0, 50));
            vzdelani.MembershipFunctionCollection.Add(new MembershipFunction("Stredni", 50, 100, 100, 150));
            vzdelani.MembershipFunctionCollection.Add(new MembershipFunction("Vysoka", 150, 200, 200, 250));

            zaludek = new LinguisticVariable("Zaludek");
            zaludek.MembershipFunctionCollection.Add(new MembershipFunction("Lacno", -51, 0, 0, 100));
            zaludek.MembershipFunctionCollection.Add(new MembershipFunction("Lehka", 0, 100, 100, 200));
            zaludek.MembershipFunctionCollection.Add(new MembershipFunction("Stredni", 100, 200, 200, 300));
            zaludek.MembershipFunctionCollection.Add(new MembershipFunction("Nadmerna", 200, 300, 300, 351));

            nalada = new LinguisticVariable("Nalada");
            nalada.MembershipFunctionCollection.Add(new MembershipFunction("Dobra", -51, 0, 0, 100));
            nalada.MembershipFunctionCollection.Add(new MembershipFunction("Normalni", 0, 100, 100, 200));
            nalada.MembershipFunctionCollection.Add(new MembershipFunction("Spatna", 100, 200, 200, 251));

            kurak = new LinguisticVariable("Kurak");
            kurak.MembershipFunctionCollection.Add(new MembershipFunction("Ne", -50, 0, 0, 50));
            kurak.MembershipFunctionCollection.Add(new MembershipFunction("Cigarety", 50, 100, 100, 150));
            kurak.MembershipFunctionCollection.Add(new MembershipFunction("Doutniky", 150, 200, 200, 250));
            kurak.MembershipFunctionCollection.Add(new MembershipFunction("Vodarna", 250, 300, 300, 350));

            unava = new LinguisticVariable("Unava");            
            unava.MembershipFunctionCollection.Add(new MembershipFunction("Mala", -51, 0, 0, 100));
            unava.MembershipFunctionCollection.Add(new MembershipFunction("Normalni", 0, 100, 100, 200));
            unava.MembershipFunctionCollection.Add(new MembershipFunction("Velka",  100, 200, 200, 251));

            //  vystup
            hodnota = new LinguisticVariable("Hodnota");
            hodnota.MembershipFunctionCollection.Add(new MembershipFunction("Snizuje", -0.1, -0.1, -0.05, 0));
            hodnota.MembershipFunctionCollection.Add(new MembershipFunction("Zustava", -0.05, 0, 0, 0.05));
            hodnota.MembershipFunctionCollection.Add(new MembershipFunction("Zvysuje", 0, 0.05, 0.1, 0.1));            
        }

        private void fuzzyLogika()
        {
            FuzzyEngine fuzzyPostava = new FuzzyEngine();
            fuzzyPostava.LinguisticVariableCollection.Add(postava);
            fuzzyPostava.LinguisticVariableCollection.Add(hodnota);
            fuzzyPostava.Consequent = "Hodnota";
            fuzzyPostava.FuzzyRuleCollection.Add(new FuzzyRule("IF Postava IS Drobna THEN Hodnota IS Zvysuje"));
            fuzzyPostava.FuzzyRuleCollection.Add(new FuzzyRule("IF Postava IS Normalni THEN Hodnota IS Zustava"));
            fuzzyPostava.FuzzyRuleCollection.Add(new FuzzyRule("IF Postava IS Urostla THEN Hodnota IS Snizuje"));

            FuzzyEngine fuzzyVyska = new FuzzyEngine();
            fuzzyVyska.LinguisticVariableCollection.Add(vyska);
            fuzzyVyska.LinguisticVariableCollection.Add(hodnota);
            fuzzyVyska.Consequent = "Hodnota";
            fuzzyVyska.FuzzyRuleCollection.Add(new FuzzyRule("IF Vyska IS Mala THEN Hodnota IS Zvysuje"));
            fuzzyVyska.FuzzyRuleCollection.Add(new FuzzyRule("IF Vyska IS Stredni THEN Hodnota IS Zustava"));
            fuzzyVyska.FuzzyRuleCollection.Add(new FuzzyRule("IF Vyska IS Vysoka THEN Hodnota IS Snizuje"));
                    
            FuzzyEngine fuzzyVek = new FuzzyEngine();
            fuzzyVek.LinguisticVariableCollection.Add(vek);
            fuzzyVek.LinguisticVariableCollection.Add(hodnota);
            fuzzyVek.Consequent = "Hodnota";
            fuzzyVek.FuzzyRuleCollection.Add(new FuzzyRule("IF Vek IS Mlady THEN Hodnota IS Zvysuje"));
            fuzzyVek.FuzzyRuleCollection.Add(new FuzzyRule("IF Vek IS Stredni THEN Hodnota IS Zustava"));
            fuzzyVek.FuzzyRuleCollection.Add(new FuzzyRule("IF Vek IS Stary THEN Hodnota IS Zvysuje"));

            FuzzyEngine fuzzyVzdelani = new FuzzyEngine();
            fuzzyVzdelani.LinguisticVariableCollection.Add(vzdelani);
            fuzzyVzdelani.LinguisticVariableCollection.Add(hodnota);
            fuzzyVzdelani.Consequent = "Hodnota";
            fuzzyVzdelani.FuzzyRuleCollection.Add(new FuzzyRule("IF Vzdelani IS Zakladni THEN Hodnota IS Zvysuje"));
            fuzzyVzdelani.FuzzyRuleCollection.Add(new FuzzyRule("IF Vzdelani IS Stredni THEN Hodnota IS Zustava"));
            fuzzyVzdelani.FuzzyRuleCollection.Add(new FuzzyRule("IF Vzdelani IS Vysoka THEN Hodnota IS Snizuje"));

            FuzzyEngine fuzzyZaludek = new FuzzyEngine();
            fuzzyZaludek.LinguisticVariableCollection.Add(zaludek);
            fuzzyZaludek.LinguisticVariableCollection.Add(hodnota);
            fuzzyZaludek.Consequent = "Hodnota";
            fuzzyZaludek.FuzzyRuleCollection.Add(new FuzzyRule("IF Zaludek IS Lacno THEN Hodnota IS Zvysuje"));
            fuzzyZaludek.FuzzyRuleCollection.Add(new FuzzyRule("IF Zaludek IS Lehka THEN Hodnota IS Zvysuje"));
            fuzzyZaludek.FuzzyRuleCollection.Add(new FuzzyRule("IF Zaludek IS Stredni THEN Hodnota IS Zustava"));
            fuzzyZaludek.FuzzyRuleCollection.Add(new FuzzyRule("IF Zaludek IS Nadmerna THEN Hodnota IS Snizuje"));

            FuzzyEngine fuzzyNalada = new FuzzyEngine();
            fuzzyNalada.LinguisticVariableCollection.Add(nalada);
            fuzzyNalada.LinguisticVariableCollection.Add(hodnota);
            fuzzyNalada.Consequent = "Hodnota";
            fuzzyNalada.FuzzyRuleCollection.Add(new FuzzyRule("IF Nalada IS Dobra THEN Hodnota IS Snizuje"));
            fuzzyNalada.FuzzyRuleCollection.Add(new FuzzyRule("IF Nalada IS Normalni THEN Hodnota IS Zustava"));
            fuzzyNalada.FuzzyRuleCollection.Add(new FuzzyRule("IF Nalada IS Spatna THEN Hodnota IS Zvysuje"));

            FuzzyEngine fuzzyKurak = new FuzzyEngine();
            fuzzyKurak.LinguisticVariableCollection.Add(kurak);
            fuzzyKurak.LinguisticVariableCollection.Add(hodnota);
            fuzzyKurak.Consequent = "Hodnota";
            fuzzyKurak.FuzzyRuleCollection.Add(new FuzzyRule("IF Kurak IS Ne THEN Hodnota IS Snizuje"));
            fuzzyKurak.FuzzyRuleCollection.Add(new FuzzyRule("IF Kurak IS Cigarety THEN Hodnota IS Zustava"));
            fuzzyKurak.FuzzyRuleCollection.Add(new FuzzyRule("IF Kurak IS Doutniky THEN Hodnota IS Zvysuje"));
            fuzzyKurak.FuzzyRuleCollection.Add(new FuzzyRule("IF Kurak IS Vodarna THEN Hodnota IS Snizuje"));

            FuzzyEngine fuzzyUnava = new FuzzyEngine();
            fuzzyUnava.LinguisticVariableCollection.Add(unava);
            fuzzyUnava.LinguisticVariableCollection.Add(hodnota);
            fuzzyUnava.Consequent = "Hodnota";
            fuzzyUnava.FuzzyRuleCollection.Add(new FuzzyRule("IF Unava IS Mala THEN Hodnota IS Zvysuje"));
            fuzzyUnava.FuzzyRuleCollection.Add(new FuzzyRule("IF Unava IS Normalni THEN Hodnota IS Zustava"));
            fuzzyUnava.FuzzyRuleCollection.Add(new FuzzyRule("IF Unava IS Velka THEN Hodnota IS Snizuje"));

            try
            {
                vVyska = fuzzyVyska.Defuzzify();
                udalosti.Items.Add("Vyska: " + tbVyska.Text + " -> " + vVyska);
                
                vVek = fuzzyVek.Defuzzify();
                udalosti.Items.Add("Vek: " + tbVek.Text + " -> " + vVek);
                
                vPostava = fuzzyPostava.Defuzzify();
                udalosti.Items.Add("Postava: " + sPostava.Value + " -> " + vPostava);
               
                vZaludek = fuzzyZaludek.Defuzzify();
                udalosti.Items.Add("Zaludek: " + sZaludek.Value + " -> " + vZaludek);
                
                vNalada = fuzzyNalada.Defuzzify();
                udalosti.Items.Add("Nalada: " + sNalada.Value + " -> " + vNalada);

                vUnava = fuzzyUnava.Defuzzify();
                udalosti.Items.Add("Únava: " + sUnava.Value + " -> " + vUnava);

                vVzdelani = fuzzyVzdelani.Defuzzify();
                udalosti.Items.Add("Vzdelani: " + cbVzdelani.Text + " -> " + vVzdelani);
                
                vKurak = fuzzyKurak.Defuzzify();
                udalosti.Items.Add("Kurak: " + cbKurak.Text + " -> " + vKurak);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


            string cestaVyska = @"txt\vyska.txt";
            string cestaVek = @"txt\vek.txt";
            string cestaPostava = @"txt\postava.txt";
            string cestaZaludek = @"txt\zaludek.txt";
            string cestaNalada = @"txt\nalada.txt";
            string cestaVzdelani = @"txt\vzdelani.txt";
            string cestaKurak = @"txt\kurak.txt";
            string cestaUnava = @"txt\unava.txt";

            fuzzyVyska.Save(cestaVyska);
            fuzzyVek.Save(cestaVek);
            fuzzyPostava.Save(cestaPostava);
            fuzzyZaludek.Save(cestaZaludek);
            fuzzyNalada.Save(cestaNalada);
            fuzzyUnava.Save(cestaVzdelani);
            fuzzyVzdelani.Save(cestaVyska);
            fuzzyKurak.Save(cestaKurak);
            fuzzyUnava.Save(cestaUnava);
        }

        #endregion

        #region vypočet alkoholu v krvi

        private double spočtiEtanol(double objem, double obsahAlkoholu)//objem v mililitrech, 
        {
            double etanol = (objem * obsahAlkoholu * 0.8) / 100;
            //udalosti.Items.Add("e-----------------");
            //udalosti.Items.Add("etanol: " + etanol);  
            return etanol;
        }

        private double spočtiPromile(double etanol, double pVaha, double pFaktor)
        {
            double promile = Math.Round(etanol / (pVaha * pFaktor), 2);
            //udalosti.Items.Add("p-----------------");  
            udalosti.Items.Add("Promile bez fuzzy: " + promile);  
            return promile;
        }

        private double spoctiCelkovyEtanol()
        {
            double celkovyEtanol = 0;

            //udalosti.Items.Add("Celkovy etanol: " + celkovyEtanol);
            celkovyEtanol += spočtiEtanol(iPivo10 * 500, 4);
            //udalosti.Items.Add("Celkovy etanol: " + celkovyEtanol);
            celkovyEtanol += spočtiEtanol(iPivo12 * 500, 5);
            //udalosti.Items.Add("Celkovy etanol: " + celkovyEtanol);

            celkovyEtanol += spočtiEtanol(iAlkoholSlaby * 50, 20);
            //udalosti.Items.Add("Celkovy etanol: " + celkovyEtanol);
            celkovyEtanol += spočtiEtanol(iAlkoholStredni * 50, 40);
            //udalosti.Items.Add("Celkovy etanol: " + celkovyEtanol);
            celkovyEtanol += spočtiEtanol(iAlkoholSilny * 50, 60);
            //udalosti.Items.Add("Celkovy etanol: " + celkovyEtanol);

            celkovyEtanol += spočtiEtanol(iVinoBile * 200, 11);
            //udalosti.Items.Add("Celkovy etanol: " + celkovyEtanol);
            celkovyEtanol += spočtiEtanol(iVinoCervene * 200, 13);
            //udalosti.Items.Add("Celkovy etanol: " + celkovyEtanol);  

            return celkovyEtanol;
        }

        private void vypocetAlkoholu()
        {
            double etanol = spoctiCelkovyEtanol();

            double promile = 0;

            promile = spočtiPromile(etanol, vaha, faktor);

            double koeficient  = vPostava + vVyska + vVek + vVzdelani + vZaludek + vNalada + vKurak + vUnava;

            double celkovePromile = Math.Round(promile * (koeficient + 1), 2);
            
            if (celkovePromile.ToString() == "Není číslo")
            {
                udalosti.Items.Clear();
                udalosti.Items.Add("Chyba");
                udalosti.Items.Add("----------------------------------------------------------------");
                udalosti.Items.Add("Nejsou zadány všechny potřebné údaje");
                udalosti.Items.Add("nebo jsou nesmyslné.");
                return;
            }

            udalosti.Items.Add("Fuzzy koecifient: " + koeficient);
            udalosti.Items.Add("Promile s fuzzy: " + celkovePromile);
            udalosti.Items.Add("----------------------------------------------------------------");
            odbouraniAlkoholu(etanol, koeficient);
            udalosti.Items.Add("----------------------------------------------------------------");
            snasenlivostAlkoholu(koeficient);
        }

        private void snasenlivostAlkoholu(double k)
        {
            string s = "Snášenlivost alkoholu: ";

            if (k < 0)
            {
                udalosti.Items.Add(s + "Dobrá");
            }
            else if (k == 0)
            {
                udalosti.Items.Add(s + "Normální");
            }
            else
            {
                udalosti.Items.Add(s + "Špatná");
            }
        }

        private void odbouraniAlkoholu(double oEtanol, double oKoecifient)
        {
            double odbourani = vaha* beta;
            int cas = 0;

            while (0 < oEtanol)
            {
                oEtanol -= odbourani;
                cas++;
            }

            int fCas = (int)(cas * (oKoecifient + 1));

            udalosti.Items.Add("Doba střízlivění bez fuzzy: " + cas + " hodin");
            udalosti.Items.Add("Doba střízlivění s fuzzy: " + fCas + " hodin");
        }

        #endregion
             
        private bool nastaveniHodnot()
        {
            try
            {
                postava.InputValue = sPostava.Value;//cbPostava.SelectedIndex * 100;

                vyska.InputValue = int.Parse(tbVyska.Text);

                vek.InputValue = int.Parse(tbVek.Text);

                vzdelani.InputValue = cbVzdelani.SelectedIndex * 100;

                zaludek.InputValue = sZaludek.Value; //cbZaludek.SelectedIndex * 100;

                kurak.InputValue = cbKurak.SelectedIndex * 100;

                unava.InputValue = sUnava.Value;//cbBricho.SelectedIndex * 100;

                nalada.InputValue = sNalada.Value;

                vaha = int.Parse(tbVaha.Text);

                if (cbPohlavi.SelectedIndex == 0)
                {
                    faktor = 0.7; //faktor pro muže
                    beta = 0.1; //beta odbouravani
                }
                else if (cbPohlavi.SelectedIndex == 1)
                {
                    faktor = 0.6; //pro ženy
                    beta = 0.085;//
                }

                iPivo10 = int.Parse(tbPivo10.Text);
                iPivo12 = int.Parse(tbPivo12.Text);

                iAlkoholSlaby = int.Parse(tbAlkoholSlaby.Text);
                iAlkoholStredni = int.Parse(tbAlkoholStredni.Text);
                iAlkoholSilny = int.Parse(tbAlkoholSilny.Text);

                iVinoBile = int.Parse(tbVinoBile.Text);
                iVinoCervene = int.Parse(tbVinoCervene.Text);
                return true;
            }
            catch (Exception chyba)
            {
                udalosti.Items.Clear();
                udalosti.Items.Add("Chyba");
                udalosti.Items.Add("---------------------------------------------------");
                udalosti.Items.Add(chyba.Message);
                return false;
            }
        }

        public void hlavni()
        {
            udalosti.Items.Clear();
            udalosti.Items.Add("Jméno: " + tbJmeno.Text);
            udalosti.Items.Add("----------------------------------------------------------------");
            fuzifikace();
            if (nastaveniHodnot())
            {
                fuzzyLogika();
                udalosti.Items.Add("----------------------------------------------------------------");
                vypocetAlkoholu();
            }
        }

        #region Tlačítka

        private void btnVypocitat_Click(object sender, RoutedEventArgs e)
        {
            hlavni();
        }

        private void btnKonec_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnVypis_Click(object sender, RoutedEventArgs e)
        {
            Vypis vypis = new Vypis();
            vypis.Show();
        }

        #endregion     


    }
}
