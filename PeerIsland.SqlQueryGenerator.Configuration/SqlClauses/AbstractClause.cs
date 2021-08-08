using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    //Abstrat class for all type of sql clauses
    public abstract class AbstractClause
    {
        public string ClauseType { get; set; }

        internal AbstractClause()
        { }
        internal AbstractClause(string Type)
        {
            this.ClauseType = Type;
        }

        /// <summary>
        /// use this method to validate clause
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValidClause();

        /// <summary>
        /// Set all clause related properties
        /// </summary>
        /// <param name="clause"></param>
        /// <returns></returns>

        public abstract AbstractClause WithClauseProperties(IDictionary<string, IDictionary<string, object>> clause);

        /// <summary>
        /// Implement this method to build the instance
        /// </summary>
        /// <returns></returns>
        public abstract AbstractClause Build();
    }
}
