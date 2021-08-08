using PeerIsland.Settings.Parser;
using PeerIsland.SqlQueryGenerator.Configuration;
using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using PeerIsland.SqlQueryGenrator.QueryGenerators;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenrator
{
    public class SQLGenerator : IQueryGenerator
    {
        public string Generate(string Json)
        {
            var configParser = new QueryConfiguration()
                                .ReadFrom
                                .FromJsonString(Json);

            return ParseClauses(configParser.Clauses);
        }

        private string ParseClauses(IList<AbstractClause> clauses)
        {
            return string.Empty;
        }
    }
}