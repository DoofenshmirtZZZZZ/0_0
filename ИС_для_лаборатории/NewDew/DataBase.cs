using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDew
{

    /*internal class DataBase
    {
        public static string logUser;
    }*/

    class DataBase
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AD8DKJH0;Initial Catalog=isdoc;Integrated Security=True");

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
        public SqlConnection getConnection()
        {
            return con;
        }

    }
    

}
