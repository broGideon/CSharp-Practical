using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Datebook
{
    public static class SerDeser
    {
        public static void Sereolize<T>(T obj, string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + file;
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);
            return;
        }
        public static List<T> Deserialize<T>(string file)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + file;
                string json = File.ReadAllText(path);
                List<T> obj = JsonConvert.DeserializeObject<List<T>>(json);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return new List<T>();
                }
            }
            catch
            {
                return new List<T>();
            }

        }
    }
}
