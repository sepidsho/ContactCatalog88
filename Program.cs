using ContactCatalog88.Menu;
using ContactCatalog88.Menus;
using ContactCatalog88.Services;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        // Logger
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = loggerFactory.CreateLogger<Program>();
        logger.LogInformation("Program started.");

        // Services
        var contactService = new ContactService();
        var tagService = new TagService();

        while (true)
        {
            // Show menu
            Menu.Show();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new AddContactMenu(contactService, tagService).Show();
                    break;
                case "2":
                    new ListContactsMenu(contactService).Show();
                    break;
                case "3":
                    new RemoveContactMenu(contactService).Show();
                    break;
                case "4":
                    new SearchContactMenu(contactService).Show();
                    break;
                case "5":
                    new FilterByTagMenu(contactService).Show();
                    break;
                case "0":
                    logger.LogInformation("Program exited.");
                    return;
                default:
                    Console.WriteLine("Unknown choice.");
                    break;
            }
        }
    }
}
// Test commit for Git push