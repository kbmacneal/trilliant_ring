using System;
using Newtonsoft.Json;
using trill.Classes;

namespace trill.Classes{

    public class Question
    {
        public static void RegisterResponse(question question)
        {
            DataManager.insert_record(question);
        }
    }
}