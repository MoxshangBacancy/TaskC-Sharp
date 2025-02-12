//using System;
//using System.Collections.Generic;

//List<object> myGenericList = new List<object>();
////adding items to generic list.
//myGenericList.Add(10);
//myGenericList.Add("one");
//myGenericList.Add(1.7);
//myGenericList.Add(true);
//myGenericList.Add("Student");

////getting an element to specific index.
//myGenericList.Remove("one");
//myGenericList.Insert(3, "one");

////removing element by its value.
//myGenericList.Remove(true);

////Printinig all the elements in the list.
//foreach (var i in myGenericList)
//{
//    Console.WriteLine(i);
//}

using System;
using System.Collections.Generic;

public class GenericList<T>
{
    private List<T> items;

    public GenericList()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public T Get(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }
        return items[index];
    }

    public bool Remove(T item)
    {
        return items.Remove(item);
    }

    public void PrintAll()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("The list is empty.");
        }
        else
        {
            Console.WriteLine("Elements in the list:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public int Count => items.Count;
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name}, Age: {Age}";
    }

    //public override bool Equals(object obj)
    //{
    //    if (obj == null || GetType() != obj.GetType())
    //        return false;

    //    Student other = (Student)obj;
    //    return Name == other.Name && Age == other.Age;
    //}

    //public override int GetHashCode()
    //{
    //    return HashCode.Combine(Name, Age);
    //}
}

class Program
{
    static void Main()
    {
        // Declare the lists globally
        GenericList<int> intList = new GenericList<int>();
        GenericList<string> stringList = new GenericList<string>();
        GenericList<Student> studentList = new GenericList<Student>();

        Console.WriteLine("Choose the type of Generic List to create:");
        Console.WriteLine("1. Integer List");
        Console.WriteLine("2. String List");
        Console.WriteLine("3. Student List");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                // Integer list
                Console.WriteLine("Enter integers (enter 'done' to stop):");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "done") break;
                    if (int.TryParse(input, out int result))
                    {
                        intList.Add(result);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                }
                intList.PrintAll();
                break;

            case 2:
                // String list
                Console.WriteLine("Enter strings (enter 'done' to stop):");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "done") break;
                    stringList.Add(input);
                }
                stringList.PrintAll();
                break;

            case 3:
                // Student list
                Console.WriteLine("Enter student details (name, age). Enter 'done' to stop:");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "done") break;

                    string[] details = input.Split(',');
                    if (details.Length == 2 && int.TryParse(details[1], out int age))
                    {
                        Student student = new Student(details[0].Trim(), age);
                        studentList.Add(student);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter name and age separated by a comma.");
                    }
                }
                studentList.PrintAll();
                break;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        // Perform operations like Get and Remove
        Console.WriteLine("Enter index to get an element (0-based):");
        int index = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine($"Element at index {index}: {intList.Get(index)}");
                break;
            case 2:
                Console.WriteLine($"Element at index {index}: {stringList.Get(index)}");
                break;
            case 3:
                Console.WriteLine($"Element at index {index}: {studentList.Get(index)}");
                break;
        }

        // Remove an element from the list
        Console.WriteLine("Enter an element to remove (enter 'done' to stop):");
        string removeInput = Console.ReadLine();
        if (removeInput.ToLower() != "done")
        {
            bool removed = false;

            switch (choice)
            {
                case 1:
                    if (int.TryParse(removeInput, out int valueToRemove))
                    {
                        removed = intList.Remove(valueToRemove);
                    }
                    break;
                case 2:
                    removed = stringList.Remove(removeInput);
                    break;
                case 3:
                    string[] studentDetails = removeInput.Split(',');
                    if (studentDetails.Length == 2 && int.TryParse(studentDetails[1], out int ageToRemove))
                    {
                        Student studentToRemove = new Student(studentDetails[0].Trim(), ageToRemove);
                        removed = studentList.Remove(studentToRemove);
                    }
                    break;
            }

            if (removed)
                Console.WriteLine("Element removed.");
            else
                Console.WriteLine("Element not found.");
        }

        // Print final list
        Console.WriteLine("Final List:");
        switch (choice)
        {
            case 1:
                intList.PrintAll();
                break;
            case 2:
                stringList.PrintAll();
                break;
            case 3:
                studentList.PrintAll();
                break;
        }
    }
}

