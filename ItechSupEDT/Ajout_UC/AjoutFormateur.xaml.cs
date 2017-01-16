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
using ItechSupEDT.Ajout_UC;
using ItechSupEDT.Outils;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormateur.xaml
    /// </summary>
    public partial class AjoutFormateur : UserControl
    {
        MutliSelectPickList multiSelect;
        private Formateur formateur;
        private List<Matiere> _lstMatiere = new List<Matiere>();
        public AjoutFormateur(List<Nameable> _lstMatiere)
        {
            InitializeComponent();
            foreach (Matiere matiere in MatiereDB.GetInstance().LstMatiere)
            {
                _lstMatiere.Add(matiere);
            }
            multiSelect = new MutliSelectPickList(_lstMatiere);
            this.MultiSelect.Content = multiSelect;
        }

        public AjoutFormateur(Formateur _formateur)
        {
            InitializeComponent();
            tb_nomFormateur.Text = _formateur.Nom;
            tb_prenomFormateur.Text = _formateur.Prenom;
            tb_telFormateur.Text = _formateur.Telephone;
            tb_mailFormateur.Text = _formateur.Mail;
        }

        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {
            List<Nameable> lstMatiere = new List<Nameable>(((MutliSelectPickList)this.MultiSelect.Content).GetSelectedObjects());
            foreach (Nameable matiere in lstMatiere)
            {
                this._lstMatiere.Add((Matiere)matiere);
            }

            String nom = tb_nomFormateur.Text;
            String prenom = tb_prenomFormateur.Text;
            String tel = tb_telFormateur.Text;
            String mail = tb_mailFormateur.Text;
            try
            {
                formateur = new Formateur(nom, prenom, mail, tel);
                FormateurDB.GetInstance().Insert(formateur);
                FormateurMatiereDB.GetInstance().Insert(formateur, this._lstMatiere);
                tb_nomFormateur.Clear();
                tb_prenomFormateur.Clear();
                tb_telFormateur.Clear();
                tb_mailFormateur.Clear();
                tbk_errorMessage.Text = "Le formateur à correctement été ajouté";
            }
            catch (Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }
    }
}
