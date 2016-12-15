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
using ItechSupEDT.Outils;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormation.xaml
    /// </summary>
    public partial class AjoutFormation : UserControl
    {
        private Formation formation;
        private List<Matiere> _lstMatiere = new List<Matiere>();
        public AjoutFormation(List<Nameable> _lstMatiere)
        {
            InitializeComponent();
            foreach (Matiere matiere in MatiereDB.GetInstance().LstMatiere)
            {
                _lstMatiere.Add(matiere);
            }
            MutliSelectPickList multiSelect = multiSelect = new MutliSelectPickList(_lstMatiere);
            this.MultiSelect.Content = multiSelect;
        }

        public AjoutFormation(Formation _formation)
        {
            InitializeComponent();
            tb_nomFormation.Text = _formation.Nom;
            tb_dureeFormation.Text = _formation.NbHeuresTotal.ToString();
        }

        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {
            List<Nameable> lstMatiere = new List<Nameable>(((MutliSelectPickList)this.MultiSelect.Content).GetSelectedObjects());
            foreach(Nameable matiere in lstMatiere)
            {
                this._lstMatiere.Add((Matiere)matiere);
            }
            
            String nom = tb_nomFormation.Text;
            String nbHeures = tb_dureeFormation.Text;
            try
            {
                float duree = Single.Parse(nbHeures);
                formation = new Formation(nom, duree, this._lstMatiere);
                FormationDB.GetInstance().Insert(formation);
                FormationMatiereDB.GetInstance().Insert(formation, this._lstMatiere);
                tb_nomFormation.Text = "";
                tb_dureeFormation.Text = "";
                tbk_errorMessage.Text = "La formation à correctement été ajouté";
            }
            catch(Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }
    }
}
