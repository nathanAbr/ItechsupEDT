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
using ItechSupEDT.Modele;

namespace ItechSupEDT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
        }

        private void mi_ajout_formation_Click(object sender, RoutedEventArgs e)
        {
            Ajout_UC.AjoutFormation ajoutFormation = new Ajout_UC.AjoutFormation();
            this.Ajout.Content = ajoutFormation;
		}
        private void mi_ajoutMatiere_Click(object sender, RoutedEventArgs e)
        {
            List <MultiSelectedObject> lstMatiere = new List<MultiSelectedObject>();
            MultiSelectedObject matiere1 = new Matiere("Droit");
            MultiSelectedObject matiere2 = new Matiere("Français");
            MultiSelectedObject matiere3 = new Matiere("Mathématiques");
            MultiSelectedObject matiere4 = new Matiere("Anglais");
            MultiSelectedObject matiere5 = new Matiere("Informatique");
            MultiSelectedObject matiere6 = new Matiere("Management");
            lstMatiere.Add(matiere1);
            lstMatiere.Add(matiere2);
            lstMatiere.Add(matiere3);
            lstMatiere.Add(matiere4);
            lstMatiere.Add(matiere5);
            lstMatiere.Add(matiere6);
            Ajout_UC.MutliSelectPickList test = new Ajout_UC.MutliSelectPickList(lstMatiere);
            this.Ajout.Content = test;
        }
    }
}
