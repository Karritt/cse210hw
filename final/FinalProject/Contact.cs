public class Contact
{
    private string _name;
    private string _email;
    private string _phoneNumber;
    private string _address;
    private string _notes;
    public Contact(string Name, string Email, string PhoneNumber, string Address, string Notes)
    {
        _name = Name;
        _email = Email;
        _phoneNumber = PhoneNumber;
        _address = Address;
        _notes = Notes;
    }
    public Contact(string Name, string Email, string PhoneNumber, string Address)
    {
        _name = Name;
        _email = Email;
        _phoneNumber = PhoneNumber;
        _address = Address;
        _notes = "";
    }

    public string GetInfo ()
    {
        return $"{_name} - {_email} - {_phoneNumber} - {_address} - {_notes}";
    }
    public string GetName()
    {
        return _name;
    }
    public string Serialize()
    {
        return $"contact::{_name}::{_email}::{_phoneNumber}::{_address}::{_notes}";
    }
}