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



// Lag et program som representerer en enkel restaurantmeny.
// MenuItem (navn, kategori, pris)
// Menu (liste over MenuItem-objekter)
// La brukeren legge inn noen menyer som et array, og overfør disse til en List<MenuItem>.
// Skriv funksjoner for å:
// Legge til menyvalg
// Filtrere menyvalg etter kategori
// Finne billigste og dyreste rett
// Implementer en metode som beregner totalprisen på en valgt meny.