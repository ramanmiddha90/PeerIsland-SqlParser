using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIsland.SqlQueryGenrator.Query
{
    public abstract class Query
    {
        public abstract StringBuilder Build(StringBuilder InutBuilder, AbstractClause clause);

        public string Space()
        {
            return " ";
        }
        public string Or()
        {
            return "or";

        }

        public string And()
        {
            return "And";

        }


        public string GreaterThen()
        {
            return ">";

        }




        public string LessThen()
        {
            return "<";

        }

        public string Equal()
        {
            return "=";

        }

        public string NotEqual()
        {
            return "!=";

        }


        public string LessThenEqual()
        {
            return "<=";

        }


        public string GreaterThenEqual()
        {
            return ">=";

        }



        public string Operator(OperatorTypes type)
        {
            switch (type)
            {
                case OperatorTypes.Equal:
                    return Equal();
                case OperatorTypes.LessThan:
                    return Equal();
                case OperatorTypes.GreaterThan:
                    return Equal();
                case OperatorTypes.NotEqual:
                    return Equal();
                default:
                    return Equal();
            }
        }
    }
}
