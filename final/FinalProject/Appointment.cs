//Appointments are a type of Event with Contacts and Location. They have a default reminder of 30 minutes before the start time.

public class Appointment : Event
{
    private List<Contact> _contacts;
    private string _location;
    public Appointment(string Title, DateTime StartDate, TimeSpan Duration, string Notes, List<Contact> Contacts, string Location) : base(Title, StartDate, Duration, Notes)
    {
        _contacts = Contacts;
        _location = Location;
        SetReminder(new TimeSpan(0, 30, 0));
    }
    public Appointment(string Title, DateTime StartDate, TimeSpan Duration, List<Contact> Contacts, string Location) : base(Title, StartDate, Duration)
    {
        _contacts = Contacts;
        _location = Location;
        SetReminder(new TimeSpan(0, 30, 0));
    }



    //polymorphic function to get the info of the appointment, but also need to include the contacts and location.
    public new string GetInfo()
    {
        string outString = $"{base.GetInfo()} \nLocation: {_location} \nContacts: ";
        if (_contacts.Count == 0)
        {
            outString += "No contacts.";
        }
        else
        {
            _contacts.ForEach(contact => outString += contact.GetName() + "\n");
        }
        return outString;
    }

    //polymorphic function to cancel the event, but also need to remind the user to cancel their appointment with their contacts.
    public string CancelEvent()
    {
        string output = $"Don't forget to cancel your appointment at {_location} with the following contacts: \n";
        _contacts.ForEach(contact => output += contact.GetInfo() + "\n");
        _contacts.Clear();
        _location = "";
        output += base.CancelEvent(); //still calls the base cancelEvent function to clear the start and end date and notes.
        return output;
    }
}