using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenrator.QueryGenerators
{
    /// <summary>
    /// Implement this interface for generated query for other provider
    /// </summary>
    public interface IQueryGenerator
    {
        /// <summary>
        /// Implement this function to parse string with given provider
        /// </summary>
        /// <param name="Input">Source</param>
        /// <param name="clauses">All Source elements in form of Abstract Clause
        /// Create own configuration provider and generate clauses</param>
        /// <returns></returns>
        public string Generate(string Input, Func<IList<AbstractClause>, string> clauses);
    }
}
