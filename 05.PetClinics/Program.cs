using System;
using System.Collections.Generic;

public class Program
{
    private static List<Pet> pets;
    private static List<Clinic> clinics;

    public static void Main()
    {
        pets = new List<Pet>();
        clinics = new List<Clinic>();
        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            string[] args = Console.ReadLine().Split(' ');
            string command = args[0];

            switch (command)
            {
                case "Create":
                    Create(args);
                    break;

                case "Add":
                    Pet currentPet = FindPetByName(args[1]);
                    Clinic clinicForAdd = FindClinicByName(args[2]);
                    if (clinicForAdd != null && currentPet != null)
                    {
                        Console.WriteLine(clinicForAdd.AddPet(currentPet));
                    }
                    break;

                case "Release":
                    Clinic clinicForRelease = FindClinicByName(args[1]);
                    if (clinicForRelease != null)
                    {
                        Console.WriteLine(clinicForRelease.Release());
                    }   
                    break;

                case "HasEmptyRooms":
                    Clinic clinicForRoomsCheck = FindClinicByName(args[1]);
                    if (clinicForRoomsCheck != null)
                    {
                        Console.WriteLine(clinicForRoomsCheck.HasEmptyRooms());
                    }
                    break;

                case "Print":
                    Print(args);
                    break;
            }
        }
    }

    static void Print(string[] args)
    {
        string clinicName = args[1];
        Clinic currentClinic = FindClinicByName(clinicName);

        if (currentClinic == null)
        {
            return;
        }

        if (args.Length == 2)
        {
            for (int i = 0; i < currentClinic.Rooms.Length; i++)
            {
                Pet pet = currentClinic.Rooms[i];
                if (pet != null)
                {
                    Console.WriteLine(pet);
                }
                else
                {
                    Console.WriteLine("Room empty");
                }
            }
        }

        else if (args.Length == 3)
        {
            int room = int.Parse(args[2]);
            Console.WriteLine(currentClinic.Print(room));
        }
    }

    static void Create(string[] args)
    {
        if (args[1].Equals("Pet"))
        {
            string petName = args[2];
            int petAge = int.Parse(args[3]);
            string kind = args[4];

            pets.Add(new Pet(petName, petAge, kind));
        }

        else if (args[1].Equals("Clinic"))
        {
            string clinicName = args[2];
            int roomsCount = int.Parse(args[3]);

            try
            {
                clinics.Add(new Clinic(clinicName, roomsCount));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static Pet FindPetByName(string name)
    {
        foreach (Pet pet in pets)
        {
            if (pet.Name.Equals(name))
            {
                return pet;
            }
        }
        return null;
    }

    static Clinic FindClinicByName(string name)
    {
        foreach (Clinic clinic in clinics)
        {
            if (clinic.Name.Equals(name))
            {
                return clinic;
            }
        }
        return null;
    }
}
