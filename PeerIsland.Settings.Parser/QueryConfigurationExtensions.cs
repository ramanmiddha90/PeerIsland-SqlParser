using PeerIsland.SqlQueryGenerator.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.Settings.Parser
{
  public static class QueryConfigurationExtensions 
    {
        /// <summary>
        /// Extension method to implement configuration provider
        /// </summary>
        /// <param name="querySettingConfiguration"></param>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static QueryConfiguration FromJsonString(this QuerySettingConfiguration querySettingConfiguration,string Json)
        {
            return querySettingConfiguration.Parse(new JsonStringParser(Json));
        }
    }
}
