using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _608Project
{
	class DBConnection
	{
        public static string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}",
                    ConfigurationManager.AppSettings["Server"],
                    ConfigurationManager.AppSettings["database"],
                    ConfigurationManager.AppSettings["UID"],
                    ConfigurationManager.AppSettings["password"]);
    }
}
