using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_MongoDB {
    class BaseRepository<T> {

        // connectDB class
        
        private IMongoCollection<T> collection;

        public BaseRepository(IMongoDatabase mongoDatabase, string collectionName) {
            this.collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public List<T> Find() => collection.Find(_ => true).ToList();

        public List<T> Find(FilterDefinition<T> filters) => collection.Find(filters).ToList();

        public Task InsertOneAsync(T doc) => collection.InsertOneAsync(doc);

        public T FindOneAndDelete(FilterDefinition<T> filter) => collection.FindOneAndDelete(filter);           

        public T FindOneAndUpdate(FilterDefinition<T> filter, UpdateDefinition<T> update) => collection.FindOneAndUpdate(filter, update);
    }
}
