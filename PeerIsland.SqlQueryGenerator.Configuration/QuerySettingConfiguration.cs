using System;

namespace PeerIsland.SqlQueryGenerator.Configuration
{
    public class QuerySettingConfiguration
    {
        public QueryConfiguration _queryConfiguration;

        internal QuerySettingConfiguration(QueryConfiguration queryConfiguration)
        {
            _queryConfiguration=queryConfiguration ??   throw new ArgumentNullException(nameof(queryConfiguration));
        }
        /// <summary>
        /// Call parse handler to redirect the call to provider
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public QueryConfiguration Parse(IConfigParser parser)
        {
            parser.Parse(_queryConfiguration);
            return _queryConfiguration;
        }
    }
}
