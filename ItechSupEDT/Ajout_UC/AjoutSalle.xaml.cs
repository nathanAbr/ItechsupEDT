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
    /// Interaction logic for AjoutSalle.xaml
    /// </summary>
    public partial class AjoutSalle : UserControl
    {
        public AjoutSalle()
        {
            InitializeComponent();
        }

        private void btn_Valider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SalleDB.GetInstance().Insert(new Salle(tb_nomSalle.Text, int.Parse(tb_capaciteSalle.Text)));
                SalleDB.GetInstance().LstSalle.Add(new Salle(tb_nomSalle.Text, int.Parse(tb_capaciteSalle.Text)));
                tb_nomSalle.Clear();
                tb_capaciteSalle.Clear();
                tbk_errorMessage.Text = "La salle à bien été ajoutée";
            }
            catch (Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }
    }
}
