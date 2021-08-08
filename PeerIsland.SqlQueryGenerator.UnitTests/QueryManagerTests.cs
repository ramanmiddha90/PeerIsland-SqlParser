using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeerIsland.SqlQueryGenrator;
using System.IO;
using System.Reflection;

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
            var path= System.IO.Directory.GetCurrentDirectory() + "\\Sample.json";
            jsonData = File.ReadAllText(path);

            var result = manager.GenerateQueryFromJson(jsonData);
            Assert.AreEqual(result, "Select distinct EmployeeName,Date From Table1");
        }
    }
}
