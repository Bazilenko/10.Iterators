using System;
using System.Collections;


public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> collection;
    private int currentIndex;
    
    public ListyIterator(List<T> collection)
    {
        this.collection = collection;
        this.currentIndex = 0;
    }
   
    public bool Move()
    {
        if (HasNext())
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return currentIndex < collection.Count - 1;
    }

    public void Print()
    {
        if (collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(collection[currentIndex]);
    }

    public void PrintAll()
    {
        if (collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        foreach (var item in collection)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }


    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < collection.Count; i++)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
