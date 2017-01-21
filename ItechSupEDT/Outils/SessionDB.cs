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
    class SessionDB
    {
        private List<Session> _lstSession = new List<Session>();
        private static SessionDB instance;
        Session session;

        public static SessionDB GetInstance()
        {
            if (instance == null)
            {
                instance = new SessionDB();
            }

            return instance;
        }

        public List<Session> LstSession
        {
            get { return this._lstSession; }
            set { this._lstSession = value; }
        }

        public SessionDB()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM sessionCours sc INNER JOIN promotion p ON p.id_promotion = sc.id_promotion_sessionCours INNER JOIN matiere m ON m.id_matiere = sc.id_matiere_sessionCours INNER JOIN salle s ON s.id_salle = sc.id_salle_sessionCours INNER JOIN formateur f ON f.id_formateur = sc.id_formateur_sessionCours INNER JOIN formation ON formation.id_formation = p.id_formation_promotion";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    session = new Session((DateTime)reader["dateDebut_sessionCours"], (DateTime)reader["dateFin_sessionCours"], new Promotion(reader["nom_promotion"].ToString(), (DateTime)reader["dateDebut_promotion"], (DateTime)reader["dateFin_promotion"], new Formation(reader["nom_formation"].ToString(), float.Parse(reader["nbHeures_formation"].ToString()))), new Matiere(reader["nom_matiere"].ToString()), new Salle(reader["nom_salle"].ToString(), int.Parse(reader["capacite_salle"].ToString())), new Formateur(reader["nom_formateur"].ToString(), reader["prenom_formateur"].ToString(), reader["mail_formateur"].ToString(), reader["tel_formateur"].ToString()));
                    session.Id = int.Parse(reader["id_sessionCours"].ToString());
                    session.Nom = "Session du " + reader["dateDebut_sessionCours"].ToString() + " au " + reader["dateFin_sessionCours"].ToString();
                    _lstSession.Add(session);
                }
                reader.Close();
                cmd.Dispose();
            }
        }

        public void Insert(Session session, Salle salle, Formateur formateur, Promotion promotion, Matiere matiere, DateTime dateDebut, DateTime DateFin)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO sessionCours (id_salle_sessionCours , id_formateur_sessionCours , id_promotion_sessionCours , id_matiere_sessionCours , dateDebut_sessionCours, dateFin_sessionCours) OUTPUT INSERTED.id_sessionCours VALUES (" + salle.Id + "," + formateur.Id + "," + promotion.Id + "," + matiere.Id + ",'" + dateDebut + "','" + DateFin + "')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = DatabaseConnection.GetInstance().Connect;
                session.Id = (int)cmd.ExecuteScalar();
                this._lstSession.Add(session);
                cmd.Dispose();
            }
            catch(Exception error)
            {
                throw error;
            }
        }
    }
}
