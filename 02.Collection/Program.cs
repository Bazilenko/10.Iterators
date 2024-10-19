class Program
{
    static void Main()
    {
        Menu();
    }
    static void Menu()
    {
        List<string> listStr = null;
        List<int> listInt = null;
        ListyIterator<int> listyInt = null;
        ListyIterator<string> listyStr = null;
        string[] commands;
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            commands = command.Split(" ");
            switch (commands[0])
            {
                case "Create":
                    if (int.TryParse(commands[1], out _))
                    {
                        listInt = new List<int>();
                        for (int i = 1; i < commands.Length; i++)
                            listInt.Add(int.Parse(commands[i]));
                       listyInt = new ListyIterator<int>(listInt);
                    }
                    else
                    {
                        listStr = new List<string>();
                        for (int i = 1; i < commands.Length; i++)
                        {
                            listStr.Add(commands[i]);
                        }
                        ListyIterator<string> listyString = new ListyIterator<string>(listStr);
                    }
                    break;
                case "PrintAll":
                    try
                    {
                        if (listStr != null)
                        {
                            listyStr.PrintAll();
                        }
                        else if (listInt != null)
                        {
                            listyInt.PrintAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "HasNext":
                    if (listStr != null)
                    {
                        Console.WriteLine(listyStr.HasNext());
                    }
                    else if (listInt != null)
                    {
                        Console.WriteLine(listyInt.HasNext());
                    }
                    break;
                case "Move":
                    if (listStr != null)
                    {
                        Console.WriteLine(listyStr.Move());
                    }
                    else if (listInt != null)
                    {
                        Console.WriteLine(listyInt.Move());
                    }
                    break;

            }
        }
    }
}