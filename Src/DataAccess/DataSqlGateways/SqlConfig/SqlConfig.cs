﻿using System.Configuration;

namespace Esoft.DataAccess.DataSqlGateways.SqlConfig
{
    public static class CSqlConfig
    {
        //EsoftDB - value in App.config
        public static string DefaultCnnVal(string name = "EsoftDB")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}