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

        public static FormationMatiereDB GetInstance()
        {
            if (instance == null)
            {
                instance = new FormationMatiereDB();
            }

            return instance;
        }

        public FormationMatiereDB()
        {
        }

        public void Insert(Formation formation, List<Matiere> lstMatiere)
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
    }
}
