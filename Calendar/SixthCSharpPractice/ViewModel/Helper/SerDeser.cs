using System.IO;
using Newtonsoft.Json;

namespace SixthCSharpPractice.ViewModel.Helper;

public static class SerDeser
{
    public static void Serialize<T>(T obj, string file)
    {
        var json = JsonConvert.SerializeObject(obj);
        File.WriteAllText(file, json);
    }

    public static List<T> Deserialize<T>(string file)
    {
        try
        {
            var json = File.ReadAllText(file);
            var obj = JsonConvert.DeserializeObject<List<T>>(json);
            if (obj != null) return obj;
            return new List<T>();
        }
        catch
        {
            return new List<T>();
        }
    }
}