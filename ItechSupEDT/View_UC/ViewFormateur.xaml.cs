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
    /// Logique d'interaction pour ViewFormateur.xaml
    /// </summary>
    public partial class ViewFormateur : UserControl
    {
        private ObservableCollection<Formateur> _lstFormateur = new ObservableCollection<Formateur>();
        public ViewFormateur()
        {
            InitializeComponent();
            try
            {
                foreach (Formateur formateur in FormateurDB.GetInstance().LstFormateur)
                {
                    this._lstFormateur.Add(formateur);
                }
                lv_formateur.ItemsSource = this._lstFormateur;
                foreach ()
            }
            catch (Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }
    }
}
