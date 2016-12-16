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
    /// Logique d'interaction pour ViewSession.xaml
    /// </summary>
    public partial class ViewSession : UserControl
    {
        private ObservableCollection<ListSession> _lstSession = new ObservableCollection<ListSession>();
        ListSession listSession = new ListSession();
        public ViewSession()
        {
            InitializeComponent();
            try
            {
                foreach (Session session in SessionDB.GetInstance().LstSession)
                {
                    listSession.Nom = session.Nom;
                    listSession.Promotion = session.Promotion.Nom;
                    listSession.Matiere = session.Matiere.Nom;
                    this._lstSession.Add(listSession);
                }
                lv_session.ItemsSource = this._lstSession;
            }
            catch(Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }

        public class ListSession
        {
            public String Nom { get; set; }
            public String Promotion { get; set; }
            public String Matiere { get; set; }
        }
    }
}
