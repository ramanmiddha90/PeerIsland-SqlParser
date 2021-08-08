using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Collections.Generic;

namespace PeerIsland.SqlQueryGenrator.Builders
{
    public interface IQueryProcessor
    {
         string ProcessSelect(IList<AbstractClause> selectClause);

         string ProcessFrom(IList<AbstractClause> fromClause);

        string ProcessJoins(IList<AbstractClause> JoinClause);

        string ProcessWhere(IList<AbstractClause> JoinClause);

        string ProcessGroups(IList<AbstractClause> selectClause);

        string ProcessHaving(IList<AbstractClause> fromClause);

        string ProcessOrders(IList<AbstractClause> fromClause);

        
    }
}
