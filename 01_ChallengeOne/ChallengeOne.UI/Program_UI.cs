using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly MenuRepo _mRepo = new MenuRepo();
    public void Run()
    {
        SeedData();
        RunApplication();
    }

    private void SeedData()
    {
        var coffee = new MenuItem("Coffee", "Columbian roast coffee", "Coffee grounds brewed with water", 2);
        _mRepo.AddItemToMenu(coffee);
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("=== Welcome to Komodo Cafe ===");
            System.Console.WriteLine("Please choose one of the following: \n" +
            "1. View Menu\n" +
            "2. Add Menu Item\n" +
            "3. Delete Menu Item\n" +
            "4. Close Application\n");

            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ViewMenu();
                    break;
                case "2":
                    AddMenuItem();
                    break;
                case "3":
                    DeleteMenuItem();
                    break;
                case "4":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("invalid selection");
                    PressAnyKeyToContinue();
                    break;
            }


        }
    }

    private void AddMenuItem()
    {
        Console.Clear();
        var newMenuItem = new MenuItem();
        System.Console.WriteLine("=== Add New Menu Item ===\n");
        System.Console.WriteLine("Please enter the item's name:");
        newMenuItem.ItemName = Console.ReadLine();
        System.Console.WriteLine("Please enter the item's ingredients:");
        newMenuItem.Ingredients = Console.ReadLine();
        System.Console.WriteLine("Please enter the item's description:");
        newMenuItem.ItemDescription = Console.ReadLine();
        System.Console.WriteLine("And finally...Please enter the item's price:");
        newMenuItem.ItemPrice = int.Parse(Console.ReadLine());

        bool isSuccessful = _mRepo.AddItemToMenu(newMenuItem);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newMenuItem.ItemName} was added to the menu.");
        }
        else
        {
            System.Console.WriteLine("Failed to add item to menu.");
        }

    }

    private void ViewMenu()
    {
        Console.Clear();
        List<MenuItem> menuItemsInDb = _mRepo.GetAllMenuItems();
        foreach (MenuItem menuItem in menuItemsInDb)
        {
            DisplayMenuItems(menuItem);
        }
        PressAnyKeyToContinue();
    }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("See you next time!");
        PressAnyKeyToContinue();
        return false;
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    private void DisplayMenuItems(MenuItem menuItem)
    {
        System.Console.WriteLine($"MenuItemID: {menuItem.ID}\n" +
        $"ItemName: {menuItem.ItemName}\n" +
        $"ItemDescription: {menuItem.ItemDescription}\n" +
        $"Ingredients: {menuItem.Ingredients}\n" +
        $"ItemPrice: {menuItem.ItemPrice}\n" +
        "------------------------------\n");
    }

    private void DeleteMenuItem()
    {
        Console.Clear();
        System.Console.WriteLine("=== Menu Item Removal ===");
        var menuItems = _mRepo.GetAllMenuItems();
        foreach (MenuItem menuItem in menuItems)
        {
            DisplayMenuItems(menuItem);
        }
        try
        {
            System.Console.WriteLine("Please select a menu item by it's ID:");
            var userInputSelectedItem = int.Parse(Console.ReadLine());
            bool isSuccessful = _mRepo.DeleteItemFromMenu(userInputSelectedItem);
            if (isSuccessful)
            {
                System.Console.WriteLine("Menu item succesfully deleted!");
            }
            else
            {
                System.Console.WriteLine("Failed to delete menu item.");
            }
        }
        catch
        {
            System.Console.WriteLine("Invalid selection.");
        }
        PressAnyKeyToContinue();
    }
}

