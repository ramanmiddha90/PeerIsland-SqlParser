using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public class FromClause : AbstractClause
    {
        public string TableName { get; private set; }

        public string Alias { get; private set; }

        internal FromClause(string type,string tableName, string alias) : base(type)
        {
            this.TableName = tableName;
            this.Alias = alias;
        }

        public override bool IsValidClause()
        {
            return !string.IsNullOrEmpty(TableName);
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
