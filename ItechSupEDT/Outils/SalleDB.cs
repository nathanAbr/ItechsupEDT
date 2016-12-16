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
    class SalleDB
    {
        private List<Salle> _lstSalle = new List<Salle>();
        private static SalleDB instance;
        Salle salle;

        public static SalleDB GetInstance()
        {
            if (instance == null)
            {
                instance = new SalleDB();
            }

            return instance;
        }

        public SalleDB()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM salle";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                salle = new Salle(reader["nom_salle"].ToString(), int.Parse(reader["capacite_salle"].ToString()));
                salle.Id = int.Parse(reader["id_salle"].ToString());
                _lstSalle.Add(salle);
            }
            reader.Close();
            cmd.Dispose();
        }

        public List<Salle> LstSalle
        {
            get { return this._lstSalle; }
            set { this._lstSalle = value; }
        }

        public void Insert(Salle salle)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO salle (nom_salle, capacite_salle) OUTPUT INSERTED.id_salle VALUES ('" + salle.Nom + "', "+ salle.Capacite +")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            salle.Id = (int)cmd.ExecuteScalar();
            cmd.Dispose();
        }
    }
}
