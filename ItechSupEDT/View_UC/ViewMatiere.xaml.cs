using ItechSupEDT.Modele;
using ItechSupEDT.Outils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ItechSupEDT.View_UC
{
    /// <summary>
    /// Logique d'interaction pour ViewMatiere.xaml
    /// </summary>

    public partial class ViewMatiere : UserControl
    {
        private ObservableCollection<Matiere> _lstMatiere = new ObservableCollection<Matiere>();
        public ViewMatiere()
        {
            InitializeComponent();
            try
            {
                foreach (Matiere matiere in MatiereDB.GetInstance().LstMatiere)
                {
                    this._lstMatiere.Add(matiere);
                }
                lv_matiere.ItemsSource = this._lstMatiere;
            }
            catch (Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }
    }
}