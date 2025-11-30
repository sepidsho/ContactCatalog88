using ContactCatalog88.Models;
using ContactCatalog88.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalog88.Menu
{
    public class RemoveContactMenu
    {
        private readonly ContactService _contactService;
        private object _contacts;
        private object _emails;

        public RemoveContactMenu(ContactService service)
        {
            _contactService = service;
        }

        public bool RemoveContact(Guid id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return false;

            _contacts.Remove(contact);
            _emails.Remove(contact.Email); 
            return true;
        }
        public void Show()
        {
            Console.Write("Enter contact ID to remove: ");
            var input = Console.ReadLine();

            if (Guid.TryParse(input, out var id))
            {
                if (_contactService.RemoveContact(id))
                    Console.WriteLine("✔ Contact removed.");
                else
                    Console.WriteLine("❌ Contact not found.");
            }
            else
            {
                Console.WriteLine("❌ Invalid ID format.");
            }
        }
    }

}
