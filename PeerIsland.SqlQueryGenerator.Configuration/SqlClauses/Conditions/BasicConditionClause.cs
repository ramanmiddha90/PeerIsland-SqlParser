using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses.Enums;
using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public class BasicConidtionClause : AbstractCondition
    {
        public OperatorTypes OperatorType { get; set; }
        public string FieldValue { get; set; }

        public BasicConidtionClause() : base("Condition")
        {
        }
        public IDictionary<string, IDictionary<string, object>> ClauseSection { get; private set; }
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
                var clauseProperties = ClauseSection[ClauseType.ToUpper()];

                if (clauseProperties == null || clauseProperties.Count <= 0)
                    throw new InvalidOperationException();

                this.FieldName = PropertyBinder.BindProperty<string>("FieldName", clauseProperties);
                if (string.IsNullOrEmpty(FieldName))
                    throw new FormatException("FieldName missing");

                this.FieldValue = PropertyBinder.BindProperty<string>("FieldValue", clauseProperties);

                this.IsOR = PropertyBinder.BindBoolProperty("IsOr", clauseProperties);

                if (string.IsNullOrEmpty(FieldValue))
                    throw new FormatException("FieldValue missing");

                if(Enum.TryParse(PropertyBinder.BindProperty<string>("Operator", clauseProperties), out OperatorTypes operatorType))
                    this.OperatorType = operatorType;
                else
                    throw new FormatException("FieldValue missing");

                this.BuilderType = "Condition";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error creating select clause {ex.Message}");
            }
            return this;
        }
    }
}
