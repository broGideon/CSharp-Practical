using System.Windows.Controls;

namespace SixthCSharpPractice.View;

public partial class FoodCard : UserControl
{
    public FoodCard()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string Path { get; set; }
    public string ProductType { get; set; }
    public bool IsActive { get; set; }
}