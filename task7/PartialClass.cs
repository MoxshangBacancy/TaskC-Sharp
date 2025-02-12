//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HMS;

using HMS;

namespace task7
{

    partial class PatientStatusC
    {
        List<Patient> PatientNameLista = new List<Patient> { };
        public void AdmitPatient(Patient PatientName)
        {
            PatientNameLista.Add(PatientName);

            Console.WriteLine($"Patient {PatientName} admitted successfully.");
        }
        public void DischargePatient(Patient PatientName)
        {
            PatientNameLista.Remove(PatientName);
            Console.WriteLine($"Patient {PatientName} discharged successfully.");
        }
    }

}