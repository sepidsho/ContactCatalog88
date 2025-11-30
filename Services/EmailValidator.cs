using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalog88.Services
{
    public static class EmailValidator
    {
        public static bool IsValidEmail(string email)
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
