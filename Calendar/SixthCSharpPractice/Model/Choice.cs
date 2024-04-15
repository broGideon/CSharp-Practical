namespace SixthCSharpPractice.Model;

public class Choice
{
    public Choice(string name, string path, bool isActive)
    {
        Name = name;
        Path = path;
        IsActive = isActive;
    }

    public string Name { get; set; }
    public string Path { get; set; }
    public bool IsActive { get; set; }
}