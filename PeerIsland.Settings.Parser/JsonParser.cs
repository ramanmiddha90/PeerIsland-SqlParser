using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PeerIsland.Settings.Parser
{
    /// <summary>
    /// Json Parser
    /// Enhance this class to handle all scenarios
    /// </summary>
    public class JsonParser
    {
        private readonly IDictionary<string, object> _data = new SortedDictionary<string, object>(StringComparer.OrdinalIgnoreCase);


        public  IDictionary<string, object> ParseJObject(JObject clauseSection)
        {
            VisitJObject(clauseSection);
            return _data;
        }
        private void VisitJObject(JObject jObject)
        {
            foreach (var property in jObject.Properties())
            {
                VisitProperty(property);
            }
        }
        private  void VisitProperty(JProperty property)
        {
            VisitToken(property.Value,property.Name);
        }
        private void VisitToken(JToken token,string PropertyName="")
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

        private void VisitArray(string propertyName,JArray array)
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

        private  void VisitPrimitive(string key, JValue data)
        {

            if (_data.ContainsKey(key))
            {
                throw new FormatException();

            }
            _data[key] = data.ToString(CultureInfo.InvariantCulture);
        }

    }
}
