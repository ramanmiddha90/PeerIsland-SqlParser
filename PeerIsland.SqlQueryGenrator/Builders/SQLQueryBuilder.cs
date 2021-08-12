using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using PeerIsland.SqlQueryGenrator.Builders;
using PeerIsland.SqlQueryGenrator.AbstractBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace PeerIsland.SqlQueryGenrator
{
    /// <summary>
    /// Processor to process all clauses and generate sql 
    /// </summary>
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

        public Query GetConditionalBuilder(string builderType)
        {
            //{
            //    var builderTypeFullName = builderType + "Builder";
            //    Type type = Type.GetType(builderTypeFullName);
            //    if (type != null)
            //        return (Query)Activator.CreateInstance(type);
            //    foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            //    {
            //        type = asm.GetType(builderTypeFullName);
            //        if (type != null)
            //            return (Query)Activator.CreateInstance(type);
            //    }
            //    return null;
            var builderTypeFullName = "PeerIsland.SqlQueryGenrator.AbstractBuilder." + builderType + "Builder";
          return (Query)typeof(Query).Assembly.CreateInstance(builderTypeFullName);

        }

        public string ProcessWhere(IList<AbstractClause> clauses)
        {
            var fromBuilder = new StringBuilder();
            var selectClauses = clauses.Where(t => typeof(AbstractCondition).IsAssignableFrom(t.GetType())).ToList();

            if (selectClauses != null && selectClauses.Count() > 0)
            {
                fromBuilder.Append("where");
                var count = 0;
                selectClauses.ForEach(x =>
                {
                    var conditonClause = ((AbstractCondition)x);
                    var builder = GetConditionalBuilder(conditonClause.BuilderType);
                    builder.Build(fromBuilder, x);
                    if (count < selectClauses.Count -1)
                    {
                        if (conditonClause.IsOR)
                            fromBuilder.Append(" Or");
                        else
                            fromBuilder.Append(" And");
                    }
                    count++;
                });
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
