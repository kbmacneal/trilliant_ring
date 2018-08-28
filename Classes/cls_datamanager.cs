using System.IO;
using JsonFlatFileDataStore;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace trill.Classes
{
    public class DataManager
    {
        public class password_hash
        {
            public byte[] salt { get; set; }
            public string password { get; set; }

            public password_hash()
            {
                // generate a 128-bit salt using a secure PRNG
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                this.salt = salt;
            }
            public password_hash(byte[] salt)
            {

                this.salt = salt;
            }
        }
        private static password_hash HashPassword(string plaintext)
        {
            password_hash hash = new password_hash();

            // derive a 256-bit subkey (use HMACSHA256 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plaintext,
                salt: hash.salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hash;
        }

        private static password_hash HashPassword(string plaintext, byte[] salt)
        {
            password_hash hash = new password_hash(salt);

            // derive a 256-bit subkey (use HMACSHA256 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plaintext,
                salt: hash.salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hash;
        }

        public static void insert_record(response response)
        {
            // Open database (create new if file doesn't exist)
            var store = new DataStore("data.json");

            // Get employee collection
            var collection = store.GetCollection<response>();

            collection.InsertOne(response);

            store.Dispose();
        }

        public static void insert_record(question question)
        {
            // Open database (create new if file doesn't exist)
            var store = new DataStore("data.json");

            // Get employee collection
            var collection = store.GetCollection<question>();

            collection.InsertOne(question);

            store.Dispose();
        }

        public static void insert_record(feedback feedback)
        {
            // Open database (create new if file doesn't exist)
            var store = new DataStore("data.json");

            // Get employee collection
            var collection = store.GetCollection<feedback>();

            collection.InsertOne(feedback);

            store.Dispose();
        }
    }
}
