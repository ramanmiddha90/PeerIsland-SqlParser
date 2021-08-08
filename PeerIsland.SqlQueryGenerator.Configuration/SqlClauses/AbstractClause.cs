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

        public abstract bool IsValidClause();

        public abstract AbstractClause WithClauseProperties(IDictionary<string, IDictionary<string, object>> clause);

        public abstract AbstractClause Build();
    }
}
