using System;
using System.Collections.Generic;
using System;
using System.Linq;
namespace PeerIsland.SqlQueryGenerator.Configuration
{
   public static class PropertyBinder
    {
        public static T BindProperty<T>(string PropertyKey, IDictionary<string, IDictionary<string, object>> ClauseSection)
        {
            if (ClauseSection.ContainsKey(PropertyKey))
                return (T)ClauseSection.Where(t => t.Key == PropertyKey).FirstOrDefault().Value;

            return default(T);
        }
    }
}
