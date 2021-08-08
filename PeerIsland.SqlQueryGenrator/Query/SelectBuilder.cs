using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.SqlQueryGenrator.Query
{
    public class SelectBuilder : Query
    {
        public override StringBuilder Build(StringBuilder selectBuilder,AbstractClause clause)
        {
            var selectClause = (SelectClause)clause;
        
            selectBuilder.Append("Select");

            if (selectClause.IsDistinctIncluded)
            {
                selectBuilder.Append(Space());
                selectBuilder.Append("distinct");
            }

            if (selectClause.Columns.Count > 0)
            {
                selectBuilder.Append(Space());
                selectBuilder.Append(string.Join(',', selectClause.Columns));
            }
            else
            {
                selectBuilder.Append(Space());
                selectBuilder.Append("*");
            }
            return selectBuilder;
        }

    }
}
