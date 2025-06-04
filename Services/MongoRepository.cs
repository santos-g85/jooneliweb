using jooneliweb.Services.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;

namespace jooneliweb.Services
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(MongoDbContext dbContext)
        {
            var collectionName = typeof(T).Name.Replace("Model", "");
            _collection = dbContext.GetCollection<T>(collectionName);
        }

        //get all data from collection
        public async Task<List<T>> GetAllAsync() =>
           await _collection.Find(_ => true).ToListAsync();


        //get data by id
        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        //create a new entity in the collection
        public async Task CreateAsync(T entity) =>
           await _collection.InsertOneAsync(entity);

        //update an existing entity in the collection
        public async Task UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await _collection.ReplaceOneAsync(filter, entity);
        }

        //delete an entity from the collection by id
        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await _collection.DeleteOneAsync(filter);
        }
    }
}
