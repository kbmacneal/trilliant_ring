using System;
using Newtonsoft.Json;
using trill.Classes;

namespace trill.Classes {

    public class Feedback {
        public static void RegisterResponse (feedback feedback) {
            DataManager.insert_record (feedback);
        }
    }
}