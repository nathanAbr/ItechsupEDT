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
    class MatiereDB
    {
        private List<Matiere> _lstMatiere = new List<Matiere>();
        private static MatiereDB instance;
        Matiere matiere;

        public static MatiereDB GetInstance()
        {
            if (instance == null)
            {
                instance = new MatiereDB();
            }

            return instance;
        }

        public MatiereDB()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM matiere";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                matiere = new Matiere(reader["nom_matiere"].ToString());
                matiere.Id = int.Parse(reader["id_matiere"].ToString());
                _lstMatiere.Add(matiere);
            }
            reader.Close();
            cmd.Dispose();
        }

        public List<Matiere> LstMatiere
        {
            get { return this._lstMatiere; }
            set { this._lstMatiere = value; }
        }

        public void Insert(Matiere matiere)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO matiere (nom_matiere) VALUES ('" + matiere.Nom + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            cmd.ExecuteReader();
            cmd.Dispose();
        }
    }
}
