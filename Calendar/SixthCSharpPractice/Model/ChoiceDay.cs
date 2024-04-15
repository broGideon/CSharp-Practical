namespace SixthCSharpPractice.Model;

public class ChoiceDay
{
    public List<Choice> Choices;
    public DateTime Date;

    public ChoiceDay(DateTime date, List<Choice> choices)
    {
        Choices = choices;
        Date = date;
    }
}