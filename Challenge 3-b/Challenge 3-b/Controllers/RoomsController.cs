using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
namespace Challenge_3_b.Controllers
{
    public class RoomsController : ApiController
    {
        // GET: api/Rooms
        public IEnumerable<string> Get()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();
            SqlCommand getRooms = new SqlCommand("SELECT * FROM ROOM", conn);

            SqlDataReader datareader = getRooms.ExecuteReader();

            return new string[] { "value1", "value2" };
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
