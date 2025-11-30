using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalog88.Menus
{  
    public static class Menu
    {
        public static void Show()
        {
            Console.WriteLine("=== Contact Catalog ===");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. List Contacts");
            Console.WriteLine("3. Remove Contact");
            Console.WriteLine("4. Search (Name contains)");
            Console.WriteLine("5. Filter by Tag");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");
        }
    }

}

