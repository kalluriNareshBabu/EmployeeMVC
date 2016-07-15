using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace EmployeeMVC.DataAccessLayer
{
    public class DBconnect
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }
    }
}