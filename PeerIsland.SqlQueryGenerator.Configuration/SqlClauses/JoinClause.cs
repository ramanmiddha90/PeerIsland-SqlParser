using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses.Enums;
using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public class JoinClause : AbstractClause
    {
        public string ParentTableName { get; set; }

        public string ParentTableColumn { get; set; }

        public string TableName { get; set; }

        public string TableColumn { get; set; }

        public OperatorTypes Operator { get; set; }

        internal JoinClause(string type, string parentTableName, string parentTableColumn, string tableName, string TableColumn, OperatorTypes operatorType) : base(type)
        {
            this.ParentTableName = parentTableName;
            this.ParentTableColumn = parentTableColumn;
            this.TableName = tableName;
            this.TableColumn = TableColumn;
            this.Operator = operatorType;
        }


        public override bool IsValidClause()
        {
            //validate join clause here
            return true;
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
