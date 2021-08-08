using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenrator.QueryGenerators
{
    public interface IQueryGenerator
    {
        public string Generate(string Input, Func<IList<AbstractClause>, string> builder);
    }
}
