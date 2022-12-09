using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace C_Sharp_MongoDB {
    class Users {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("password")]
        public string password { get; set; }

        public Users (string name, string email, string password) {
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}
