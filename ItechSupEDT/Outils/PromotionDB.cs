﻿using ItechSupEDT.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class PromotionDB
    {
        private List<Promotion> _lstPromotion = new List<Promotion>();
        private static PromotionDB instance;
        Promotion promotion;

        public static PromotionDB GetInstance()
        {
            if (instance == null)
            {
                instance = new PromotionDB();
            }

            return instance;
        }

        public PromotionDB()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM promotion p INNER JOIN formation f ON f.id_formation = p.id_formation_promotion";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                promotion = new Promotion(reader["nom_promotion"].ToString(), (DateTime)reader["dateDebut_promotion"], (DateTime)reader["dateFin_promotion"], new Formation(reader["nom_formation"].ToString(), float.Parse(reader["nbHeures_formation"].ToString()), int.Parse(reader["id_formation_promotion"].ToString())));
                promotion.Id = int.Parse(reader["id_promotion"].ToString());
                _lstPromotion.Add(promotion);
            }
            reader.Close();
            cmd.Dispose();
        }

        public List<Promotion> LstPromotion
        {
            get { return this._lstPromotion; }
            set { this._lstPromotion = value; }
        }

        public void Insert(Promotion promotion, Formation formation)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Promotion (nom_Promotion, dateDebut_promotion, dateFin_promotion, id_formation_promotion) OUTPUT INSERTED.id_promotion VALUES ('" + promotion.Nom + "','" + promotion.DateDebut + "','" + promotion.DateFin + "','" + formation.Id + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DatabaseConnection.GetInstance().Connect;
            promotion.Id = (int)cmd.ExecuteScalar();
            cmd.Dispose();
        }
    }
}
