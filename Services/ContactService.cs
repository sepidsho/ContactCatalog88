using ContactCatalog88.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactCatalog88.Services
{
    public class ContactService
    {
       
        private readonly List<Contact> _contacts = new();
        private readonly HashSet<string> _emails = new(StringComparer.OrdinalIgnoreCase);

        
        public ContactService() { }

        public bool AddContact(Contact contact)
        {
            if (!IsValidEmail(contact.Email))
                return false; 

            if (!_emails.Add(contact.Email))
                return false; 
            _contacts.Add(contact);
            return true;
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

       
        public bool RemoveContact(Guid id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return false;

            _contacts.Remove(contact);
            _emails.Remove(contact.Email);
            return true;
        }

       
        public List<Contact> SearchByName(string term)
        {
            return _contacts
                .Where(c => c.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Name)
                .ToList();
        }

       
        public List<Contact> FilterByTag(string tag)
        {
            return _contacts
                .Where(c => c.Tags.Contains(tag, StringComparer.OrdinalIgnoreCase))
                .OrderBy(c => c.Name)
                .ToList();
        }

       
        private static bool IsValidEmail(string email)
        {
            try
            {
                return new System.Net.Mail.MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}