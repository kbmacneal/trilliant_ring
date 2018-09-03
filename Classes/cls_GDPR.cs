using System;
using Newtonsoft.Json;
using trill.Classes;

namespace trill.Classes {

    public class GDPR {
        public static void RegisterResponse (response response) {
            DataManager.insert_record (response);
        }
    }
}