using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_2
{
    public class Trainer1
    {
        public int TrainerID { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }


        public Trainer1(int trainerID, string name, string expertise)
        {
            TrainerID = trainerID;
            Name = name;
            Expertise = expertise;
        }
    }

    public class TrainerList
    {
        public static List<Trainer1> GetTrainerDetails()
        {
            return new List<Trainer1>
            {
                new Trainer1(1, "John Smith", "Machine Learning"),
                new Trainer1(2, "Alice Johnson", "Web Development"),
                new Trainer1(3, "Michael Brown", "Cloud Computing"),
                new Trainer1(4, "Emma Wilson", "Cybersecurity"),
                new Trainer1(5, "David Lee", "Data Science"),
                new Trainer1(6, "Sophia White", "Mobile App Development"),
                new Trainer1(7, "James Miller", "AI & Deep Learning"),
                new Trainer1(8, "Olivia Davis", "Software Architecture"),
                new Trainer1(9, "William Garcia", "DevOps & CI/CD"),
                new Trainer1(10, "Ethan Thompson", "Database Management"),
                new Trainer1(1, "John Smith", "Machine Learning"),

            };
        }
    }
}

