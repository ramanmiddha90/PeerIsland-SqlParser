using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.SqlQueryGenerator.Configuration
{
    public interface IConfigParser
    {
        public void Parse(QueryConfiguration configuraion);
    }
}
