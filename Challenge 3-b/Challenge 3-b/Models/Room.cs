using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_3_b.Models
{
    public class Room
    {
        public string Building;
        public int RoomNo;
        public int Capacity; 

        public Room(string building, int roomno, int capacity)
        {
            this.Building = building;
            this.RoomNo = roomno;
            this.Capacity = capacity;
        }
    }
}