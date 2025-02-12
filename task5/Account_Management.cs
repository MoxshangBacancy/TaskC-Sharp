using System;
using System.Collections.Generic;
using System.Linq;

namespace BMS
{
    class Bank
    {
        string id;
        public int idnum = 0;

        public string[] myId = new string[100];
        public string[] myName = new string[100];
        public string[] myAccType = new string[100];
        public string[] myDob = new string[100];
        public string[] myNominee = new string[100];
        public double[] myBalance = new double[100];
        private Dictionary<string, List<Transaction>> transactionHistory = new Dictionary<string, List<Transaction>>();

        private void AddTransaction(string accountId, string type, double amount)
        {
            if (!transactionHistory.ContainsKey(accountId))
            {
                transactionHistory[accountId] = new List<Transaction>();
            }

            var transaction = new Transaction(type, amount);
            transactionHistory[accountId].Add(transaction);
        }

        public void ShowTransactions()
        {
            Console.WriteLine("Enter your Account ID: ");
            string inId = Console.ReadLine();

            if (transactionHistory.ContainsKey(inId))
            {
                Console.WriteLine($"Transaction history for Account ID: {inId}");
                foreach (var transaction in transactionHistory[inId])
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine("No transactions found for this account.");
            }
        }

        IDGenerator Id = new IDGenerator();
        DOB dob = new DOB();
        Credit cr = new Credit();
        Debit db = new Debit();
        Savings sv = new Savings();

        public bool val = true;
        public bool debval = true;

        private void GetAcc(string ID)
        {
            ID = this.id;
            myId[idnum] = ID;
            idnum++;
        }

        public void showAll()
        {
            Console.WriteLine("All accounts are:\n");

            var accountList = new List<(string Name, double Balance)>();

            for (int i = 0; i < idnum; i++)
            {
                accountList.Add((myName[i], myBalance[i]));
            }

            var sortedList = accountList.OrderBy(account => account.Balance).ThenBy(account => account.Name).ToList();

            foreach (var account in sortedList)
            {
                Console.WriteLine("Name: " + account.Name);
                Console.WriteLine("Balance: " + account.Balance);
                Console.WriteLine();
            }
        }

        public void GetTotalBalance()
        {
            double totalBalance = 0;

            for (int i = 0; i < idnum; i++)
            {
                totalBalance += myBalance[i];
            }

            Console.WriteLine("Total balance in the bank: " + totalBalance);
        }

