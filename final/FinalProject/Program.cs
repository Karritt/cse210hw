using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        List<Contact> contacts = new List<Contact>();
        List<Event> events = new List<Event>();
        //Load data from file
        if (System.IO.File.Exists("data.txt"))
        {
            string serializedData = System.IO.File.ReadAllText("data.txt");
            string decodedData = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(serializedData));

            // Debugging
            // Console.WriteLine($"Decoded data: {decodedData}");
            // Console.WriteLine("Press any key to continue...");
            // Console.ReadKey();

            List<string> lines = new List<string>(decodedData.Split('\n'));
            foreach (string line in lines)
            {
                string[] parts = line.Split("::");
                if (parts[0] == "contact")
                {
                    Contact contact = new Contact(parts[1], parts[2], parts[3], parts[4], parts[5]);
                    contacts.Add(contact);
                }
                else if (parts[0] == "generic")
                {
                    Generic genericEvent = new Generic(parts[1], DateTime.Parse(parts[2]), TimeSpan.Parse(parts[3]), parts[4]);
                    events.Add(genericEvent);
                }
                else if (parts[0] == "appointment")
                {
                    List<Contact> eventContacts = new List<Contact>();
                    string[] contactNames = parts[6].Trim('[', ']').Split(',');
                    foreach (string contactName in contactNames)
                    {
                        Contact contact = contacts.Find(c => c.GetName() == contactName.Trim());
                        if (contact != null)
                        {
                            eventContacts.Add(contact);
                        }
                    }
                    Appointment appointmentEvent = new Appointment(parts[1], DateTime.Parse(parts[2]), TimeSpan.Parse(parts[3]), parts[4], eventContacts, parts[5]);
                    events.Add(appointmentEvent);
                }
                else if (parts[0] == "task")
                {
                    Task taskEvent = new Task(parts[1], DateTime.Parse(parts[2]), parts[3], bool.Parse(parts[4]));
                    events.Add(taskEvent);
                }
            }
        }
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Event Management System!");
            Console.WriteLine("1. Contact - Create");
            Console.WriteLine("2.           View");
            Console.WriteLine("3.           Delete");
            Console.WriteLine("4. Event   - Create");
            Console.WriteLine("5.           View");
            Console.WriteLine("6.           Delete");
            Console.WriteLine("7. Exit");
            Console.Write(">");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Creating a new contact...");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter email: ");
                string email = Console.ReadLine();
                Console.Write("Enter phone number: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Enter address: ");
                string address = Console.ReadLine();
                Console.Write("Enter notes (optional): ");
                string notes = Console.ReadLine();
                Contact newContact = new Contact(name, email, phoneNumber, address, notes);
                contacts.Add(newContact);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Viewing contacts...");
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine(contact.GetInfo());
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Deleting a contact...");
                Console.Write("Enter the name of the contact to delete: ");
                string nameToDelete = Console.ReadLine();
                Contact contactToDelete = null;
                foreach (Contact contact in contacts)
                {
                    if (contact.GetName() == nameToDelete)
                    {
                        contactToDelete = contact;
                        break;
                    }
                }
                if (contactToDelete != null)
                {
                    contacts.Remove(contactToDelete);
                    Console.WriteLine($"Contact {nameToDelete} deleted.");
                }
                else
                {
                    Console.WriteLine($"Contact {nameToDelete} not found.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Creating a new event...");
                Console.Write("Enter event title: ");
                string title = Console.ReadLine();
                Console.Write("Enter start date and time (yyyy-mm-dd HH:mm): ");
                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);
                Console.Write("Enter notes (optional): ");
                string notes = Console.ReadLine();
                Console.Write("What type of event is this? (Generic, Appointment, Task): ");
                string eventType = Console.ReadLine();
                if (eventType.ToLower() == "appointment")
                {
                    Console.Write("Enter duration (hh:mm:ss): ");
                    TimeSpan duration = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter location: ");
                    string location = Console.ReadLine();
                    List<Contact> eventContacts = new List<Contact>();
                    Console.Write("Enter number of contacts: ");
                    int numContacts = int.Parse(Console.ReadLine());
                    for (int i = 0; i < numContacts; i++)
                    {
                        Console.Write("Enter contact name: ");
                        string contactName = Console.ReadLine();
                        Contact contact = contacts.Find(c => c.GetName() == contactName);
                        if (contact != null)
                        {
                            eventContacts.Add(contact);
                        }
                        else
                        {
                            Console.WriteLine($"Contact {contactName} not found.");
                        }
                    }
                    Appointment newEvent = new Appointment(title, startDate, duration, notes, eventContacts, location);
                    events.Add(newEvent);
                }
                else if (eventType.ToLower() == "task")
                {
                    Task newEvent = new Task(title, startDate, notes);
                    events.Add(newEvent);
                }
                else
                {
                    Console.Write("Enter duration (hh:mm:ss): ");
                    TimeSpan duration = TimeSpan.Parse(Console.ReadLine());
                    Generic newEvent = new Generic(title, startDate, duration, notes);
                    events.Add(newEvent);
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("Viewing events...");
                foreach (Event eventItem in events)
                {
                    Console.WriteLine(eventItem.GetInfo());
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Deleting an event...");
                Console.Write("Enter the title of the event to delete: ");
                string titleToDelete = Console.ReadLine();
                Event eventToDelete = null;
                foreach (Event eventItem in events)
                {
                    if (eventItem.GetTitle() == titleToDelete)
                    {
                        eventToDelete = eventItem;
                        break;
                    }
                }
                if (eventToDelete != null)
                {
                    Console.WriteLine(eventToDelete.CancelEvent());
                    events.Remove(eventToDelete);
                    Console.WriteLine($"Event {titleToDelete} deleted.");
                }
                else
                {
                    Console.WriteLine($"Event {titleToDelete} not found.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "7")
            {
                Console.WriteLine("Exiting the program...");
                string serializedData = "";
                foreach (Contact contact in contacts)
                {
                    serializedData += contact.Serialize() + "\n";
                }
                foreach (Event eventItem in events)
                {
                    serializedData += eventItem.Serialize() + "\n";
                }
                serializedData = serializedData.TrimEnd('\n');
                serializedData = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(serializedData));
                //Console.WriteLine($"Serialized data: {serializedData}");
                System.IO.File.WriteAllText("data.txt", serializedData);
                Console.WriteLine("Data saved to data.txt");
                break;
            }
        }
        //Create a new contact
        // Contact contact1 = new Contact("John Doe", "johndoe@email.com", "123-456-7890", "123 Main St", "Friend from college");
        // Contact contact2 = new Contact("Jane Smith", "janesmith@email.com", "098-765-4321", "456 Elm St");
        // Event studyTime = new Generic("Study Session", new DateTime(2023, 10, 1, 14, 0, 0), new TimeSpan(2, 0, 0), "Study for the upcoming exam");
        // Appointment teamMeeting = new Appointment("Team Meeting", new DateTime(2023, 10, 2, 10, 0, 0), new TimeSpan(1, 0, 0), "Discuss project progress", new List<Contact> { contact1, contact2 }, "Conference Room A");
        // Task cancelTeamMeeting = new Task("Cancel Team Meeting", new DateTime(2023, 10, 2, 9, 0, 0), "Cancel the team meeting due to scheduling conflict");
        // Console.WriteLine(contact1.GetInfo());
        // Console.WriteLine(contact2.GetInfo());
        // Console.WriteLine(studyTime.GetInfo());
        // Console.WriteLine(teamMeeting.GetInfo());
        // Console.WriteLine(studyTime.CancelEvent());
        // Console.WriteLine(teamMeeting.CancelEvent());
        // Console.WriteLine(cancelTeamMeeting.CompleteTask());
    }
}