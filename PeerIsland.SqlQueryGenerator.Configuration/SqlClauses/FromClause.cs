using System;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{

    public class FromClause : AbstractClause
    {
        private readonly static string FromClauseType = "From";
        public string TableName { get; private set; }

        public string Alias { get; private set; }

        public IDictionary<string, IDictionary<string, object>> ClauseSection { get; private set; }

        public FromClause() : base(FromClauseType)
        {

        }

        public override bool IsValidClause()
        {
            return !string.IsNullOrEmpty(TableName);
        }

        public override AbstractClause WithClauseProperties(IDictionary<string, IDictionary<string, object>> clauseProperties)
        {
            this.ClauseSection = clauseProperties;
            return this;
        }

        public override AbstractClause Build()
        {
            try
            {
                var clauseProperties = ClauseSection[ClauseType];

                if (clauseProperties == null || clauseProperties.Count <= 0)
                    throw new InvalidOperationException();

                this.TableName = PropertyBinder.BindProperty<string>("TableName", clauseProperties);
                this.Alias = PropertyBinder.BindProperty<string>("Alias", clauseProperties);
              
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error creating select clause {ex.Message}");
            }
            return this;

        }
    }
}
