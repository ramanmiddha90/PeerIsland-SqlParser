using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using PeerIsland.SqlQueryGenrator.QueryGenerators;
using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenrator
{
    /// <summary>
    /// Class initializing parsing operation
    /// </summary>
    public class QueryManager
    {
        private IQueryGenerator _generator;
        private Func<IList<AbstractClause>, string> builder;

        public QueryManager(IQueryGenerator generator, Func<IList<AbstractClause>, string> builder)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            this.builder = builder;
        }

        /// <summary>
        /// Call this method to parse json string into sql query
        /// </summary>
        /// <param name="Input">JsonInput</param>
        /// <returns></returns>
        public string GenerateQueryFromJson(string JSON)
        {
            return _generator.Generate(JSON, builder);
        }
    }
}
