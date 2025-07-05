namespace Restaurantmeny;

public class MenuItem
{
    private string _name;
    private string _category;
    private decimal _price;

    public MenuItem(string name, string category, decimal price)
    {
        _name = name;
        _category = category;
        _price = price;
    }
    public string Name => _name;
    public string Category => _category;
    public decimal Price => _price;

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Category: {Category}, Price: {Price:C2}");
    }
}
