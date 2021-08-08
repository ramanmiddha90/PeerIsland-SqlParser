using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration
{
    /// <summary>
    /// Configuration conatining all clauses of the source string
    /// </summary>
    public class QueryConfiguration
    {
        public IList<AbstractClause> Clauses = new List<AbstractClause>();

        /// <summary>
        /// Enhance this to add more configuration provider
        /// </summary>
        public QuerySettingConfiguration ReadFrom
        {
            get { return new QuerySettingConfiguration(this); }
        }
    }
}
