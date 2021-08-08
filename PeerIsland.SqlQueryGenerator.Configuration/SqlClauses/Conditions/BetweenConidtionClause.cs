﻿using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses.Conditions
{
    public class BetweenConidtionClause<T> : BaseCondition
    {
        public string ColumnName { get; set; }
        public T Higher { get; set; }
        public T Lower { get; set; }

        public BetweenConidtionClause() : base("Between")
        {
        }

        public override bool IsValidClause()
        {
            return true;
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
