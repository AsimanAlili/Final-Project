using Final_Project.Sturucture.Enums;
using Final_Project.Sturucture.Exceptions;
using Final_Project.Sturucture.Models;
using Final_Project.Sturucture.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.Sturucture.Services
{
     public class RestaurantManager: IRestaurantManager
    {
        public MenuItem MenuItem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        List<MenuItem> MenuItems { get; set; }
        List<Order> Orders { get; set; }
        List<Order> IRestaurantManager.Orders { get ; set ; }

        public RestaurantManager()
        {
            MenuItems = new List<MenuItem>();
            Orders = new List<Order>();
        }
       
       
        public void AddMenuItem(string name, double price, Category category)
        {
            string nameStr = name.Trim().ToLower();
            if (MenuItems.Exists(i=>i.Name.Trim().ToLower()!=nameStr))
            {
                MenuItem menuItem = new MenuItem(name, price, category);
                MenuItems.Add(menuItem);
            }
            throw new MenuItemAlreadyExistException("Name", "Menu items exist!");
        }

        public void AddOrder(List<OrderItem> orderItems)
        {
            throw new NotImplementedException();
        }

        public MenuItem EditMenuItem(string name, double price, string no)
        {
            MenuItem searched = MenuItems.Find(i => i.No.ToLower().Trim().Equals(no));
            string nameStr = searched.Name.ToLower().Trim();
            if (MenuItems.Exists(i=>i.Name.Trim().ToLower() ==nameStr))
            {
                searched.Price = price;
                searched.Name = name;
            }
            else
            {
                throw new MenuItemAlreadyExistException("Menu", "Menu item not found!");
            }
            return searched;
        }

        public List<MenuItem> GetMenuItems()
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItemsCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItemsPriceInterval(double firstPrice, double secondPrice)
        {
            if (firstPrice>0 && secondPrice>0)
            {
                if (secondPrice>firstPrice)
                {
                    List<MenuItem> menuPriceInterval = MenuItems.FindAll(i => i.Price >= firstPrice && i.Price <= secondPrice);
                    return menuPriceInterval;
                }
                throw new InvalidPriceIntervalException("Price", "The second price cannot be less than the first!");

            }
            throw new InvalidPriceIntervalException("Price", "Prices cannot be less than zero");
        }

        public List<Order> GetOrderByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void GetOrderByNo(int no)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByDatesInterval(DateTime firstDate, DateTime lastDate)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByPriceInterval(double firstPrice, double secondPrice)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string menuItemNo)
        {
            menuItemNo = menuItemNo.Trim().ToLower();
            MenuItem menuRemove = MenuItems.Find(i => i.No.Equals(menuItemNo));
            MenuItems.Remove(menuRemove);
        }

        public void RemoveOrder(int orderNo)
        {
            Order orderRemove = Orders.Find(i => i.No.Equals(orderNo));
            Orders.Remove(orderRemove);
        }

        public List<MenuItem> Search(string searchStr)
        {
            searchStr = searchStr.Trim().ToLower();

            List<MenuItem> searchedMenuItem = MenuItems.FindAll(b => b.Name.ToLower().Contains(searchStr) || b.No .ToLower().Contains(searchStr) );

            return searchedMenuItem;
        }
    }
}
