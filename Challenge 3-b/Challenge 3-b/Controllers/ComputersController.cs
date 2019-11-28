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
    public class ComputersController : ApiController
    {
        // GET: api/Computers
        public IEnumerable<Computer> Get()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();
            SqlCommand getComputers = new SqlCommand("SELECT C.NUMBER, C.AssembledYear, ROOM.BUILDING, ROOM.ROOMNO, ROOM.CAPACITY " +
                "FROM COMPUTER C INNER JOIN ROOM ON ROOM.ROOMNO = C.ROOMNO AND ROOM.BUILDING = C.BUILDING; ", conn);
           
            SqlDataReader datareader = getComputers.ExecuteReader();

            List<Computer> listOfComputers = new List<Computer>();

            while (datareader.Read())
            {
                listOfComputers.Add(new Computer(int.Parse(datareader[0].ToString()), int.Parse(datareader[1].ToString()), 
                    new Room(datareader[2].ToString(), int.Parse(datareader[3].ToString()), int.Parse(datareader[4].ToString()) ) 
                    ));

            }

            return listOfComputers;
        }

        // GET: api/Computers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Computers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Computers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Computers/5
        public void Delete(int id)
        {
        }
    }
}
