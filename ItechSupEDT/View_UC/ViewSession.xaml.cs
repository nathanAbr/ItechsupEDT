﻿using ItechSupEDT.Modele;
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
        private ObservableCollection<Session> _lstSession = new ObservableCollection<Session>();
        public ViewSession()
        {
            InitializeComponent();
            try
            {
                foreach (Session session in SessionDB.GetInstance().LstSession)
                {
                    this._lstSession.Add(session);
                }
                lv_session.ItemsSource = this._lstSession;
            }
            catch(Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
        }
    }
}
