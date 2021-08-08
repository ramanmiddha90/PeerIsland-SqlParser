namespace PeerIsland.SqlQueryGenerator.Configuration
{
    public interface IConfigParser
    {
        /// <summary>
        /// Implemnet this method in custom configuration provider
        /// </summary>
        /// <param name="configuraion"></param>
        public void Parse(QueryConfiguration configuraion);
    }
}
