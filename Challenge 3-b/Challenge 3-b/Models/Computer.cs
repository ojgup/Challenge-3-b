using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_3_b.Models
{
    public class Computer
    {
        public int Number;
        public int AssembledYear;
        public Room Room;

        public Computer(int number, int assembledYear, Room room)
        {
            this.Number = number;
            this.AssembledYear = assembledYear;
            this.Room = room;
        }
    }
}