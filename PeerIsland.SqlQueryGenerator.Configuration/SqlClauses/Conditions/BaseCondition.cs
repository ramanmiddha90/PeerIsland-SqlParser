using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses.Enums;

namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public abstract class AbstractCondition : AbstractClause 
    {

        public string FieldName { get; set; }

        public string BuilderType { get; set; }

        public bool IsOR { get; set; }

        public override abstract bool IsValidClause();

        public AbstractCondition(string type) : base(type)
        {

        }
    }
}
