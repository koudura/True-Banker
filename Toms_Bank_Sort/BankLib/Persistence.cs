using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Linq;

namespace BankLib
{
    public class Database
    {

        IMongoClient client;
        IMongoDatabase db;
        IMongoCollection<AccountDoc> collection;

        public Database(string client, string db, string collection)
        {
            this.client = new MongoClient();
            this.db = this.client.GetDatabase(db);
            this.collection = this.db.GetCollection<AccountDoc>(collection);
        }

        /// <summary>
        /// Inserts the specified acc into database.
        /// </summary>
        /// <param name="acc">The account.</param>
        public void Insert(Account acc)
        {
            collection.InsertOne(acc.ToAccountDoc());
        }


        /// <summary>
        /// Retrieves the specified Account based on its Account number and pin.
        /// </summary>
        /// <param name="accnum">The accnum.</param>
        /// <param name="pin">The pin.</param>
        /// <returns >The Account</returns>
        public Account Retrieve(string accnum, string pin)
        {
            var builder = Builders<AccountDoc>.Filter;
            var filter = builder.Eq("accnum", accnum) & builder.Eq("pin", pin);
            //var filter = new BsonDocument("accnum", accnum);
            var doc = collection.Find(filter).FirstOrDefault();
            if(doc == null)
            {
                return null;
            }
            if ( doc.Type == 1)
            {
                SavingsAccount acc = new SavingsAccount(doc);
                return acc;
            }
            else
            {
                CurrentAccount acc = new CurrentAccount(doc);
                return acc;
            }
      
        }

        /// <summary>
        /// Updates the Account details.
        /// </summary>
        /// <param name="accnum">The account number.</param>
        /// <param name="acc">The replacement account.</param>
        public void Update(string accnum, Account acc)
        {
            var builder = Builders<AccountDoc>.Filter;
            var filter = builder.Eq("accnum", accnum);
            collection.ReplaceOne(filter, acc.ToAccountDoc());
        }


    }

    public class AccountDoc
    {
      
        public AccountDoc(Account acc, int type)
        {
            AccNum = acc.AccNum;
            Name = acc.Name;
            Pin = acc.Pin;
            Balance = acc.Balance;
            Type = type;
            _id = acc.Id;
        }
        [BsonId]
        public ObjectId _id;

        [BsonElement("accnum")]
        public string AccNum { get; set; }

        [BsonElement("balance")]
        public int Balance { get; set; }

        [BsonElement("pin")]
        public string Pin { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public int Type { get; set; }
    }
}
