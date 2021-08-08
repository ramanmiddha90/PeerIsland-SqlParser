using Newtonsoft.Json.Linq;
using PeerIsland.SqlQueryGenerator.Configuration;
using PeerIsland.SqlQueryGenerator.Configuration.SqlClauses;
using System.Collections.Generic;

namespace PeerIsland.Settings.Parser
{
    public class JsonStringParser : IConfigParser
    {
        private string InputJson;
        public JsonStringParser(string Json)
        {
            InputJson = Json;
        }
        public void Parse(QueryConfiguration configuraion)
        {
            configuraion.Clauses = GenerateClausesFromJson();

        }

        //Start json parsing here
        public IList<AbstractClause> GenerateClausesFromJson()
        {
            var rootObject = JObject.Parse(InputJson);
            var clauses = new List<AbstractClause>();
            foreach (var column in rootObject.SelectToken("columns").Value<JArray>())
            {
                AbstractClause sqlClause;
                var clauseType = column.SelectToken("Type").Value<string>();
                var properties = new Dictionary<string, IDictionary<string, object>>();
                properties.Add(clauseType, JsonParser.ParseJObject((JObject)column) as IDictionary<string, object>);
                sqlClause = ClauseHandlerFactory.InitializeClause(clauseType, properties);
                clauses.Add(sqlClause);
            }
            return clauses;
        }
    }
}
