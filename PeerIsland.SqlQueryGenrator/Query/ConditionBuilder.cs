using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Text;

namespace PeerIsland.SqlQueryGenrator.Query
{
    public class ConditionBuilder : Query
    {
        public override StringBuilder Build(StringBuilder conditionStringBuilder, AbstractClause clause)
        {
            var conidtionClause = (BasicConidtionClause)clause;

            conditionStringBuilder.Append($" {conidtionClause.FieldName} {Operator(conidtionClause.OperatorType)} {conidtionClause.FieldValue}");

            return conditionStringBuilder;
        }
    }
}
