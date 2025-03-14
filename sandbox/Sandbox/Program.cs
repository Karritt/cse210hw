using System;
class Program
{
    static void Main(string[] args)
    {
        Teacher teacher = new Teacher("John", "Doe", "Mr.", 146);
        Specialist specialist = new Specialist("Jane", "Smith", "Ms.", "Math");
        Volunteer volunteer = new Volunteer("Emily", "Jones", "Mrs.");
        teacher.DisplayGreeting();
        specialist.DisplayGreeting();
        volunteer.DisplayGreeting();

    }

}