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

            while (datareader.Read())
            {
                listOfRooms.Add(new Room(datareader[0].ToString(), int.Parse(datareader[1].ToString()), int.Parse(datareader[2].ToString())));

            }

            return listOfRooms;
        }

        // GET: api/RoomsWithComputers

       // [Route("Rooms/Computers")]
       [HttpGet]
        public IEnumerable<Room> RoomsWithComputers()
            {
                List<Computer> listOfComputers = new List<Computer>();
                HashSet<Room> roomsWithComputers = new HashSet<Room>();
            
            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();

            SqlCommand getClass = new SqlCommand("SELECT COMPUTER.NUMBER, COMPUTER.AssembledYear, R.BUILDING, R.ROOMNO, R.CAPACITY FROM COMPUTER INNER JOIN ROOM R ON COMPUTER.BUILDING = R.BUILDING AND COMPUTER.ROOMNO = R.ROOMNO", conn);

            SqlDataReader dataReader = getClass.ExecuteReader();

            while (dataReader.Read())
            {
                listOfComputers.Add(new Computer(int.Parse(dataReader[0].ToString()), int.Parse(dataReader[1].ToString()), new Room(dataReader[2].ToString(), int.Parse(dataReader[3].ToString()),
                    int.Parse(dataReader[4].ToString()))));
            }




            for (int i = 0; i < listOfComputers.Count(); i++)
            {
                if (!roomsWithComputers.Contains(listOfComputers[i].Room))
                {
                    roomsWithComputers.Add(listOfComputers[i].Room);
                }

            }
            
            return roomsWithComputers;
            }


        [HttpGet]

        public IEnumerable<Room> unused()
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

            foreach (Class currentClass in listOfClasses)
            {
                for (int i = 0; i < listOfRooms.Count; i++)
                {

                    if (currentClass.Room.RoomNo == listOfRooms[i].RoomNo && currentClass.Room.Building == listOfRooms[i].Building && currentClass.Room.Capacity == listOfRooms[i].Capacity)
                    {
                        listOfRooms.Remove(listOfRooms[i]);
                    }
                }
            }

            return listOfRooms;
        }

        [HttpGet]

        public IEnumerable<Class> used()
        {
            List<Class> listOfClasses = new List<Class>();

            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();

            SqlCommand getClass = new SqlCommand("SELECT CLASS.CLASSCODE, CLASS.NAME, R.BUILDING, R.ROOMNO, R.CAPACITY FROM CLASS INNER JOIN ROOM R ON CLASS.BUILDING = R.BUILDING AND CLASS.ROOMNO = R.ROOMNO", conn);

            SqlDataReader dataReader = getClass.ExecuteReader();

            while (dataReader.Read())
            {
                listOfClasses.Add(new Class(dataReader[0].ToString(), dataReader[1].ToString(), new Room(dataReader[2].ToString(), int.Parse(dataReader[3].ToString()),
                    int.Parse(dataReader[4].ToString()))));
            }
            return listOfClasses;
        }


        // GET: api/Rooms/5
        public string Get(int id)
            {
                return "value";
            }

        }
    }
