using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class MenuRepo
{
 private readonly List<MenuItem> _menuItems = new List<MenuItem>();
 private int _count;
 public bool AddItemToMenu(MenuItem menuItem)
 {
     if(menuItem != null)
     {
         _count++;
         menuItem.ID=_count;
         _menuItems.Add(menuItem);
         return true;
     }
     else
     {
         return false;
     }
 }
 public List<MenuItem> GetAllMenuItems()
 {
     return _menuItems;
 }
 public MenuItem GetMenuItemByID(int id)
 {
     foreach (MenuItem menuItem in _menuItems)
     {
         if (menuItem.ID == id)
         {
             return menuItem;
         }
     }
     return null;
 }
public bool DeleteItemFromMenu(int id)
{
    var menuItem = GetMenuItemByID(id);
    if (menuItem != null)
    {
        _menuItems.Remove(menuItem);
        return true;
    }
    else
    {
        return false;
    }
}
}
