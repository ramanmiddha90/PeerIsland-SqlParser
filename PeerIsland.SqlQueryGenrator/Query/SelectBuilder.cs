using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Text;

namespace PeerIsland.SqlQueryGenrator.Query
{
    /// <summary>
    /// Builder to generate string for select clause
    /// </summary>
    /// <param name="selectBuilder">Builder to append string</param>
    /// <param name="clause">Select Appender. Use this for Select clause only.</param>
    /// <returns>selectBuilder</returns>
    public class SelectBuilder : Query
    {
        public override StringBuilder Build(StringBuilder selectBuilder,AbstractClause clause)
        {
            var selectClause = (SelectClause)clause;
        
            selectBuilder.Append("Select");

            if (selectClause.IsDistinctIncluded)
            {
                selectBuilder.Append($" distinct");
            }

            if (selectClause.Columns.Count > 0)
            {
                selectBuilder.Append($" {string.Join(',', selectClause.Columns)}");
            }
            else
            {
                selectBuilder.Append(" *");
            }
            return selectBuilder;
        }

    }
}
