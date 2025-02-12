using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    abstract class Account
    {
        public readonly string name;
        public readonly string ID;
        public readonly DOB DOB;
        public readonly string nominee;
        public double balance;
        protected string type;
        public double ammount;
        public abstract bool deposit(double amount);

        public abstract bool withdraw(double amount);

        public double getBalance()
        {
            return balance;
        }
        public string getAccType()
        {
            string actype;
            actype = Convert.ToString(Console.ReadLine());
            return actype;
        }
        public void printAccount()
        {

            Console.WriteLine("Name : " + name);
            Console.WriteLine("Date of Birth :" + DOB);
            Console.WriteLine("Nominee : " + nominee);
            Console.WriteLine("Balance :" + balance);
        }
        public Account()
        {

        }
        public Account(string name, DOB DOB, string nominee, double balance)
        {
            this.name = name;
            this.DOB = DOB;
            this.nominee = nominee;
            this.balance = balance;
        }
    }
}
//Savings class
namespace BMS
{
    class Savings : Account
    {
        public Savings() : base()
        {
        }

        public override bool deposit(double amount)
        {
            this.ammount = amount;
            this.balance = balance + ammount;
            Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
            return true;
        }

        public override bool withdraw(double amount)
        {
            this.ammount = amount;
            this.balance = balance - ammount;
            Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance);
            return true;
        }
    }
}

//Debit class

namespace BMS
{
    class Debit : Account
    {
        public double maxBalance = 100000;
        private double dailyTransLimit = 20000;

        public Debit() : base()
        {

        }

        public Debit(string name, DOB DOB, string nominee, double balance) : base(name, DOB, nominee, balance)
        {

        }

        public override bool deposit(double amount)
        {
            this.ammount = amount;
            if (amount > maxBalance)
            {
                Console.WriteLine("You can not deposit more than 100000!");
                return false;
            }
            else
            {
                this.balance = balance + ammount;
                Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
                return true;
            }
        }

        public override bool withdraw(double amount)
        {
            this.ammount = amount;

            if (amount > dailyTransLimit)
            {
                Console.WriteLine("You can not withdraw more than 20000.");
                return false;

            }
            else if (amount > maxBalance)
            {
                Console.WriteLine("You can not withdraw that ammount of money!");
                return false;
            }
            else
            {
                this.balance = balance - ammount;
                Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance);
                return true;
            }
        }
    }
}

//Credit class 

namespace BMS
{
    class Credit : Account
    {
        public double minBalance = -100000;
        private double dailyWithdrawLimit = 20000;


        public Credit() : base()
        {
        }
        public Credit(string name, DOB DOB, string nominee, double balance) : base(name, DOB, nominee, balance)
        {

        }

        public override bool deposit(double amount)
        {
            this.ammount = amount;
            this.balance = balance + ammount;
            Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
            return true;
        }
        public override bool withdraw(double amount)
        {
            this.ammount = amount;
            if (amount < this.minBalance)
            {
                Console.WriteLine("Your Account don't have sufficient ammount of money!");
                return false;
            }
            else if (amount > dailyWithdrawLimit)
            {
                Console.WriteLine("You can not withdraw more than 20000.");
                return false;
            }
            else
            {

                this.balance = balance - ammount;
                Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance);
                return true;
            }
        }
    }
}
