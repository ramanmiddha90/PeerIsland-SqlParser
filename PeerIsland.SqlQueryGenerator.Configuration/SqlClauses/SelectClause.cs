using System.Collections.Generic;
using System;
using System.Linq;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public class SelectClause : AbstractClause
    {
        private readonly static string SelectClauseType = "Select";

        public bool IsDistinctIncluded { get; set; }

        public IList<string> Columns { get; set; }

        //public SelectClause

        //public SelectClause() { }

        public SelectClause() : base(SelectClauseType)
        {

        }

        public IDictionary<string, IDictionary<string, object>> ClauseSection { get; private set; }
        //public SelectClause(bool IsDistinctIncluded, IList<string> columnList) : base(SelectClauseType)
        //{
        //    this.IsDistinctIncluded = IsDistinctIncluded;
        //    this.Columns = columnList;
        //}

        public override bool IsValidClause()
        {
            return true;
        }

        public override AbstractClause WithClauseProperties(IDictionary<string, IDictionary<string, object>> clauseSection)
        {
            this.ClauseSection = clauseSection;
            return this;

        }

        public override AbstractClause Build()
        {
            try
            {
                var clauseProperties = ClauseSection[ClauseType];

                if (clauseProperties == null || clauseProperties.Count <= 0)
                    throw new InvalidOperationException();

                this.IsDistinctIncluded = Convert.ToBoolean(clauseProperties.Where(t => t.Key == "IsDistinctIncluded").FirstOrDefault().Value);

                this.Columns = (IList<string>)clauseProperties.Where(t => t.Key == "IncludedColumns").FirstOrDefault().Value;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error creating select clause {ex.Message}");
            }
            return this;

        }
    }
}
