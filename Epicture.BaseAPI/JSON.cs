using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Epicture.BaseAPI
{
    public static class JSON
    {
        public static string Serialize(object input)
        {
            return JsonConvert.SerializeObject(input);
        }

        public static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}