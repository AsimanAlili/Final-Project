using Final_Project.Sturucture.Enums;
using Final_Project.Sturucture.Models;
using System;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuItem menu = new MenuItem("as", 55, Category.Main);
            Console.WriteLine(menu.No);
        }
    }
}
