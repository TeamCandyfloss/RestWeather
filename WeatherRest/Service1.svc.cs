﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Windows.Markup;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using WeatherRest.model;

namespace WeatherRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static string _place; 
           

        private string _connectionString = "Server=tcp:3semesterxxx.database.windows.net,1433;Initial Catalog=WCFSTUDENT;Persist Security Info=False;User ID=Admeme;Password=Skole123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<MTemperature> GetAllTemperatures()
        {
            string sqlQuery = "SELECT * FROM Temperature";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var temperatureList = connection.Query<MTemperature>(sqlQuery).ToList();

                return temperatureList;
            }
        }

        public MTemperature GetTemperature(string id)
        {
            string sqlQuery = $"SELECT * FROM Temperature WHERE Id={id}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var specificTemperature = connection.Query<MTemperature>(sqlQuery).ToList();

                return specificTemperature[0];
            }
        }

        public List<MTemperature> GetSpecificTemperatures(string place)
        {
            string sqlQuery = $"SELECT * FROM Temperature WHERE Place='{place}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var tempList = connection.Query<MTemperature>(sqlQuery).ToList();

                return tempList;
            }
        }

        public List<MTemperature> GetSpecificTemperatureByDate(string date)
        {
            string sqlQuery = $"SELECT * FROM Temperature WHERE Date='{date}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var tempList = connection.Query<MTemperature>(sqlQuery).ToList();

                return tempList;
            }
        }

        public bool AddTemperature(MTemperature temp)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "INSERT INTO Temperature (Temperature, Time, Place) VALUES (@Temperature, @Time, @Place)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Temperature", temp.Temperature);
                    command.Parameters.AddWithValue("@Time", temp.Time);
                    command.Parameters.AddWithValue("@Place", temp.Place);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into the database.");
                    }
                }

                return true;
            }

        }

        public bool SetTemp(string temp)
        {
            var time = DateTime.Now.ToShortTimeString();

            DateTime dt = DateTime.Now;
            var currentDate = dt.ToString("MM dd yyyy");

            string[] values = currentDate.Split();

            string month = values[0];
            string day = values[1];
            string year = values[2];

            var date = month + "-" + day + "-" + year;


            if (_place == null || time == null || temp == null)
            {
                throw new ArgumentException("Du kan ikke indsætte en Null værdi");
            }

            var _connectionString = "Server=tcp:3semesterxxx.database.windows.net,1433;Initial Catalog=WCFSTUDENT;Persist Security Info=False;User ID=Admeme;Password=Skole123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlQuery =
                    "INSERT INTO Temperature (Temperature, Time, Place, Date) VALUES (@Temperature, @Time, @Place, @Date)";

                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Temperature", temp);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@Place", _place);
                    command.Parameters.AddWithValue("@Date", date);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                    {
                        throw new ArgumentException("Nothing has been added to the Database");
                    }

                    return true;

                    // tjekker for fejl i indsættelsen skriver hvis der er fejl
                }
            }
        }

        public void SetPlace(mPlace place)
        {
            _place = place.Place;
        }

        public bool DeleteTemperature(MTemperature temp)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = $"DELETE FROM Temperature WHERE id=@id";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", temp.ID);

                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        Console.WriteLine("Error deleting data from the database.");
                    }

                    return true;
                }
            }
        }

        public MTemperature UpdateTemperature(MTemperature temp)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = $"UPDATE Temperature SET place=@Place WHERE id=@id";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@place", temp.Place);
                    command.Parameters.AddWithValue("@id", temp.ID);
                    
                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        Console.WriteLine("Error updating data inside the database.");
                    }

                    return temp;
                }
            }
        }

        public MTemperature GetCurrentTemperature()
        {
            string sqlQuery = "SELECT * FROM Temperature";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var temperatureList = connection.Query<MTemperature>(sqlQuery).ToList();

                var currentTemp = temperatureList.Count - 1;

                return temperatureList[currentTemp];
            }
        }
    }
}
