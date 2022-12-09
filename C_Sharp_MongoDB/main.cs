using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;


namespace C_Sharp_MongoDB {
    public partial class main : Form {
        /*        static string uri = "mongodb+srv://Nixagh:123@productsdb.t4fkl0p.mongodb.net/?retryWrites=true&w=majority";
                static MongoClient mongoClient = new MongoClient(uri);
                static IMongoDatabase mongoDatabase = mongoClient.GetDatabase("test");*/
        /*static IMongoCollection<Users> collection = mongoDatabase.GetCollection<Users>("users");*/
        BaseRepository<Users> userRepository = new BaseRepository<Users>(ConnectionDB.getInstance().getDataBase(), "users");

        public main() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Environment.Exit(0); 
        }

        void readAllDocument() {
            /*FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(u => u.name, "new");*/
            FilterDefinition<Users> filter = Builders<Users>.Filter.Empty;
            List<Users> list = userRepository.Find(filter);
            dgvUsers.DataSource = list;
        }

        private void Form1_Load(object sender, EventArgs e) {
            readAllDocument();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            Users user = new Users(txtName.Text, txtEmail.Text, txtPass.Text);
            userRepository.InsertOneAsync(user);
            MessageBox.Show("Insert");
            readAllDocument ();           
        }

        void update(Users user) {
            var filter = new BsonDocument("name", "new");
            var filters = Builders<Users>.Filter.Eq("name", "new");
        }
        void delete(Users user) {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Where(u => u.name == user.name);
            userRepository.FindOneAndDelete(filter);
        }
    }
}   
