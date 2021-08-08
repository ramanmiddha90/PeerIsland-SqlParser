using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public class InClause : AbstractClause
    {
        public string ColumnName { get; set; }

        public IList<string> Values  { get; set; }

        internal InClause(string type,string columnName, IList<string> values) : base(type)
        {
            this.ColumnName = columnName;
            this.Values = values;
        }

        public override bool IsValidClause()
        {
            return !string.IsNullOrEmpty(ColumnName) && Values != null && Values.Count > 0;
        }

        public override AbstractClause WithClauseProperties(IDictionary<string, IDictionary<string, object>> clause)
        {
            throw new NotImplementedException();
        }

        public override AbstractClause Build()
        {
            throw new NotImplementedException();
        }
    }
}
