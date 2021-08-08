using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Text;

namespace PeerIsland.SqlQueryGenrator.Query
{
    public class FromBuilder : Query
    {
        /// <summary>
        /// Builder to generate string for conditiona clause
        /// </summary>
        /// <param name="conditionStringBuilder">Builder to append string</param>
        /// <param name="clause">From Appender. Use this for From clause only.</param>
        /// <returns></returns>
        public override StringBuilder Build(StringBuilder fromBuilder, AbstractClause clause)
        {
            var fromClause = (FromClause)clause;

            fromBuilder.Append($"From {fromClause.TableName}");

            if (!string.IsNullOrEmpty(fromClause.Alias))
                fromBuilder.Append($" {fromClause.Alias}");
            return fromBuilder;
        }

    }
}
