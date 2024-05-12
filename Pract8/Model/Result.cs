namespace TestNaSkoropechat.Model;

public class Result
{
    public string Name { get; set; }
    public int CharMinut { get; set; }
    public float CharSecond { get; set; }

    public Result(string name, int charMinut, float charSecond)
    {
        Name = name;
        CharMinut = charMinut;
        CharSecond = charSecond;
    }
}