        public void showInfo()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your details: ");
                Console.WriteLine("Name: " + myName[indexNum]);
                Console.WriteLine("Id: " + myId[indexNum]);
                Console.WriteLine("Acc Type: " + myAccType[indexNum]);
                Console.WriteLine("DOB: " + myDob[indexNum]);
                Console.WriteLine("Nominee: " + myNominee[indexNum]);
                Console.WriteLine("Balance: " + myBalance[indexNum]);
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }
        }

        public void create_account()
        {
            string accType;
            string name;
            string nominee;
            double balance;
            string input;

            Console.WriteLine("1. Debit Account");
            Console.WriteLine("2. Credit Account");
            Console.WriteLine("3. Savings Account");
            object ob1 = Console.ReadLine();
            input = Convert.ToString(ob1);

            if (input == "1")
            {
                accType = "Debit";
                myAccType[idnum] = accType;
                Console.Write("Name:");

                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;

                val = true;
                while (val)
                {
                    Console.WriteLine("Enter date of birth (Sample: 23/08/1995): ");
                    string dobInput = Console.ReadLine();

                    if (dob.set(dobInput)) // If date is valid
                    {
                        myDob[idnum] = dobInput; // Store the date
                        val = false;
                    }
                    else
                    {
                        val = true;
                    }
                }

                Console.WriteLine("Enter Nominee name: ");
                nominee = Convert.ToString(Console.ReadLine());
                myNominee[idnum] = nominee;

                debval = true;
                while (debval)
                {
                    Console.WriteLine("Enter account balance: ");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance > db.maxBalance)
                    {
                        Console.WriteLine("Debit Account max value is 100000!");
                        debval = true;
                    }
                    else
                    {
                        myBalance[idnum] = balance;
                        debval = false;
                    }
                }
                debval = true;

                Console.WriteLine("Created debit account successfully...! ");
                id = Id.generate();
                id = id + "Deb";
                Console.WriteLine("Your Account Id : " + id);
                GetAcc(id);
            }
            else if (input == "2")
            {
                accType = "Credit";
                myAccType[idnum] = accType;
                Console.Write("Name:");

                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;

                val = true;
                while (val)
                {
                    Console.WriteLine("Enter date of birth (Sample: 23/08/1995): ");
                    string dobInput = Console.ReadLine();

                    if (dob.set(dobInput)) // If date is valid
                    {
                        myDob[idnum] = dobInput; // Store the date
                        val = false;
                    }
                    else
                    {
                        val = true;
                    }
                }

                Console.WriteLine("Enter Nominee name: ");
                nominee = Convert.ToString(Console.ReadLine());
                myNominee[idnum] = nominee;

                debval = true;
                while (debval)
                {
                    Console.WriteLine("Enter account balance: ");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance < cr.minBalance)
                    {
                        Console.WriteLine("Credit Account's min value is -100000!");
                        debval = true;
                    }
                    else
                    {
                        myBalance[idnum] = balance;
                        debval = false;
                    }
                }
                debval = true;

                Console.WriteLine("Created Credit account successfully...! ");
                id = Id.generate();
                id = id + "Cre";
                Console.WriteLine("Your Account Id : " + id);
                GetAcc(id);
            }
            else if (input == "3")
            {
                accType = "Savings";
                myAccType[idnum] = accType;
                Console.Write("Name:");

                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;

                val = true;
                while (val)
                {
                    Console.WriteLine("Enter date of birth (Sample: 23/08/1995): ");
                    string dobInput = Console.ReadLine();

                    if (dob.set(dobInput)) // If date is valid
                    {
                        myDob[idnum] = dobInput; // Store the date
                        val = false;
                    }
                    else
                    {
                        val = true;
                    }
                }

                Console.WriteLine("Enter Nominee name: ");
                nominee = Convert.ToString(Console.ReadLine());
                myNominee[idnum] = nominee;

                Console.WriteLine("Enter account balance: ");
                balance = Convert.ToDouble(Console.ReadLine());
                myBalance[idnum] = balance;

                Console.WriteLine("Created Savings account successfully...! ");
                id = Id.generate();
                id = id + "Sav";
                Console.WriteLine("Your Account Id : " + id);
                GetAcc(id);
            }
        }

        public void deposit()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to deposit: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.deposit(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Credit")
                {
                    cr.balance = myBalance[indexNum];
                    cr.deposit(depval);
                    myBalance[indexNum] = cr.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.deposit(depval);
                    myBalance[indexNum] = sv.balance;
                }

                AddTransaction(inId, "Deposit", depval);
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }
        }

        public void withdraw()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to withdraw: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.withdraw(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Credit")
                {
                    cr.balance = myBalance[indexNum];
                    cr.withdraw(depval);
                    myBalance[indexNum] = cr.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.withdraw(depval);
                    myBalance[indexNum] = sv.balance;
                }

                AddTransaction(inId, "Withdraw", depval);
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }
        }
    }
}

namespace BMS
{
    class DOB
    {
        public int day;
        private int month;
        private int year;

        public bool set(string dateInput)
        {
            string[] dateParts = dateInput.Split('/');

            if (dateParts.Length == 3 &&
                int.TryParse(dateParts[0], out day) &&
                int.TryParse(dateParts[1], out month) &&
                int.TryParse(dateParts[2], out year))
            {
                if (checkDate())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use dd/mm/yyyy.");
                return false;
            }
        }

        public bool checkDate()
        {
            if (day > 31 || month > 12 || year > 2016 || day < 1 || month < 1 || year < 1900)
            {
                Console.WriteLine("Invalid date.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void printDate()
        {
            if (checkDate())
            {
                Console.WriteLine($"Date is: {day}-{month}-{year} (Sample: 23/08/1995)");
            }
            else
            {
                Console.WriteLine("Please enter a valid date.");
            }
        }
    }
}

namespace BMS
{
    class IDGenerator
    {
        static int id = 0;
        string storeId;
        DateTime date = DateTime.Now;

        public string generate()
        {
            string gid = DateTime.Now.ToString("yyyy-MM-");
            storeId = gid + ++id;

            return storeId;
        }
    }
}

namespace BMS
{
    class Transaction
    {
        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string type, double amount)
        {
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Date.ToString("yyyy-MM-dd HH:mm:ss")} - {Type}: {Amount}";
        }
    }
}
