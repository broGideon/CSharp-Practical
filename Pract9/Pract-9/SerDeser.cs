using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pract_9
{
    static public class SerDeser
    {
        public static void Serialize(List<HotKey> hotKeys, string path)
        {
            string json = JsonConvert.SerializeObject(hotKeys);
            File.WriteAllText(path, json);
        }
        public static List<HotKey> Deserialize(string path)
        {
            try
            {
            string json = File.ReadAllText(path);
            List<HotKey> hotKey = JsonConvert.DeserializeObject<List<HotKey>>(json);
            return hotKey;
            }
            catch 
            {
                return new List<HotKey>();
            }

        }
    }
}
