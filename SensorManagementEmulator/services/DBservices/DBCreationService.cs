using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SensorManagementEmulator.Constants;

namespace SensorManagementEmulator.services
{
    public static class DBCreationService
    {

        public static void CreateSensorDataTable(int sensorId)
        {

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();

            string creationString = @"
USE SensorData;
create table " + "Sensor"+ sensorId + @" (
   Value REAL,
   Time VARCHAR(20)
);";
            MySqlCommand tableCreationCmd = new MySqlCommand(creationString, dBconnection.DataBaseConnection);
            tableCreationCmd.Prepare();
            tableCreationCmd.ExecuteNonQuery();
            dBconnection.DataBaseConnection.Close();
        }
    }
}
