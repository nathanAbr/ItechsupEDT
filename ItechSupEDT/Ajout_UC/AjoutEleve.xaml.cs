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
    /// Interaction logic for AjoutEleve.xaml
    /// </summary>
    public partial class AjoutEleve : UserControl
    {
        
        Dictionary<String, Promotion> _lstPromotion;
        Eleve eleve;
        public Dictionary<String, Promotion> LstPromotion
        {
            get { return this._lstPromotion; }
            set { this._lstPromotion = value; }
        }
        public AjoutEleve()
        {
            InitializeComponent();

            this.LstPromotion = new Dictionary<string, Promotion>();
            foreach (Promotion promotion in PromotionDB.GetInstance().LstPromotion)
            {
                this.LstPromotion.Add(promotion.Nom, promotion);
            }
            this.cb_lstPromotion.ItemsSource = this.LstPromotion.Keys;
            this.cb_lstPromotion.SelectedIndex = 0;
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            String nom = tb_nomEleve.Text;
            String prenom = tb_prenomEleve.Text;
            String mail = tb_mailEleve.Text;
            Promotion promotion = LstPromotion[cb_lstPromotion.SelectedItem.ToString()];

            try
            {
                eleve = new Eleve(nom, prenom, mail, promotion);
                EleveDB.GetInstance().Insert(eleve, promotion);
                tbk_errorMessage.Text = "L'élève à correctement été ajouté";
            }
            catch (Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }
    }
}
