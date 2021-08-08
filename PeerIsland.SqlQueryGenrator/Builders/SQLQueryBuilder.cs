using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using PeerIsland.SqlQueryGenrator.Builders;
using PeerIsland.SqlQueryGenrator.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PeerIsland.SqlQueryGenrator
{
    public class SqlQueryBuilder : IBuilder, IQueryProcessor
    {
        private readonly StringBuilder sqlQuery = new StringBuilder();
        public string BuildQuery(IList<AbstractClause> clauses)
        {
            var results = new[]
            {
                    this.ProcessSelect(clauses),
                    this.ProcessFrom(clauses),
                    this.ProcessJoins(clauses),
                    this.ProcessWhere(clauses),
                    this.ProcessGroups(clauses),
                    this.ProcessHaving(clauses),

            }
            .Where(result => !string.IsNullOrEmpty(result))
            .ToList();

            return string.Join(" ", results).Trim();
        }


        public string ProcessSelect(IList<AbstractClause> clauses)
        {
            var selectBuilder = new StringBuilder();
            var selectClauses = clauses.Where(t => t.ClauseType.ToUpper() == "SELECT").ToList();

            if (selectClauses == null || selectClauses.Count() < 0)
            {
                throw new FormatException("Invalid Configuration.Select clause missing.");
            }

            if (selectClauses.Count > 1)
            {
                throw new FormatException("Invalid Configuration.Multiple select clause found.");

            }

            return new SelectBuilder().Build(selectBuilder, selectClauses.First()).ToString();
        }
        public string ProcessFrom(IList<AbstractClause> clauses)
        {

            var fromBuilder = new StringBuilder();
            var selectClauses = clauses.Where(t => t.ClauseType.ToUpper() == "FROM").ToList();

            if (selectClauses == null || selectClauses.Count() < 0)
            {
                throw new FormatException("Invalid Configuration.From clause missing.");
            }
            var fromQuery = new FromBuilder().Build(fromBuilder, selectClauses.First()).ToString();
            return fromQuery;


        }

        public string ProcessWhere(IList<AbstractClause> clauses)
        {
            var fromBuilder = new StringBuilder();
            var selectClauses = clauses.Where(t => t.ClauseType.ToUpper() == "CONDITION").ToList();

            if (selectClauses != null && selectClauses.Count() > 0)
            {
                fromBuilder.Append("where");
                var conditionBuilder = new ConditionBuilder();
                selectClauses.ForEach(x => conditionBuilder.Build(fromBuilder, x));
            }

            return fromBuilder.ToString();

        }
        public string ProcessGroups(IList<AbstractClause> clauses)
        {
            return string.Empty;
        }

        public string ProcessHaving(IList<AbstractClause> clauses)
        {
            return string.Empty;
        }

        public string ProcessJoins(IList<AbstractClause> clauses)
        {
            return string.Empty;
        }

        public string ProcessOrders(IList<AbstractClause> clauses)
        {
            return string.Empty;
        }


    }
}
