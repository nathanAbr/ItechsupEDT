using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class DatabaseConnection
    {
        private static DatabaseConnection instance;
        private SqlConnection connect;

        public SqlConnection Connect
        {
            get { return connect; }
            private set { connect = value; }
        }
        public static DatabaseConnection GetInstance()
        {
            if(instance == null)
            {
                instance = new DatabaseConnection();
            }
            return instance;
        }
        private DatabaseConnection()
        {
            using(this.Connect = new SqlConnection("Data Source=PC-NATHAN\\SQLEXPRESS;Initial Catalog=Itechsup;Integrated Security=True"))
            {
                this.Connect = new SqlConnection("Data Source=PC-NATHAN\\SQLEXPRESS;Initial Catalog=Itechsup;Integrated Security=True");
                this.Connect.Open();
            }
        }
    }
}
