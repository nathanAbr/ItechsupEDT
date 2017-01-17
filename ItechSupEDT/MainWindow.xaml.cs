﻿using System;
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
using ItechSupEDT.Ajout_UC;
using ItechSupEDT.Modele;
using ItechSupEDT.Outils;

namespace ItechSupEDT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            View_UC.ViewSession viewSession = new View_UC.ViewSession();
            this.Ajout.Content = viewSession;
        }
		
        private void mi_ajout_formation_Click(object sender, RoutedEventArgs e)
        {
            List<Nameable> lstMatiere = new List<Nameable>();
            Ajout_UC.AjoutFormation ajoutFormation = new Ajout_UC.AjoutFormation(lstMatiere);
            this.Ajout.Content = ajoutFormation;
		}
		
        private void mi_ajout_matiere_Click(object sender, RoutedEventArgs e)
        {
            AjoutMatiere ajoutMatiere = new AjoutMatiere();
            this.Ajout.Content = ajoutMatiere;
        }

        private void mi_ajout_promotion_Click(object sender, RoutedEventArgs e)
        {
            List<Nameable> lstEleves = new List<Nameable>();
            AjoutPromotion ajoutPromotion = new AjoutPromotion(new List<Formation>());
            this.Ajout.Content = ajoutPromotion;
        }

        private void mi_ajout_formateur_Click(object sender, RoutedEventArgs e)
        {
            List<Nameable> lstMatiere = new List<Nameable>();
            AjoutFormateur ajoutFormateur = new AjoutFormateur(lstMatiere);
            this.Ajout.Content = ajoutFormateur;
        }

        private void mi_afficher_formation_Click(object sender, RoutedEventArgs e)
        {
            // Récuperer la formation depuis la base de donnée (id = 1 par exemple)
            Formation formation = new Modele.Formation("NomFormation", 150);
            Ajout_UC.AjoutFormation ajoutFormation = new Ajout_UC.AjoutFormation(formation);
            this.Ajout.Content = ajoutFormation;
        }

        private void mi_afficher_matiere_Click(object sender, RoutedEventArgs e)
        {
            View_UC.ViewMatiere viewMatiere = new View_UC.ViewMatiere();
            this.Ajout.Content = viewMatiere;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AjoutSalle ajoutSalle = new AjoutSalle();
            this.Ajout.Content = ajoutSalle;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AjoutEleve ajoutEleve = new AjoutEleve();
            this.Ajout.Content = ajoutEleve;
        }

        private void mi_afficher_formateur_Click(object sender, RoutedEventArgs e)
        {
            View_UC.ViewFormateur viewFormateur = new View_UC.ViewFormateur();
            this.Ajout.Content = viewFormateur;
        }

        private void mi_ajout_session_Click(object sender, RoutedEventArgs e)
        {
            Ajout_UC.AjoutSession addSession = new Ajout_UC.AjoutSession();
            this.Ajout.Content = addSession;
        }
    }
}
