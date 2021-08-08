using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Text;

namespace PeerIsland.SqlQueryGenrator.Query
{
    public class FromBuilder : Query
    {
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
