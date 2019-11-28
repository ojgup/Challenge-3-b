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
    public class RoomsWithComputersController : ApiController
    {
        // GET: api/RoomsWithComputers
        public IEnumerable<Room> Get()
        {
            List<Computer> listOfComputers = new List<Computer>();

            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();

            SqlCommand getClass = new SqlCommand("SELECT COMPUTER.NUMBER, COMPUTER.AssembledYear, R.BUILDING, R.ROOMNO, R.CAPACITY FROM COMPUTER INNER JOIN ROOM R ON COMPUTER.BUILDING = R.BUILDING AND COMPUTER.ROOMNO = R.ROOMNO", conn);

            SqlDataReader dataReader = getClass.ExecuteReader();

            while (dataReader.Read())
            {
                listOfComputers.Add(new Computer(int.Parse(dataReader[0].ToString()), int.Parse(dataReader[1].ToString()), new Room(dataReader[2].ToString(), int.Parse(dataReader[3].ToString()),
                    int.Parse(dataReader[4].ToString()))));
            }

            HashSet<Room> roomsWithComputers = new HashSet<Room>();


            for(int i =0; i< listOfComputers.Count(); i++)
            {
                if (!roomsWithComputers.Contains(listOfComputers[i].Room))
                {
                    roomsWithComputers.Add(listOfComputers[i].Room);
                }
         
            }
            return roomsWithComputers;
        }

        // GET: api/RoomsWithComputers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RoomsWithComputers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomsWithComputers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomsWithComputers/5
        public void Delete(int id)
        {
        }
    }
}
