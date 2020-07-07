using System.Configuration;

namespace Esoft.DataAccess.DataSqlGateways
{
    public abstract class SqlConfig
    {
        //EsoftDB - value in App.config
        public static string ConnectionStringValue(string name = "EsoftDB")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
