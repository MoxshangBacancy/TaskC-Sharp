using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using HMS;
using task7;
class program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        Patient patient = new Patient(); //calling persons constructor (task 1 base keyword)
        Doctor doctor = new Doctor();//calling persons constructor (task 1 base keyword)
        IHospitalOperations admin1 = new HospitalManager();
        MedicalRecordDatabase medicalRecordDatabase = new MedicalRecordDatabase();
        PatientStatusC patientStatus = new PatientStatusC();
        //patient.DisplayInfo("moxsahng", 22);
        Console.WriteLine("Enter your name and age (e.g., John 25):");
        string input = Console.ReadLine(); // Read the whole line

        string[] parts = input.Split(' '); // Split input by space
        string name = parts[0]; // First part is name

        if (parts.Length >= 2) // Ensure at least name and age are provided
        {
            if (int.TryParse(parts[1], out int age)) // Convert second part to integer
            {
                patient.DisplayInfo(name, age);// override displayinfo from person(task 2 ovveride)
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input format. Please enter both name and age.");
        }
        
           Console.WriteLine("Select Panel:" + " Press 1 for Patient Panel, 2 for Doctor Panel, 3 for Admin Panel, 4 for service type, 5 for partial class methods");
        
        string choice = Console.ReadLine();
        int number = int.Parse(choice); 
        switch(number){
            case 1:
                Console.WriteLine("welcome to Patient Panel");
                Console.WriteLine("How are you feeling");
                string symptoms = Console.ReadLine();
                patient.GetSymptoms(symptoms);
               // goto getInput();
                break;
            case 2:
                Console.WriteLine("Welcome to Doctor Panel");

                doctor.ScheduleAppointment(name);// Call both overloaded versions of ScheduleAppointment()(task 3 method overloading).
                doctor.ScheduleAppointment(name, DateTime.Now);// Call both overloaded versions of ScheduleAppointment()(task 3 method overloading).
                break;
            case 3:
                Console.WriteLine("Welcome to Admin Panel");
                admin1.AdmitPatient(patient);
                admin1.DischargePatient(patient);       
                admin1.DisplayPatients();
                break;
            case 4:
                person.GetServiceType();
                person.PrintHospitalPolicy();
                medicalRecordDatabase.LogMedicalRecord(name, "Fever");
                    break;
            case 5:
                //patientStatus.AdmitPatient(name);
                //patientStatus.DischargePatient(name);
                //patientStatus.ScheduleAppointment();
                //patientStatus.DisplayPatients();
                admin1.AdmitPatient(patient);
                admin1.DischargePatient(patient);
                admin1.DisplayPatients();
                patientStatus.ScheduleAppointment();
                   break;

            default:
                Console.WriteLine("Please select a choice");
                break;

        }
    }

}