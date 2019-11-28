using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Challenge_3_b.Models;
using System.Data.SqlClient;

namespace Challenge_3_b.Controllers
{
    public class RoomsUnusedController : ApiController
    {
        // GET: api/RoomsUnused
        public IEnumerable<Room> Get()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();
            SqlCommand getRooms = new SqlCommand("SELECT * FROM ROOM", conn);

            SqlDataReader datareader = getRooms.ExecuteReader();

            List<Room> listOfRooms = new List<Room>();

            while (datareader.Read())
            {
                listOfRooms.Add(new Room(datareader[0].ToString(), int.Parse(datareader[1].ToString()), int.Parse(datareader[2].ToString())));

            }


            conn.Close();


            List<Class> listOfClasses = new List<Class>();


            conn.Open();
            SqlCommand getClass = new SqlCommand("SELECT CLASS.CLASSCODE, CLASS.NAME, R.BUILDING, R.ROOMNO, R.CAPACITY FROM CLASS INNER JOIN ROOM R ON CLASS.BUILDING = R.BUILDING AND CLASS.ROOMNO = R.ROOMNO", conn);
            
            datareader = getClass.ExecuteReader();

            while (datareader.Read())
            {
                listOfClasses.Add(new Class(datareader[0].ToString(), datareader[1].ToString(), new Room(datareader[2].ToString(), int.Parse(datareader[3].ToString()),
                    int.Parse(datareader[4].ToString()))));
            }
            conn.Close();

            foreach(Class currentClass in listOfClasses)
            {
                for(int i = 0; i < listOfRooms.Count; i++)
                {

                    if(currentClass.Room.RoomNo == listOfRooms[i].RoomNo && currentClass.Room.Building == listOfRooms[i].Building && currentClass.Room.Capacity == listOfRooms[i].Capacity)
                    {
                        listOfRooms.Remove(listOfRooms[i]);
                    }
                }
            }

            return listOfRooms;
        }

        // GET: api/RoomsUnused/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RoomsUnused
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomsUnused/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomsUnused/5
        public void Delete(int id)
        {
        }
    }
}
