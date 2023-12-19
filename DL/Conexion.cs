using System.Configuration;

namespace DL
{
    public class Conexion
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["JSANCHEZDIGIPRO"].ConnectionString;
        }
    }
}
