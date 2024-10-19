using System;

class Program
{
    static void Main()
    {
        Menu();
    }
    static void Menu()
    {
        List<Person> people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string city = tokens[2];

            people.Add(new Person(name, age, city));
        }

        int n = int.Parse(Console.ReadLine()) - 1;
        Person personToCompare = people[n];

        int equalCount = 0;
        int notEqualCount = 0;

        foreach (var person in people)
        {
            if (person.CompareTo(personToCompare) == 0)
            {
                equalCount++;
            }
            else
            {
                notEqualCount++;
            }
        }

        if (equalCount < 2)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalCount} {notEqualCount} {people.Count}");
        }
    
}
}
