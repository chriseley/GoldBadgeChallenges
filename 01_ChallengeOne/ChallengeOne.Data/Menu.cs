using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class MenuItem
{
    public MenuItem() { }
    public MenuItem(string itemName, string itemDescription, string ingredients, int itemPrice)
    {
        ItemName = itemName;
        ItemDescription = itemDescription;
        Ingredients = ingredients;
        ItemPrice = itemPrice;
    }
    public int ID { get; set; }
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public string Ingredients { get; set; }
    public decimal ItemPrice { get; set; }
}
