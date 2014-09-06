namespace Chat.Data
{
    using MongoDB.Driver;

    public class ChatDB : IChatDB
    {
        private MongoDatabase database;

        public ChatDB()
        {
            var connectionString = ChatSettings.Default.ChatConnectionString;
            var mongoClient = new MongoClient(connectionString);
            var server = mongoClient.GetServer();

            var database = ChatSettings.Default.DatabaseName;
            this.Database = server.GetDatabase(database);
        }

        public MongoDatabase Database
        {
            get
            {
                return this.database;
            }

            private set
            {
                this.database = value;
            }
        }
    }
}
