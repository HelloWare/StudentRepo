using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HWA.ECom.Web
{
    public class ConstantUtil
    {
        public static String MyConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public static String AzureDb = ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString;

        //Not good practice
        public static String NotFromWebConfig = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AzureDB; Integrated Security = True";
    }
}