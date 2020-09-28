using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TAAPP16_12_2019.DAL
{
    public class dbConstr
    {
        public static string connectionString()
        {   
            string str = ConfigurationManager.ConnectionStrings["appConstr"].ConnectionString;
            return str;
        }
    }
}