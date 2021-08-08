using PeerIsland.SqlQueryGenrator.QueryGenerators;
using System;

namespace PeerIsland.SqlQueryGenrator
{
    public class QueryManager
    {
        private IQueryGenerator _generator;

        public QueryManager(IQueryGenerator generator)
        {
            _generator = generator;
        }
        public String GenerateQueryFromJson(string json)
        {
            return _generator.Generate(json);
        }
    }
}
