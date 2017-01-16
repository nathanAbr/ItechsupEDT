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
    class FormateurMatiereDB
    {
        private static FormateurMatiereDB instance;

        public static FormateurMatiereDB GetInstance()
        {
            if (instance == null)
            {
                instance = new FormateurMatiereDB();
            }

            return instance;
        }

        public FormateurMatiereDB()
        {
        }

        public void Insert(Formateur formateur, List<Matiere> lstMatiere)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO formateur_matiere (id_formateur, id_matiere) VALUES ";
            foreach (Matiere matiere in lstMatiere)
            {
                cmd.CommandText += "(" + formateur.Id + ", " + matiere.Id + "),";
            }
            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1, 1);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            cmd.ExecuteReader();
            cmd.Dispose();
        }
    }
}
