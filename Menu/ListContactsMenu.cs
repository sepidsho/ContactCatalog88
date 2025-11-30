using ContactCatalog88.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalog88.Menu
{
    public class ListContactsMenu
    {
        private readonly ContactService _contactService;

        public ListContactsMenu(ContactService service)
        {
            _contactService = service;
        }

        public void Show()
        {
            var contacts = _contactService.GetAllContacts();

            Console.WriteLine("=== All Contacts ===");

            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.Id}  |  {c.Name}  |  {c.Email}  |  {c.Phone}");
            }

            if (contacts.Count == 0)
                Console.WriteLine("No contacts found.");
        }
    }

}
