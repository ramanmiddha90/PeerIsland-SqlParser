using System.Collections.Generic;
using System.Linq;
namespace PeerIsland.SqlQueryGenerator.Configuration
{
    public static class PropertyBinder
    {
        /// <summary>
        /// Use this property to bind from dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="PropertyKey"></param>
        /// <param name="ClauseSection"></param>
        /// <returns></returns>
        public static T BindProperty<T>(string PropertyKey, IDictionary<string, object> ClauseSection)
        {
            if (ClauseSection.ContainsKey(PropertyKey))
                return (T)ClauseSection.Where(t => t.Key == PropertyKey).FirstOrDefault().Value;

            return default(T);
        }
    }
}
