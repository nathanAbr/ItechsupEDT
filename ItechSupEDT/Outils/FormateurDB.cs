using ItechSupEDT.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class FormateurDB
    {
        private List<Formateur> _lstFormateur = new List<Formateur>();
        private static FormateurDB instance;
        private List<Matiere> _lstMatiere = new List<Matiere>();
        Formateur formateur;

        public static FormateurDB GetInstance()
        {
            if (instance == null)
            {
                instance = new FormateurDB();
            }

            return instance;
        }

        public List<Formateur> LstFormateur
        {
            get { return this._lstFormateur; }
            set { this._lstFormateur = value; }
        }

        public FormateurDB()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM formateur";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                formateur = new Formateur(reader["nom_formateur"].ToString(), reader["prenom_formateur"].ToString(), reader["mail_formateur"].ToString(), reader["tel_formateur"].ToString(), int.Parse(reader["id_formateur"].ToString()));
                _lstFormateur.Add(formateur);
            }
            reader.Close();
            cmd.Dispose();
        }

       public void Insert(Formateur formateur)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO formateur (nom_formateur, prenom_formateur, tel_formateur, mail_formateur) OUTPUT INSERTED.id_formateur VALUES ('" + formateur.Nom + "','" + formateur.Prenom + "','" + formateur.Telephone + "','" + formateur.Mail + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            formateur.Id = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            this._lstFormateur.Add(formateur);
        }
    }
}
