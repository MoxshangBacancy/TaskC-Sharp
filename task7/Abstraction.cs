using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS;

namespace task7
{
    public abstract class HospitalService
    {
        string HospitalPolicy = @"
        **********************************************
                      XYZ Hospital Policy
        **********************************************

        1. **Patient Confidentiality**  
           - All patient information is strictly confidential and will not be shared without consent.

        2. **Visiting Hours**  
           - General: 10:00 AM - 8:00 PM  
           - ICU: 4:00 PM - 6:00 PM (Immediate family only)

        3. **Emergency Services**  
           - Available 24/7. Call our emergency hotline at 123-456-7890.

        4. **Appointment Scheduling**  
           - Patients must schedule appointments in advance. Walk-ins are accepted based on availability.

        5. **Billing & Insurance**  
           - Payments must be made at the billing counter. We accept major insurance providers.

        6. **Code of Conduct**  
           - Patients and visitors must maintain decorum. Any misconduct may lead to expulsion.

        7. **No-Smoking Policy**  
           - Smoking is strictly prohibited on hospital premises.

        **********************************************
                  Thank You for Choosing XYZ Hospital
        **********************************************
        ";
        public abstract void GetServiceType();
        public void PrintHospitalPolicy()
        {
            Console.WriteLine(HospitalPolicy);
        }
    }

}
