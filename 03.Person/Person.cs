    using System;

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            if (result == 0)
            {
                result = this.City.CompareTo(other.City);
            }
            return result;
        }
    }
public class Sorter
{
    public static void Sort(List<Person> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 1; j < list.Count - i; j++)
            {

                if (list[j - 1].CompareTo(list[j]) > 0)
                {
                    Swap(list, j - 1, j);
                }
            }
        }
    }
    public static void Swap(List<Person> p, int ind1, int ind2)
    {
        Person t = p[ind1];
        p[ind1] = p[ind2];
        p[ind2] = t;

    }
}

