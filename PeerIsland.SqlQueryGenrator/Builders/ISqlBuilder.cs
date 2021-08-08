using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.SqlQueryGenrator.Builders
{
    public interface IBuilder
    {
        string BuildQuery(IList<AbstractClause> clauses);
    }
}
