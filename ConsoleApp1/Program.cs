class Program
{
    static void Main()
    {
        Menu();
    }
    static void Menu()
    {
        ListyIterator<string> listStr = null;
        ListyIterator<int> listInt = null;
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
                        listInt = new ListyIterator<int>();
                        for (int i = 1; i < commands.Length; i++)
                            listInt.AddElement(int.Parse(commands[i]));  
                    }
                    else
                    {
                        listStr = new ListyIterator<string>();
                        for (int i = 1; i < commands.Length; i++) 
                            listStr.AddElement(commands[i]);
                    }
                    break;
                case "Print":
                    try
                    {
                        if (listStr != null)
                        {
                            listStr.Print();
                        }
                        else if (listInt != null)
                        {
                            listInt.Print();
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
                        Console.WriteLine(listStr.HasNext());
                    }
                    else if (listInt != null)
                    {
                        Console.WriteLine(listInt.HasNext());
                    }
                    break;
                case "Move":
                    if (listStr != null)
                    {
                        Console.WriteLine(listStr.Move());
                    }
                    else if (listInt != null)
                    {
                        Console.WriteLine(listInt.Move());
                    }
                    break;

            }
        }
    }
}