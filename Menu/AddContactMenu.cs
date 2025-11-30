using ContactCatalog88.Models;
using ContactCatalog88.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactCatalog88.Menu
{
    public class AddContactMenu
    {
        private readonly ContactService _contactService;
        private readonly TagService _tagService;
        private readonly ILogger _logger;

        public AddContactMenu(ContactService contactService, TagService tagService)
        {
            _contactService = contactService;
            _tagService = tagService;
        }

        public void Show()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine()!;

            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Phone: ");
            var phone = Console.ReadLine()!;

            Console.Write("Tags (comma separated): ");
            var tags = _tagService.ParseTags(Console.ReadLine()!);

            var contact = new Contact
            {
                Name = name,
                Email = email,
                Phone = phone,
                Tags = tags
            };
            if (EmailValidator.IsValidEmail(email))
            {
                object value = _contactService.AddContact(contact);
                Console.WriteLine("✔ Contact added successfully!");
            }
            else
            {
                Console.WriteLine("❌ Invalid email format!");
                return;
            }
             else
             {
                Console.WriteLine("❌ Email already exists! Contact not added.");
                _logger.LogWarning("Duplicate email attempted: {Email}", email);
            }
        }
    }

}

