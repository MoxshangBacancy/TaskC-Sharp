using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS;

namespace task7
{
    public partial class PatientStatusC
    {
        public void ScheduleAppointment()
        {
            Console.WriteLine("Your appointment is booked for {0}", DateTime.Now);

        }
        public void DisplayPatients()
        {
            foreach(Patient patient in PatientNameLista)
            {
                Console.WriteLine(patient);
            }
        }


    }
}
