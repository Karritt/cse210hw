using System;

class Program
{
    static void Main(string[] args)
    {
        //Create a new contact
        Contact contact1 = new Contact("John Doe", "johndoe@email.com", "123-456-7890", "123 Main St", "Friend from college");
        Contact contact2 = new Contact("Jane Smith", "janesmith@email.com", "098-765-4321", "456 Elm St");
        Event studyTime = new Event("Study Session", new DateTime(2023, 10, 1, 14, 0, 0), new TimeSpan(2, 0, 0), "Study for the upcoming exam");
        Appointment teamMeeting = new Appointment("Team Meeting", new DateTime(2023, 10, 2, 10, 0, 0), new TimeSpan(1, 0, 0), "Discuss project progress", new List<Contact> { contact1, contact2 }, "Conference Room A");
        Task cancelTeamMeeting = new Task("Cancel Team Meeting", new DateTime(2023, 10, 2, 9, 0, 0), "Cancel the team meeting due to scheduling conflict");
        Console.WriteLine(contact1.GetInfo());
        Console.WriteLine(contact2.GetInfo());
        Console.WriteLine(studyTime.GetInfo());
        Console.WriteLine(teamMeeting.GetInfo());
        Console.WriteLine(studyTime.CancelEvent());
        Console.WriteLine(teamMeeting.CancelEvent());
        Console.WriteLine(cancelTeamMeeting.CompleteTask());
    }
}