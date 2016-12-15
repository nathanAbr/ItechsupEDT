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
    /// Interaction logic for AjoutPromotion.xaml
    /// </summary>
    public partial class AjoutPromotion : UserControl
    {
        private Dictionary<String, Formation> lstFormations;
        private Promotion promotion;
        public Dictionary<String, Formation> LstFormations
        {
            get { return this.lstFormations; }
            set { this.lstFormations = value; }
        }
        public AjoutPromotion(List<Formation> _lstFormations)
        {
            InitializeComponent();

            this.LstFormations = new Dictionary<string, Formation>();
            foreach (Formation formation in FormationDB.GetInstance().LstFormation)
            {
                this.LstFormations.Add(formation.Nom, formation);
            }
            this.cb_lstFormations.ItemsSource = this.LstFormations.Keys;
            this.cb_lstFormations.SelectedIndex = 0;
        }

        private void bt_validerPromotion_Click(object sender, RoutedEventArgs e)
        {
            String nom = tb_nom.Text;
            DateTime dateD = dp_dateDebut.SelectedDate.GetValueOrDefault();
            DateTime dateF = dp_dateFin.SelectedDate.GetValueOrDefault();
            Formation formation = LstFormations[cb_lstFormations.SelectedItem.ToString()];

            try
            {
                promotion = new Promotion(nom, dateD, dateF, formation);
                PromotionDB.GetInstance().Insert(promotion, formation);
                tbk_errorMessage.Text = "La promotion à correctement été ajouté";
            }
            catch (Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }
    }
}
