namespace Chat.Data
{
    using MongoDB.Driver;

    public interface IChatDB
    {
        MongoDatabase Database { get; }
    }
}
