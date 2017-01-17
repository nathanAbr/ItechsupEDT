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
    class EleveDB
    {
        private List<Eleve> _lstEleve = new List<Eleve>();
        private static EleveDB instance;

        public static EleveDB GetInstance()
        {
            if (instance == null)
            {
                instance = new EleveDB();
            }

            return instance;
        }

        public EleveDB()
        {
        }

        public List<Eleve> LstEleve
        {
            get { return this._lstEleve; }
            set { this._lstEleve = value; }
        }

        public void Insert(Eleve eleve, Promotion promotion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Eleve (nom_eleve, prenom_eleve, mail_eleve, id_promotion_eleve) OUTPUT INSERTED.id_eleve VALUES ('" + eleve.Nom + "','" + eleve.Prenom + "','" + eleve.Mail + "','" + promotion.Id + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            eleve.Id = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            this._lstEleve.Add(eleve);
        }
    }
}
