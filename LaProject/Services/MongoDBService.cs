using LaProject.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaProject.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Playlist> playlistCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            playlistCollection = database.GetCollection<Playlist>(mongoDBSettings.Value.CollectionName);
        }

        public async Task CreateAsync(Playlist playlist)
        {
            await playlistCollection.InsertOneAsync(playlist);
            return;
        }
        public async Task<List<Playlist>> GetAsync()
        {
            return await playlistCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddToPlaylistAsync(string id, string movieId)
        {
            FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("id", id);
            UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("movieId", movieId);
            await playlistCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("id", id);
            await playlistCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
