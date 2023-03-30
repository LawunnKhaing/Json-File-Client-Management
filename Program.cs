using OOPTask12B;
using System.Diagnostics;

bool more = false;
int choice;
string filePath;
string clientName;
DateTime dateOfRegistration;
Client client = new Client(null, null);
//File is here
// C:\Users\95996\Downloads\client.json

do
{
    Console.WriteLine();
    Console.WriteLine("Welcome to JSON file processiing. Select from (1...4)");
    Console.WriteLine("1. Output the contents.");
    Console.WriteLine("2. Add a new client");
    Console.WriteLine("3. Modify client information.");
    Console.WriteLine("4. Remove client");
    Console.WriteLine();
    Console.Write("Select an option: ");
    string received=Console.ReadLine();
    while (!Int32.TryParse(received, out choice) || choice < 1 || choice>4 )
    {
        Console.WriteLine("Not accepted, try again");
        received= Console.ReadLine();
    }

    switch (choice)
    {
        case 1:
            Console.WriteLine("You selected: 1. Output the contents");
            do
            {
                Console.Write("Enter the file path: ");
                filePath = Console.ReadLine();
                if (string.IsNullOrEmpty(filePath))
                    Console.WriteLine("The field cannot be empty.");


            } while (string.IsNullOrEmpty(filePath));
            //Call your method now:
            client.PrintTheContents(filePath);


            break; 
        
        case 2:
            Console.WriteLine("You selected: 2. Add a new client");
            do
            {
                Console.Write("Enter the file path: ");
                filePath = Console.ReadLine();
                if (string.IsNullOrEmpty(filePath))
                    Console.WriteLine("The field cannot be empty.");


            } while (string.IsNullOrEmpty(filePath));
            do
            {
                Console.Write("Enter the client name: ");
                clientName = Console.ReadLine();
                if (string.IsNullOrEmpty(clientName))
                    Console.WriteLine("The field cannot be empty.");


            } while (string.IsNullOrEmpty(clientName));

            Console.WriteLine("Enter the date of registration: ");
            received = Console.ReadLine();
                while (!DateTime.TryParse(received, out dateOfRegistration))
                {
                    Console.Write("Not valid, try again: ");
                    received = Console.ReadLine();
                }
            Client newClient = new Client(clientName, dateOfRegistration);
            //Call your method now:
            client.AddClient(filePath, newClient);


            break;
        case 3:
            Console.WriteLine("You selected: 3. Modify client information");
            do
            {
                Console.Write("Enter the file path: ");
                filePath= Console.ReadLine();
                if (string.IsNullOrEmpty(filePath))
                    Console.WriteLine("The field cannot be empty.");


            } while (string.IsNullOrEmpty(filePath));

            do
            {
                Console.Write("Enter the client name: ");
                clientName = Console.ReadLine();
                if (string.IsNullOrEmpty(clientName))
                    Console.WriteLine("The field cannot be empty.");


            } while (string.IsNullOrEmpty(clientName));
            //Call your method now:
            client.ModifyInfo(filePath, clientName);
            break;
        case 4:
            Console.WriteLine("You selected: 4. Remove client");
            break;
        default:
            Console.WriteLine("Sorry, you will NEVER be here.");
            break;
    }

    Console.Write("More operations Y/N: ");
    received= Console.ReadLine().ToUpper();
    if(received.StartsWith("Y"))
        more= true;
    else
        more= false;


} while (more);