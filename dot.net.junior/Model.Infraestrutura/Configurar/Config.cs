using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infraestrutura.Configurar
{
    public static class Config
    {

        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["DataBaseName"].ConnectionString;

        public static string ValueSettings(string Key) =>
             ConfigurationManager.AppSettings[Key];
    }
}
