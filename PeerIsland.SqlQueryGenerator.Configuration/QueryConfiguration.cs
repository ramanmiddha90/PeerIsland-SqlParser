using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.SqlQueryGenerator.Configuration
{
   public class QueryConfiguration
    {
        public IList<AbstractClause> Clauses = new List<AbstractClause>();

        public QuerySettingConfiguration ReadFrom
        {
            get { return new QuerySettingConfiguration(this); }
        }
    }
}
