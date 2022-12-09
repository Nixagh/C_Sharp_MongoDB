using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_MongoDB {
    class ConnectionDB {
        private static string uri = "mongodb+srv://Nixagh:123@productsdb.t4fkl0p.mongodb.net/?retryWrites=true&w=majority";
        private static MongoClient mongoClient = new MongoClient(uri);
        private IMongoDatabase mongoDatabase = mongoClient.GetDatabase("test");

        private static ConnectionDB _instance = null;

        public static ConnectionDB getInstance() {
            if (_instance == null)
                _instance = new ConnectionDB();
            return _instance;
        }

        private ConnectionDB() { }

        public IMongoDatabase getDataBase() {
            return this.mongoDatabase;
        }
    }
}
