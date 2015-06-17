#region USINGS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using TranslatorBackend.framework;
using TranslatorBackend.framework.objects;
using TranslatorBackend.framework.translation;
using TranslatorBackend.framework.mongoControl;
using System.Web.Script.Serialization;
#endregion
namespace TranslatorBackend
{
    public class TranslationManager
    {
        EnglishToDerpish e2d;
        DerpishToEnglish d2e;

        public  Dictionary<string, List<Word>> words;

        IMongoDatabase mongoDB;
        

        public TranslationManager()
        {
            initMongo();
            
        }

        private void initMongo()
        {
            var client = new MongoClient("mongodb://erictg97:sabrefan67@ds031932.mongolab.com:31932/colorsgame");
            mongoDB = client.GetDatabase("colorsgame");
        }

        public void resetWordList()
        {
            words.Clear();
            words = new Dictionary<string,List<Word>>();
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "PHRASES" };
            foreach (string s in letters)
            {
                words.Add(s, new List<Word>());
                var thigny = mongoDB.GetCollection<BsonDocument>(s);
                List<BsonDocument> docs = new List<BsonDocument>();
                thigny.Find(new BsonDocument()).ForEachAsync(d => docs.Add(d));
                foreach(BsonDocument d in docs){
                    Word w = new JavaScriptSerializer().Deserialize<Word>(d.ToJson());
                    words[s].Add(w);
                }

            }
        }

        public void addWord(Word word)
        {
            string x = word.EnglishWord.Substring(0,1);
            var wordCollection = mongoDB.GetCollection<BsonDocument>(x.ToUpper());
            string jsonString = new JavaScriptSerializer().Serialize(word);
            BsonDocument doc = BsonDocument.Parse(jsonString);
            wordCollection.InsertOneAsync(doc);
        }

        public void addPhrase(Word word)
        {
            var wordCollection = mongoDB.GetCollection<BsonDocument>("PHRASES");
            string jsonString = new JavaScriptSerializer().Serialize(word);
            BsonDocument doc = BsonDocument.Parse(jsonString);
            wordCollection.InsertOneAsync(doc);
        }

    }
}
