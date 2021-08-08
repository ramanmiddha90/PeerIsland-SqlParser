﻿using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration
{
    public class ClauseHandlerFactory
    {
       static IDictionary<string, Type> Mapping = new Dictionary<string, Type>()
            {
            {"SELECT", typeof(SelectClause) },
            {"FROM", typeof(FromClause) },
            {"IN", typeof(InClause) },
            {"GROUPBY", typeof(InClause) },
            {"JOIN", typeof(JoinClause) }
            };


        public static AbstractClause InitializeClause(string clauseType, IDictionary<string, IDictionary<string, object>> clause)
        {
            if (Mapping.ContainsKey(clauseType.ToUpper()))
            {
                // use the activator to generically create an instance
                return ((AbstractClause)Activator.CreateInstance(Mapping[clauseType.ToUpper()]))
                    .WithClauseProperties(clause)
                    .Build();
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
