using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS;

namespace task7
{
    interface IHospitalOperations
    {
        void AdmitPatient(Patient patient);
        void DischargePatient(Patient patient);
        void DisplayPatients();
    }

    class HospitalManager : IHospitalOperations
    {

        PatientStatusC pat = new PatientStatusC();

        void IHospitalOperations.AdmitPatient(Patient patient)
        {

            //PatientNameList.Add(patient);
            pat.AdmitPatient(patient);

            //Console.WriteLine($"Patient {patient.Name} admitted successfully.");

        }
        void IHospitalOperations.DischargePatient(Patient patient)
        {
            pat.DischargePatient(patient);
            //Console.WriteLine($"Patient {patient.Name} discharged successfully.");
        }
        void IHospitalOperations.DisplayPatients()
        {
            //foreach (Patient patient in PatientNameList)
            //{
            //    Console.WriteLine(patient.Name);
            //}
            pat.DisplayPatients();  
        }
    }
}