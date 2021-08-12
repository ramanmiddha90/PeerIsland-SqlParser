using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeerIsland.SqlQueryGenrator;
using System.IO;

namespace PeerIsland.SqlQuery.UnitTests
{
    [TestClass]
    public class QueryManagerTests
    {
        [TestMethod]
        public void GenerateQueyrFromJsonString()
        {
            var manager = new QueryManager(new SQLGenerator(),null);

            string jsonData = string.Empty;
            var path= System.IO.Directory.GetCurrentDirectory() + "\\Simple.json";
            jsonData = File.ReadAllText(path);

            var result = manager.GenerateQueryFromJson(jsonData);
            Assert.AreEqual(result, "Select distinct EmployeeName,Date From Table1 where Age = 50 Or Age Between[50,10]");
        }
        [TestMethod]
        public void GenerateQueyrFromJsonWithWhereCondition()
        {
            var manager = new QueryManager(new SQLGenerator(), null);

            string jsonData = string.Empty;
            var path = System.IO.Directory.GetCurrentDirectory() + "\\WithWhere.json";
            jsonData = File.ReadAllText(path);

            var result = manager.GenerateQueryFromJson(jsonData);
            Assert.AreEqual(result.Trim(), "Select distinct EmployeeName,Date From Table1 where Age = 50");
        }
        [TestMethod]
        public void GenerateQueyrFromJson_WithWhere_Condition_WithAlias()
        {
            var manager = new QueryManager(new SQLGenerator(), null);

            string jsonData = string.Empty;
            var path = System.IO.Directory.GetCurrentDirectory() + "\\WithAliasWithWhere.json";
            jsonData = File.ReadAllText(path);

            var result = manager.GenerateQueryFromJson(jsonData);
            Assert.AreEqual(result, "Select distinct EmployeeName,Date From Table1 e where Age = 50");
        }
    }
}
