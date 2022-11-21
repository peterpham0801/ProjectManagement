using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement
{
    internal class Users
    {
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement");

 
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public bool AdminAccount { get; set; }

        public List<Users> LoadListUser()
        {
            List<Users> lstUer = new List<Users>();
            con.Open();
            MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM users", con);
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var ck = new Users();
                ck.UserName = reader.GetString("userName");
                ck.Password = reader.GetString("UPassword");
                ck.AdminAccount = reader.GetBoolean("AdminAccount");
                lstUer.Add(ck);
            }
            con.Close();
            return lstUer;
        }
    }
}
