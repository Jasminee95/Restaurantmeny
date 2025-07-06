namespace Restaurantmeny;

public class ResturantApp
{
    public Menu Menu { get; private set; }

    public ResturantApp()
    {
        MenuItem[] initialItems = new MenuItem[]
        {
            new MenuItem("Pizza Margherita", "Main Course", 169.50m),
            new MenuItem("Tomato Soup", "Appetizer", 89.00m),
            new MenuItem("Coca-Cola", "Drink", 45.00m),
            new MenuItem("Brownie", "Dessert", 75.00m),
            new MenuItem("Spagetti Carbonara", "Main Course", 189.00m),
            new MenuItem("Water", "Drink", 30.00m),
        };
        Menu = new Menu(initialItems);
    }

    public void Run()
    {
        bool running = true;
        
        while (running)
        {
            DisplayMainMenu();
            string choise = Console.ReadLine() ?? string.Empty;
            
            switch (choise)
            {
                case "1":
                    AddMenuitemPrompt();
                    break;
                case "2":
                    Console.Clear();
                    Menu.PrintAllMenuItems();
                    break;
                case "3":
                    FilterByCategoryPrompt();
                    break;
                case "4":
                    FindCheapestAndMostExpensivePrompt();
                    break;
                case "5":
                    CalculateOrderPricePrompt();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("You closed the app. Thank you for your visit. Have a great day!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    private void DisplayMainMenu()
    {
        Console.WriteLine("\nResturant Administration!");
        Console.WriteLine("1. Add a new menu item");
        Console.WriteLine("2. Show the whole menu");
        Console.WriteLine("3. Filter the menu by category");
        Console.WriteLine("4. Find the cheapest dish");
        Console.WriteLine("5. Calculate total price");
        Console.WriteLine("6. Exit the resturant app");
        Console.Write("Choose an option ");
    }

    private void AddMenuitemPrompt()
    {
        Console.WriteLine("\nPlease enter the name of the menu item");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter the category of the menu item (Appetizer, Main Course, Dessert or Drink)");
        string category = Console.ReadLine();
        Console.WriteLine($"Please enter the total price of the item");

        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Menu.AddMenuItem(new MenuItem(name, category, price));
        }
        else
        {
            Console.WriteLine("Please enter a valid number");
        }
    }
    
    private void FilterByCategoryPrompt()
    {
        Console.WriteLine("Please enter the category you would like to filter");
        string category = Console.ReadLine();
        Menu.FilterByCategory(category);
    }

    private void FindCheapestAndMostExpensivePrompt()
    {
        Menu.FindCheapestItem();
        Menu.FindMostExpensiveItem();
    }

    private void CalculateOrderPricePrompt()
    {
        List<MenuItem> selectedItems = new List<MenuItem>();
        string input;
        int itemNumber = 1;

        Console.Clear();
        Console.WriteLine("\n**** Calculate Order Price ****");
        Console.WriteLine("Please enter the name of the item you would like to add to your order");
        Console.WriteLine("Write 'done' when you are done\n");
        Menu.PrintAllMenuItems();

        while (true)
        {
            Console.WriteLine($"\n({itemNumber}) Add more orders (or 'done')");
            input = Console.ReadLine() ?? string.Empty;

            if (input.Equals("done", StringComparison.InvariantCultureIgnoreCase))
            {
                break;
            }
            
            MenuItem foundItem = Menu.MenuItems.FirstOrDefault(item => item.Name.Equals(input, StringComparison.InvariantCultureIgnoreCase));

            if (foundItem != null)
            {
                selectedItems.Add(foundItem);
                Console.WriteLine($"'{foundItem.Name}' added to order.");
                itemNumber++;
            }
            else
            {
                Console.WriteLine($"Could not find any dish with the name '{input}'. Please try again.");
            }
        }
        Menu.CalculateTotalPrice(selectedItems);
    }
}