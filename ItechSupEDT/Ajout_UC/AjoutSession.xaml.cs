using ItechSupEDT.Modele;
using ItechSupEDT.Outils;
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

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Logique d'interaction pour AjoutSession.xaml
    /// </summary>
    public partial class AjoutSession : UserControl
    {
        Dictionary<String, Promotion> _lstPromotion;
        Dictionary<String, Formateur> _lstFormateur;
        Dictionary<String, Salle> _lstSalle;
        Dictionary<String, Matiere> _lstMatiere;
        Session session;
        public Dictionary<String, Promotion> LstPromotion
        {
            get { return this._lstPromotion; }
            set { this._lstPromotion = value; }
        }
        public Dictionary<String, Salle> LstSalle
        {
            get { return this._lstSalle; }
            set { this._lstSalle = value; }
        }
        public Dictionary<String, Matiere> LstMatiere
        {
            get { return this._lstMatiere; }
            set { this._lstMatiere = value; }
        }
        public Dictionary<String, Formateur> LstFormateur
        {
            get { return this._lstFormateur; }
            set { this._lstFormateur = value; }
        }
        public AjoutSession()
        {
            InitializeComponent();
            this.recupFormateur();
            this.recupMatiere();
            this.recupPromotion();
            this.recupSalle();
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateD = dp_dateDebut.SelectedDate.GetValueOrDefault();
            DateTime dateF = dp_dateFin.SelectedDate.GetValueOrDefault();
            Formateur formateur = LstFormateur[cb_lstFormateur.SelectedItem.ToString()];
            Salle salle = LstSalle[cb_lstSalle.SelectedItem.ToString()];
            Promotion promotion = LstPromotion[cb_lstPromotion.SelectedItem.ToString()];
            Matiere matiere  = LstMatiere[cb_lstMatiere.SelectedItem.ToString()];

            try
            {
                session = new Session(dateD, dateF, promotion, matiere, salle, formateur);
                SessionDB.GetInstance().Insert(session, salle, formateur, promotion, matiere, dateD, dateF);
                tbk_errorMessage.Text = "La Session à correctement été ajouté";
            }
            catch (Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }

        private void recupPromotion()
        {
            this.LstPromotion = new Dictionary<string, Promotion>();
            foreach (Promotion promotion in PromotionDB.GetInstance().LstPromotion)
            {
                this.LstPromotion.Add(promotion.Nom, promotion);
            }
            this.cb_lstPromotion.ItemsSource = this.LstPromotion.Keys;
            this.cb_lstPromotion.SelectedIndex = 0;
        }

        private void recupSalle()
        {
            this.LstSalle = new Dictionary<string, Salle>();
            foreach (Salle salle in SalleDB.GetInstance().LstSalle)
            {
                this.LstSalle.Add(salle.Nom, salle);
            }
            this.cb_lstSalle.ItemsSource = this.LstSalle.Keys;
            this.cb_lstSalle.SelectedIndex = 0;
        }

        private void recupMatiere()
        {
            this.LstMatiere = new Dictionary<string, Matiere>();
            foreach (Matiere matiere in MatiereDB.GetInstance().LstMatiere)
            {
                this.LstMatiere.Add(matiere.Nom, matiere);
            }
            this.cb_lstMatiere.ItemsSource = this.LstMatiere.Keys;
            this.cb_lstMatiere.SelectedIndex = 0;
        }

        private void recupFormateur()
        {
            this.LstFormateur = new Dictionary<string, Formateur>();
            foreach (Formateur formateur in FormateurDB.GetInstance().LstFormateur)
            {
                this.LstFormateur.Add(formateur.Nom, formateur);
            }
            this.cb_lstFormateur.ItemsSource = this.LstFormateur.Keys;
            this.cb_lstFormateur.SelectedIndex = 0;
        }

    }
}
