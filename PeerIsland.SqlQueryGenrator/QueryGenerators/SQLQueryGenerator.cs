using PeerIsland.Settings.Parser;
using PeerIsland.SqlQueryGenerator.Configuration;
using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using PeerIsland.SqlQueryGenrator.QueryGenerators;
using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenrator
{
    public class SQLGenerator : IQueryGenerator
    {
        public string Generate(string Input, Func<IList<AbstractClause>, string> builder)
        {
            var configParser = new QueryConfiguration()
                                .ReadFrom
                                .FromJsonString(Input);

            if (builder != null)
                return builder(configParser.Clauses);

            else
                return new SqlQueryBuilder().BuildQuery(configParser.Clauses);
        }

    }
}