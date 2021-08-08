using System;

namespace PeerIsland.SqlQueryGenrator.QueryGenerators
{
    public interface IQueryGenerator
    {
        public String Generate(string Json);
    }
}
