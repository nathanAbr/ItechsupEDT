﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Matiere : Nameable
    {
        private String nom;
        private List<Formation> lstFormations;
        private List<Session> lstSessions;
        private List<Formateur> lstFormateurs;
        private int id;
        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public List<Formation> LstFormations
        {
            get { return this.lstFormations; }
            set { this.lstFormations = value; }
        }
        public List<Session> LstSessions
        {
            get { return this.lstSessions; }
            set { this.lstSessions = value; }
        }
        public List<Formateur> LstFormateurs
        {
            get { return this.lstFormateurs; }
            set { this.lstFormateurs = value; }
        }
        public Matiere(String _nom)
        {
            this.Nom = _nom;
            this.LstSessions = new List<Session>();
            this.LstFormateurs = new List<Formateur>();
            this.lstFormations = new List<Formation>();
        }

        public Matiere(String _nom, int _id)
        {
            this.Nom = _nom;
            this.Id = _id;
            this.LstSessions = new List<Session>();
            this.LstFormateurs = new List<Formateur>();
            this.lstFormations = new List<Formation>();
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public String getNom()
        {
            return this.Nom;
        }
    }
}
