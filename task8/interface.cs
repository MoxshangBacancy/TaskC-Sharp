using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{       
        public interface Iworker
        {
            void Work();
        }
        public interface IEatable
        {
              void Eat();
        }

        public class Human : Iworker, IEatable
        {
            public void Work()
            {
                Console.WriteLine("Working...");
            }
            public void Eat()
            {
                Console.WriteLine("Eating...");
            }
        }

        public class Robot : Iworker
        {
            public void Work()
            {
                Console.WriteLine("Robot Working...");
            }
        }
}
