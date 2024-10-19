using System;
using System.Collections;
public class ListyIterator<T> 
{
	List<T> list;
	int currIndex;
	public ListyIterator()
	{
		list = new List<T> ();
		currIndex = 0;
	}
	public bool Move()
	{
		if (HasNext())
		{
			currIndex++;
			return true;
		}
		return false;
	}
	public bool HasNext()
	{
		if (currIndex == list.Count - 1)
			return false;
		return true;
	}
	public void Print()
	{
		if (list.Count == 0)
			throw new ArgumentException("Collection is empty");
		Console.WriteLine(list[currIndex]);
	}

	public void AddElement(T element)
	{
		list.Add(element);
	}
   
	
    
}


