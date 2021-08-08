using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using PeerIsland.SqlQueryGenrator.QueryGenerators;
using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenrator
{
    public class QueryManager
    {
        private IQueryGenerator _generator;
        private Func<IList<AbstractClause>, string> builder;

        public QueryManager(IQueryGenerator generator, Func<IList<AbstractClause>, string> builder)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            this.builder = builder;
        }
        public string GenerateQueryFromJson(string Input)
        {
            return _generator.Generate(Input, builder);
        }
    }
}
