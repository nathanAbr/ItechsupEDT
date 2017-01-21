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
        DateTime dateF;
        DateTime dateD;
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
            this.recupPromotion();
            this.recupSalle();
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            Formateur formateur = LstFormateur[cb_lstFormateur.SelectedItem.ToString()];
            Salle salle = LstSalle[cb_lstSalle.SelectedItem.ToString()];
            Promotion promotion = LstPromotion[cb_lstPromotion.SelectedItem.ToString()];
            Matiere matiere  = LstMatiere[cb_lstMatiere.SelectedItem.ToString()];
            try
            {
                session = new Session(this.dateD, this.dateF, promotion, matiere, salle, formateur);
                SessionDB.GetInstance().Insert(session, salle, formateur, promotion, matiere, this.dateD, this.dateF);
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
            if (cb_lstPromotion.SelectedItem != null)
            {
                this.recupMatiere(LstPromotion[cb_lstPromotion.SelectedItem.ToString()]);
            }
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

        private void recupMatiere(Promotion promotion)
        {
            this.LstMatiere = new Dictionary<string, Matiere>();
            foreach (Matiere matiere in promotion.Formation.LstMatiere)
            {
                this.LstMatiere.Add(matiere.Nom, matiere);
            }
            this.cb_lstMatiere.ItemsSource = this.LstMatiere.Keys;
            this.cb_lstMatiere.SelectedIndex = 0;
            this.recupFormateur(LstMatiere[cb_lstMatiere.SelectedItem.ToString()]);
        }

        private void recupFormateur(Matiere matiere)
        {
            this.LstFormateur = new Dictionary<string, Formateur>();
            this.LstFormateur.Add("--Aucun--", new Formateur("", "", "", ""));
            if (cb_lstMatiere.SelectedItem != null)
            {
                foreach (Formateur formateur in FormateurMatiereDB.GetInstance().MatiereFormateur(matiere))
                {
                    this.LstFormateur.Add(formateur.Nom, formateur);
                }
                this.cb_lstFormateur.ItemsSource = this.LstFormateur.Keys;
                this.cb_lstFormateur.SelectedIndex = 0;
            }
                
        }

        private void cb_lstPromotion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.recupMatiere(LstPromotion[cb_lstPromotion.SelectedItem.ToString()]);
        }

        private void dp_dateDebut_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            tbk_hoursDateDebut.Visibility = Visibility.Visible;
            tb_hoursDateDebut.Visibility = Visibility.Visible;
        }

        private void dp_dateFin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            tbk_hoursDateFin.Visibility = Visibility.Visible;
            tb_hoursDateFin.Visibility = Visibility.Visible;
        }
        private void tb_hoursDateDebut_MouseLeave(object sender, MouseEventArgs e)
        {
            int dateDHours;
            int dateDMinute;
            if (tb_hoursDateDebut.Text == "")
            {
                tbk_errorMessage.Text = "Veuillez renseigner une heure de début";
            }
            else
            {
                try
                {
                    if (int.Parse(tb_hoursDateDebut.Text.Substring(0, 1)) == 0)
                    {
                        dateDHours = int.Parse(tb_hoursDateDebut.Text.Substring(1, 1));
                    }
                    else
                    {
                        dateDHours = int.Parse(tb_hoursDateDebut.Text.Substring(0, 2));
                    }
                    if (int.Parse(tb_hoursDateDebut.Text.Substring(3, 1)) == 0)
                    {
                        dateDMinute = int.Parse(tb_hoursDateDebut.Text.Substring(4, 1));
                    }
                    else
                    {
                        dateDMinute = int.Parse(tb_hoursDateDebut.Text.Substring(3, 2));
                    }
                    this.dateD = new DateTime(dp_dateDebut.SelectedDate.Value.Year, dp_dateDebut.SelectedDate.Value.Month, dp_dateDebut.SelectedDate.Value.Day, dateDHours, dateDMinute, 0);
                    tbk_errorMessage.Text = "";
                }
                catch (Exception error)
                {
                    tbk_errorMessage.Text = error.Message;
                }
            }
        }

        private void tb_hoursDateFin_MouseLeave(object sender, MouseEventArgs e)
        {
            int dateFHours;
            int dateFMinute;
            if (tb_hoursDateFin.Text == "")
            {
                tbk_errorMessage.Text = "Veuillez renseigner une heure de Fin";
            }
            else
            {
                try
                {
                    if (int.Parse(tb_hoursDateFin.Text.Substring(0, 1)) == 0)
                    {
                        dateFHours = int.Parse(tb_hoursDateFin.Text.Substring(1, 1));
                    }
                    else
                    {
                        dateFHours = int.Parse(tb_hoursDateFin.Text.Substring(0, 2));
                    }
                    if (int.Parse(tb_hoursDateFin.Text.Substring(3, 1)) == 0)
                    {
                        dateFMinute = int.Parse(tb_hoursDateFin.Text.Substring(4, 1));
                    }
                    else
                    {
                        dateFMinute = int.Parse(tb_hoursDateFin.Text.Substring(3, 2));
                    }
                    this.dateF = new DateTime(dp_dateFin.SelectedDate.Value.Year, dp_dateFin.SelectedDate.Value.Month, dp_dateFin.SelectedDate.Value.Day, dateFHours, dateFMinute, 00);
                    tbk_errorMessage.Text = "";
                }
                catch (Exception error)
                {
                    tbk_errorMessage.Text = error.Message;
                }
            }
        }

        private void cb_lstMatiere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_lstMatiere.SelectedItem != null)
            {
                this.recupFormateur(LstMatiere[cb_lstMatiere.SelectedItem.ToString()]);
            }
        }
    }
}
