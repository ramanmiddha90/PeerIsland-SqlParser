using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.SqlQueryGenerator.Configuration
{
   public class QuerySettingConfiguration
    {
        public QueryConfiguration _queryConfiguration;

        internal QuerySettingConfiguration(QueryConfiguration queryConfiguration)
        {
            _queryConfiguration=queryConfiguration ??   throw new ArgumentNullException(nameof(queryConfiguration));
        }
        public QueryConfiguration Parse(IConfigParser parser)
        {
            parser.Parse(_queryConfiguration);
            return _queryConfiguration;
        }
    }
}
