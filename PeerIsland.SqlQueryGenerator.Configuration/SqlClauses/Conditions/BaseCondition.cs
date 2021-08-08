namespace PeerIsland.SqlQueryGenerator.Configuration.SqlClauses
{
    public abstract class BaseCondition : AbstractClause
    {
        public override abstract bool IsValidClause();

        internal BaseCondition(string type) : base(type)
        {

        }


    }
}
