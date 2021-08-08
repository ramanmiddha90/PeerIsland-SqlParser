using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PeerIsland.Settings.Parser
{
    public class JsonParser
    {
        private static readonly IDictionary<string, object> _data = new SortedDictionary<string, object>(StringComparer.OrdinalIgnoreCase);


        public static IDictionary<string, object> ParseJObject(JObject clauseSection)
        {
            VisitJObject(clauseSection);
            return _data;
        }
        private static void VisitJObject(JObject jObject)
        {
            foreach (var property in jObject.Properties())
            {
                VisitProperty(property);
            }
        }
        private static void VisitProperty(JProperty property)
        {
            VisitToken(property.Value,property.Name);
        }
        private static void VisitToken(JToken token,string PropertyName="")
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    VisitJObject(token.Value<JObject>());
                    break;

                case JTokenType.Array:
                    VisitArray(PropertyName, token.Value<JArray>());
                    break;

                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.String:
                case JTokenType.Boolean:
                case JTokenType.Bytes:
                case JTokenType.Raw:
                case JTokenType.Null:
                    VisitPrimitive(PropertyName, token.Value<JValue>());
                    break;

                default:
                    throw new FormatException();
            }
        }

        private static void VisitArray(string propertyName,JArray array)
        {
            var valueItems = new List<string>();
            JToken token=null;
            for (int index = 0; index < array.Count; index++)
            {
                token = array[index];

                if (token.Type != JTokenType.Object)
                {
                    valueItems.Add(token.Value<string>());
                }
            }
            if (token?.Type != JTokenType.Object &&  (!_data.ContainsKey(propertyName)))
            {
                _data[propertyName] = valueItems;
            }
        }

        private static void VisitPrimitive(string key, JValue data)
        {

            if (_data.ContainsKey(key))
            {
                throw new FormatException();

            }
            _data[key] = data.ToString(CultureInfo.InvariantCulture);
        }

    }
}
