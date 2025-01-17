﻿using System;
using System.Collections;
public class Clinic : IEnumerable<Pet>
{
    private string name;
    private Pet[] rooms;

    public Clinic(string name, int roomsCount)
    {
        this.Name = name;
        this.Rooms = new Pet[roomsCount];
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public Pet[] Rooms
    {
        get { return this.rooms; }

        private set
        {
            if (value.Length % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.rooms = value;
        }
    }

    public bool AddPet(Pet pet)
    {
        int middleRoomIndex = this.Rooms.Length / 2;

        if (this.Rooms[middleRoomIndex] == null)
        {
            this.Rooms[middleRoomIndex] = pet;
            return true;
        }

        int awayFromTheMiddleIndex = 1;
        while (true)
        {
            int roomLeftFromTheMiddle = middleRoomIndex - awayFromTheMiddleIndex;
            if (roomLeftFromTheMiddle >= 0 && this.Rooms[roomLeftFromTheMiddle] == null)
            {
                this.Rooms[roomLeftFromTheMiddle] = pet;
                return true;
            }

            int roomRightFromTheMiddle = middleRoomIndex + awayFromTheMiddleIndex;
            if (roomRightFromTheMiddle < this.Rooms.Length && this.Rooms[roomRightFromTheMiddle] == null)
            {
                this.Rooms[roomRightFromTheMiddle] = pet;
                return true;
            }

            awayFromTheMiddleIndex++;

            if (awayFromTheMiddleIndex > this.Rooms.Length / 2)
            {
                return false;
            }
        }
    }

    public bool Release()
    {
        int currentIndex = this.Rooms.Length / 2;
        int checkedRooms = 0;

        while (true)
        {
            if (this.Rooms[currentIndex % this.Rooms.Length] != null)
            {
                this.Rooms[currentIndex % this.Rooms.Length] = null;
                return true;
            }

            checkedRooms++;  
            if (checkedRooms == this.Rooms.Length)
            {
                return false;
            }

            currentIndex++;
        }
    }

    public bool HasEmptyRooms()
    {
        for (int i = 0; i < this.Rooms.Length; i++)
        {
            if (this.Rooms[i] == null)
            {
                return true;
            }
        }

        return false;
    }


    public string Print(int roomId)
    {
        if (this.Rooms[roomId - 1] != null)
        {
            return this.Rooms[roomId - 1].ToString();
        }

        return "Room empty";
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        foreach (Pet pet in this.Rooms)
        {
            yield return pet;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}