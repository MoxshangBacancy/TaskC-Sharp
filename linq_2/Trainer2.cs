using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_2
{
    public class Trainer2
    {
        public int TrainerID { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }


        public Trainer2(int trainerID, string name, string expertise)
        {
            TrainerID = trainerID;
            Name = name;
            Expertise = expertise;
        }
    }

    public class TrainerList2
    {
        public static List<Trainer2> GetTrainerDetails2()
        {
            return new List<Trainer2>
            {
            new Trainer2(11, "John Smith", "Deep Learning"), // Duplicate Name (Different Expertise)
            new Trainer2(12, "Alice Johnson", "Full Stack Development"), // Duplicate Name (Different Expertise)
            new Trainer2(13, "Robert Anderson", "Cybersecurity"),
            new Trainer2(14, "Emma Wilson", "Ethical Hacking"), // Duplicate Name (Different Expertise)
            new Trainer2(15, "David Lee", "Big Data"), // Duplicate Name (Different Expertise)
            new Trainer2(16, "Sophia White", "Flutter Development"), // Duplicate Name (Different Expertise)
            new Trainer2(17, "Christopher Harris", "Blockchain"),
            new Trainer2(18, "Olivia Davis", "Microservices"), // Duplicate Name (Different Expertise)
            new Trainer2(19, "Nathan Martinez", "Software Engineering"),
            new Trainer2(20, "Ethan Thompson", "SQL & Databases"), // Duplicate Name (Different Expertise)
            };
        }
    }
}

