using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public class BasicConidtionClause : BaseCondition
    {
        public OperatorTypes OperatorType { get; set; }

        public string FieldName { get; set; }

        public string FieldValue { get; set; }

        internal BasicConidtionClause(OperatorTypes operatorType,string fieldName, string fieldValue) : base("Operator")
        {
            this.OperatorType = operatorType;
            this.FieldName = fieldName;
            this.FieldValue = fieldValue;

        }

        public override bool IsValidClause()
        {
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
