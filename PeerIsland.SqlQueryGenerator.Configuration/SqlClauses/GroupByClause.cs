using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public class GroupByClause : AbstractClause
    {
        public IList<string> GroupByColumns { get; private set; }

        internal GroupByClause(string type, IList<string> groupByClause) : base(type)
        {
            this.GroupByColumns = groupByClause;
        }
        public override bool IsValidClause()
        {
            return GroupByColumns != null && GroupByColumns.Count > 0;
        }

        public override AbstractClause WithClauseProperties(IDictionary<string, IDictionary<string, object>> clause)
        {
            throw new System.NotImplementedException();
        }

        public override AbstractClause Build()
        {
            throw new System.NotImplementedException();
        }
    }
}
