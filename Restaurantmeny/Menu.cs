namespace Restaurantmeny;

public class Menu
{
    public List<MenuItem> MenuItems { get; private set; }

    public Menu()
    {
        MenuItems = new List<MenuItem>();
    }

    public Menu(MenuItem[] initialMenuItems) : this()
    {
        if (initialMenuItems != null)
        {
            MenuItems.AddRange(initialMenuItems);
            Console.WriteLine($"Added {initialMenuItems.Length} menu items from initial menu list");
        }
    }

    public void AddMenuItem(MenuItem item)
    {
        if (item != null)
        {
            if (MenuItems.Any(m => m.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"{item.Name} already exists");
            }
            else
            {
                Console.WriteLine($"{item.Name} added to menu list");
            }
        }
        else
        {
            Console.WriteLine("Cannot add an empty item");
        }
    }
    
    public List<MenuItem> FilterByCategory(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            Console.WriteLine("Category cannot be empty");
            return new List<MenuItem>();
        }
        
        var filteredItem = MenuItems.Where(i => i.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

        if (filteredItem.Count == 0)
        {
            Console.WriteLine($"Couldn't find menuitem in the category {category}");
        }
        else
        {
            Console.WriteLine($"\n**** Menu Items found in category {category} ****");
            foreach (var item in filteredItem)
            {
                item.PrintInfo();
            }
        }
        return filteredItem;
    }
    
    public MenuItem FindCheapestItem()
    {
        if (!MenuItems.Any())
        {
            Console.WriteLine("The menu is empty, can't find the cheapest dish");
            return null;
        }
        
        var cheepest =MenuItems.OrderBy(item => item.Price).FirstOrDefault();

        Console.WriteLine("\n**** Cheapest dish ****");
        if (cheepest != null)
        {
            cheepest.PrintInfo();
        }
        
        return cheepest;
    }
    
    public MenuItem FindMostExpensiveItem()
    {
        if (!MenuItems.Any())
        {
            Console.WriteLine("The menu is empty, can't find the most expensive dish");
            return null;
        }
        
        var mostExpensive = MenuItems.OrderByDescending(item => item.Price).FirstOrDefault();

        Console.WriteLine("\n**** Most expensive dish ****");
        if (mostExpensive != null)
        {
            mostExpensive.PrintInfo();
        }
        return mostExpensive;
    }
    
    public decimal CalculateTotalPrice(List<MenuItem> selectedItems)
    {
        if (selectedItems == null || !selectedItems.Any())
        {
            Console.WriteLine("No items selected, can't calculate total price");
            return 0m;
        }
        
        decimal totalPrice = selectedItems.Sum(item => item.Price);
        Console.WriteLine($"\nTotal price for selected items: {totalPrice:C2}\n");
        return totalPrice;;
    }

    public void PrintAllMenuItems()
    {
        if (MenuItems.Count == 0)
        {
            Console.WriteLine("The menu is empty");
            return;
        }

        Console.WriteLine("**** The Menu ****");
        foreach (var menu in MenuItems)
        {
            menu.PrintInfo();
        }
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