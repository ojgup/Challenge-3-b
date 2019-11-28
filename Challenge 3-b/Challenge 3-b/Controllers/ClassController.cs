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
    public class ClassController : ApiController
    {
        // GET: api/Class

        List<Class> listOfClasses = new List<Class>(); 
        public IEnumerable<Class> Get()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();

            SqlCommand getClass = new SqlCommand("SELECT CLASS.CLASSCODE, CLASS.NAME, R.BUILDING, R.ROOMNO, R.CAPACITY FROM CLASS INNER JOIN ROOM R ON CLASS.BUILDING = R.BUILDING AND CLASS.ROOMNO = R.ROOMNO", conn);

            SqlDataReader dataReader = getClass.ExecuteReader();

            while(dataReader.Read())
            {
                listOfClasses.Add(new Class(dataReader[0].ToString(), dataReader[1].ToString(), new Room(dataReader[2].ToString(), int.Parse(dataReader[3].ToString()),
                    int.Parse(dataReader[4].ToString())) ));
            }
            return listOfClasses;
        }
        
        // GET: api/Class/5
        public Class Get(string id)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();

            string getClass = "SELECT CLASS.CLASSCODE, CLASS.NAME, R.BUILDING, R.ROOMNO, R.CAPACITY FROM CLASS " +
                "INNER JOIN ROOM R ON (CLASS.BUILDING = R.BUILDING AND CLASS.ROOMNO = R.ROOMNO)" + "WHERE CLASS.CLASSCODE = @id";
            SqlDataAdapter da = new SqlDataAdapter(getClass, conn);

            

            SqlCommand com = new SqlCommand(getClass, conn);
            com.Parameters.AddWithValue("@id", id);

            com.ExecuteNonQuery();

            SqlDataReader dataReader = com.ExecuteReader();

            Class classPicked;

            while (dataReader.Read())
            {
                classPicked = new Class(dataReader[0].ToString(), dataReader[1].ToString(), new Room(dataReader[2].ToString(), int.Parse(dataReader[3].ToString()),
                    int.Parse(dataReader[4].ToString())));

                return classPicked;
            }


            return null;
        }

        // POST: api/Class
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Class/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Class/5
        public void Delete(int id)
        {
        }
    }
}
