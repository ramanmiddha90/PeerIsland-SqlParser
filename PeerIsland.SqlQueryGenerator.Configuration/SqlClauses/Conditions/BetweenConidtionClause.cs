using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses.Conditions
{
    public class BetweenConidtionClause : AbstractCondition
    {
        
        public string Low  { get; set; }
        public string High { get; set; }

        public IDictionary<string, IDictionary<string, object>> ClauseSection { get; private set; }
        public BetweenConidtionClause() : base("BETWEEN")
        {
        }

        public override bool IsValidClause()
        {
            return true;
        }


        public override AbstractClause WithClauseProperties(IDictionary<string, IDictionary<string, object>> clause)
        {
            this.ClauseSection = clause;
            return this;
        }

        public override AbstractClause Build()
        {
            try
            {
                var clauseProperties = ClauseSection[ClauseType];

                if (clauseProperties == null || clauseProperties.Count <= 0)
                    throw new InvalidOperationException();

                this.FieldName = PropertyBinder.BindProperty<string>("FieldName", clauseProperties);
                this.IsOR = PropertyBinder.BindBoolProperty("IsOr", clauseProperties);
                this.High = PropertyBinder.BindProperty<string>("High", clauseProperties);
                this.Low = PropertyBinder.BindProperty<string>("Low", clauseProperties);
                this.BuilderType = "Between";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error creating select clause {ex.Message}");
            }
            return this;
        }
    }
}
