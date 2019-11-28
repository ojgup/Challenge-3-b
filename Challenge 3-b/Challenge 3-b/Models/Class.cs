using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_3_b.Models
{
    public class Class
    {
        public string ClassCode;
        public string Name;
        public Room Room;

        public Class(string classcode, string name, Room room)
        {
            this.ClassCode = classcode;
            this.Name = name;
            this.Room = room;
        }

    }
}