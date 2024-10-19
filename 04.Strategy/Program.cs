using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        SortedSet<Person> nameSorted = new SortedSet<Person>(new NameComparer());
        SortedSet<Person> ageSorted = new SortedSet<Person>(new AgeComparer());

        int counter = int.Parse(Console.ReadLine());
        for (int i = 0; i < counter; i++)
        {
            var personArgs = Console.ReadLine().Split();
            var person = new Person(personArgs[0], int.Parse(personArgs[1]));

            nameSorted.Add(person);
            ageSorted.Add(person);
        }

        foreach (var name in nameSorted)
        {
            Console.WriteLine(name);
        }

        foreach (var age in ageSorted)
        {
            Console.WriteLine(age);
        }

    }
}