using System.IO;
using Newtonsoft.Json;

namespace WpfLibrary1;

public static class SerDeser
{
    public static void Serialize<T>(T obj, string file)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string json = JsonConvert.SerializeObject(obj);
        File.WriteAllText(path + "\\" + file, json);
    }
    public static T Deserialize<T>(string file)
    {
        try
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "\\" + file);
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
        catch
        {
            return default!;
        }

    }
}