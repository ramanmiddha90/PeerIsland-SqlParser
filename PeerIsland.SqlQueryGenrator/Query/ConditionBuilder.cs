using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Text;

namespace PeerIsland.SqlQueryGenrator.Query
{
    public class ConditionBuilder : Query
    {
        /// <summary>
        /// Builder to generate string for conditional clause
        /// </summary>
        /// <param name="conditionStringBuilder">Builder to append string</param>
        /// <param name="clause">Conditional Appender. Use this for Conditioanl clause only.</param>
        /// <returns>StringBuilder</returns>
        public override StringBuilder Build(StringBuilder conditionStringBuilder, AbstractClause clause)
        {
            var conidtionClause = (BasicConidtionClause)clause;

            conditionStringBuilder.Append($" {conidtionClause.FieldName} {Operator(conidtionClause.OperatorType)} {conidtionClause.FieldValue}");

            return conditionStringBuilder;
        }
    }
}
