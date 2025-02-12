using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    sealed class MedicalRecordDatabase
    {
        public void LogMedicalRecord(string patientName, string diagnosis)
        {
            Console.WriteLine("Patient Name : {0} , Diagnosed with : {1} ", patientName, diagnosis);
        }


    }
}