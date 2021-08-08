using PeerIsland.SqlQueryGenerator.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.Settings.Parser
{
  public static class QueryConfigurationExtensions 
    {
        public static QueryConfiguration FromJsonString(this QuerySettingConfiguration querySettingConfiguration,string Json)
        {
            return querySettingConfiguration.Parse(new JsonStringParser(Json));
        }
    }
}
