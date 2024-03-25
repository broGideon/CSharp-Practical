using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CreateTest
{
    internal static class SerDeser
    {
        public static void Serialize(List<Test> tests)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Test.json";
            string text = JsonConvert.SerializeObject(tests);
            File.WriteAllText(path, text);
            return;
        }
        public static List<Test> Deserialize()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Test.json";
                string json = File.ReadAllText(path);
                List<Test> tests = JsonConvert.DeserializeObject<List<Test>>(json);
                if (tests != null)
                {
                    return tests;
                }
                else
                {
                    return new List<Test>();
                }
            }
            catch
            {
                return new List<Test>();
            }
        }

    }
}
