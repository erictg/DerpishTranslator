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

        List<Word> words;

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
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            foreach (string s in letters)
            {
                var thigny = mongoDB.GetCollection<BsonDocument>(s);
                List<BsonDocument> l = new List<BsonDocument>();
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

    }
}
