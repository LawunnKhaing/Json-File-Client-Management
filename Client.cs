using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTask12B
{
    internal class Client
    {
        public Client(string? name, DateTime? dateOfRegistration)
        {
            Name = name;
            DateOfRegistration = dateOfRegistration;
        }

        public string? Name { get; set; }
        public DateTime? DateOfRegistration { get; set; }

        //Instance methods here;
        public void ModifyInfo(string path, string name)
        {
            bool ifChanged = false;

            //Deserialize the JSON data here:
            List<Client> clients = new List<Client>();

            using (StreamReader sr = new StreamReader(path))
            {
                var jsonString = sr.ReadToEnd();
                //Deserialize into generic collection of type List<Client>
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonString);
            }
            var chosen = from cli in clients
                         where cli.Name.ToLower().Contains(name)
                         select cli;

            int numberOfClients = clients.Count();
            if (chosen.Any())
            {
                for (int i = 0; i < numberOfClients; i++)
                {
                    if (clients[i].Name.ToLower().Contains(name))
                    {
                        Console.WriteLine("Found client {0}", clients[i].Name);
                        Console.WriteLine("Want to change the information Y/N: ");
                        string choice = Console.ReadLine().ToUpper();
                        if (choice.StartsWith("Y"))
                        {
                            Console.WriteLine("We go through all the information.One at a time");
                            Console.WriteLine("If you do not want to change, press ENTER");
                            Console.WriteLine("Current name is {0}.", clients[i].Name);
                            Console.Write("Enter new name: ");
                            string NewName = Console.ReadLine();
                            if (!String.IsNullOrEmpty(NewName))
                            {
                                clients[i].Name = NewName;
                                ifChanged = true;
                            }

                            DateTime newDateOfRegistration;
                            Console.WriteLine("Current date of registration is {0}.", clients[i].DateOfRegistration?.ToString("d"));
                            Console.Write("Enter new Date of registration: ");
                            string received = Console.ReadLine();
                            if (!String.IsNullOrEmpty(received))
                            {
                                while (!DateTime.TryParse(received, out newDateOfRegistration))
                                {
                                    Console.Write("Not valid, try again: ");
                                    received = Console.ReadLine();
                                }
                                clients[i].DateOfRegistration = newDateOfRegistration;
                                ifChanged = true;
                            }
                        }
                    }
                }
                if (!ifChanged)
                    Console.WriteLine("You selected the change option, but no changes were made");
            }
            else
            {
                Console.WriteLine("No client with that name");
            }
            if (ifChanged)
            {
                Console.WriteLine("Need to save information into the file!");
                //Serializing the collection information into your file:
                using (StreamWriter sr = new StreamWriter(path, false))
                {
                    //Serializing business first
                    string jsonData = JsonConvert.SerializeObject(clients);
                    sr.Write(jsonData);
                }
            }
        }
        public void PrintTheContents(string path)
        {
            //Deserialize the JSON data here:
            List<Client> clients = new List<Client>();

            using (StreamReader sr = new StreamReader(path))
            {
                var jsonString = sr.ReadToEnd();
                //Deserialize into generic collection of type List<Client>
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonString);
            }

            foreach (var item in clients)
            {
                Console.WriteLine("Name:{0}, date of registration: {1}", item.Name,
                    item.DateOfRegistration?.ToString("d"));
                //Console.WriteLine("Name:{0}, date of registration: {1}", item.Name, item.DateOfRegistration.Value.ToString("d"));
            }
        }
        public void AddClient(string path, Client newOne)
        {
            //Deserialize the JSON data here:
            List<Client> clients = new List<Client>();

            using (StreamReader sr = new StreamReader(path))
            {
                var jsonString = sr.ReadToEnd();
                //Deserialize into generic collection of type List<Client>
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonString);
            }
            clients.Add(newOne);
            //Serializing the collection information into your file:
            using (StreamWriter sr = new StreamWriter(path, false))
            {
                //Serializing business first
                string jsonData = JsonConvert.SerializeObject(clients);
                sr.Write(jsonData);
            }
        }
        
    }
}
    
