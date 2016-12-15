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
    class PromotionDB
    {
        private List<Promotion> _lstPromotion = new List<Promotion>();
        private static PromotionDB instance;

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
