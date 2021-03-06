using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using trill.Classes;
using trill.Models;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;

namespace trill.Controllers {

    public class leaderboard
    {
        public string name {get;set;}
        public long credits {get;set;}
    }

    public class stats {
        public int ID { get; set; }
        public List<Controllers.leaderboard> leaderboard {get;set;}

        public static async Task update_stats (stats s) {
            // Open database (create new if file doesn't exist)
            var store = new DataStore ("stats.json");
            // Get employee collection
            var collection = store.GetCollection<stats> ();

            if (collection.AsQueryable ().Count () == 0) {
                await collection.InsertOneAsync (s);

            } else {
                await collection.ReplaceOneAsync (e => e.ID == s.ID, s);
            }

            store.Dispose ();
        }

        public static stats get_stats ()
        {
            // Open database (create new if file doesn't exist)
            var store = new DataStore ("stats.json");
            // Get employee collection
            var collection = store.GetCollection<stats> ();

            stats stats = collection.AsQueryable().FirstOrDefault();

            if(stats == null)
            {
                stats = new stats{
                    leaderboard = new List<leaderboard> {new leaderboard {name="No stats at this time",credits=0}}
                };
            }

            store.Dispose();

            return stats;


        }

    }

    public class key {
        public int ID { get; set; }
        public string api_key { get; set; }

        public static async Task<key> new_key () {
            // Open database (create new if file doesn't exist)
            var store = new DataStore ("api.json");

            key k = new key ();

            var key = new byte[32];

            using (var generator = System.Security.Cryptography.RandomNumberGenerator.Create ()) {
                generator.GetBytes (key);
                k.api_key = Convert.ToBase64String (key);
            }

            // Get employee collection
            var collection = store.GetCollection<key> ();

            await collection.InsertOneAsync (k);

            store.Dispose ();

            return k;
        }

        public static key get_key (string api_key) {
            // Open database (create new if file doesn't exist)
            var store = new DataStore ("api.json");
            // Get employee collection
            var collection = store.GetCollection<key> ();

            key k = collection.AsQueryable ().FirstOrDefault (e => e.api_key == api_key);

            store.Dispose ();

            return k;
        }
    }
    public class apiController : Controller {

        [HttpPost]
        public ActionResult Updateleaderboard ([FromBody] apiModel model) {

            BadRequestResult bad = new BadRequestResult();

            // apiModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<apiModel>(raw);

            if (key.get_key (model.api_key) == null) {
                return bad;
            }

            stats s = new stats{
                ID = 0,
                leaderboard = model.leaderboard
            };

            stats.update_stats(s).GetAwaiter().GetResult();

            OkResult ok = new OkResult();

            return ok;
        }

    }
}