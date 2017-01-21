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
    class FormationMatiereDB
    {
        private static FormationMatiereDB instance;

        public static FormationMatiereDB GetInstance(Formation formation)
        {
            if (instance == null)
            {
                instance = new FormationMatiereDB(formation);
            }

            return instance;
        }

        public FormationMatiereDB(Formation formation)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM formation INNER JOIN formation_matiere ON formation_matiere.id_formation = formation.id_formation INNER JOIN matiere ON matiere.id_matiere = formation_matiere.id_matiere WHERE formation.id_formation = " + formation.Id;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    formation.LstMatiere.Add(new Matiere(reader["nom_matiere"].ToString(), int.Parse(reader["id_matiere"].ToString())));
                }
                reader.Close();
                cmd.Dispose();
            } 
        }

        public void Insert(Formation formation, List<Matiere> lstMatiere)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO formation_matiere (id_formation, id_matiere) VALUES ";
                foreach (Matiere matiere in lstMatiere)
                {
                    cmd.CommandText += "(" + formation.Id + ", " + matiere.Id + "),";
                }
                cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1, 1);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = DatabaseConnection.GetInstance().Connect;
                cmd.ExecuteReader();
                cmd.Dispose();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
