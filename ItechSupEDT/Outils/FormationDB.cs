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
    class FormationDB
    {
        private List<Formation> _lstFormation = new List<Formation>();
        private static FormationDB instance;
        
        public static FormationDB GetInstance()
        {
            if (instance == null)
            {
                instance = new FormationDB();
            }

            return instance;
        }

        public FormationDB()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM formation";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                _lstFormation.Add(new Formation(reader["nom_formation"].ToString(), float.Parse(reader["nbHeures_formation"].ToString()), int.Parse(reader["id_formation"].ToString())));
            }
            reader.Close();
            cmd.Dispose();
        }

        public List<Formation> LstFormation
        {
            get { return this._lstFormation; }
            set { this._lstFormation = value; }
        }

        public void Insert(Formation formation)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO formation (nom_formation, nbHeures_formation) OUTPUT INSERTED.id_formation VALUES ('" + formation.Nom + "','" + formation.NbHeuresTotal + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            formation.Id = (int)cmd.ExecuteScalar();
            cmd.Dispose();
        }
    }
}
