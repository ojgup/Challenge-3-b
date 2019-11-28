using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Challenge_3_b.Models;
namespace Challenge_3_b.Controllers
{
    public class RoomsController : ApiController
    {
        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();
            SqlCommand getRooms = new SqlCommand("SELECT * FROM ROOM", conn);
            SqlCommand getClass = new SqlCommand("SELECT CLASS.CLASSCODE, CLASS.NAME, R.BUILDING, R.ROOMNO, R.CAPACITY FROM CLASS INNER JOIN ROOM R ON CLASS.BUILDING = R.BUILDING AND CLASS.ROOMNO = R.ROOMNO", conn);


            SqlDataReader datareader = getRooms.ExecuteReader();

            List<Room> listOfRooms = new List<Room>();

            while(datareader.Read())
            {
                listOfRooms.Add(new Room(datareader[0].ToString(), int.Parse(datareader[1].ToString()), int.Parse(datareader[2].ToString())));

            }

            return listOfRooms;
        }

        // GET: api/Rooms/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rooms
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
        }
    }
}
