public class Patient
{
    public int PatientID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    private string Disease { get; set; }

    //public void GetDisease(string disease){ Console.WriteLine(disease); }

    public void GetPatientDetails()
    {
        Console.Write(PatientID + ",");
        Console.Write(Name + ",");
        Console.Write(Age + ",");
        Console.WriteLine(Disease);

    }

    public Patient(int id, string name, int age, string disease)
    {
        PatientID = id;
        Name = name;
        Age = age;
        Disease = disease;
    }

    ~Patient()
    {
        Console.WriteLine("Patient is Discharged");
    }

}
public class Doctor
{
    public string Name { get; set; }
}
namespace task6
{
    class program
    {
        public static void Main(String[] args)
        {
            Doctor doc = new Doctor();
            Console.WriteLine("Doctors Added: ");
            Console.WriteLine(doc.Name = "Doc1");
            Console.WriteLine(doc.Name = "Doc2");
            Console.WriteLine(doc.Name = "Doc3");


            Console.WriteLine("Patients Added: ");
            Patient Pat1 = new Patient(101, "Pat1", 31, "Disease1");
            Pat1.GetPatientDetails();
            Patient Pat2 = new Patient(102, "Pat2", 32, "Disease2");
            Pat2.GetPatientDetails();
            Patient Pat3 = new Patient(103, "Pat3", 33, "Disease3");
            Pat3.GetPatientDetails();
            Patient Pat4 = new Patient(104, "Pat4", 34, "Disease4");
            Pat4.GetPatientDetails();
            Patient Pat5 = new Patient(105, "Pat5", 35, "Disease5");
            Pat5.GetPatientDetails();

        }

    }
}