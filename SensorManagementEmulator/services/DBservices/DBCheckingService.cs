using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SensorManagementEmulator.Constants;

namespace SensorManagementEmulator.services
{
    public static class DBCheckingService
    {
        public static bool TableExists(int sensorId)
        {
            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username,DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();
            string creationString = @"
USE SensorData;
SELECT * FROM " + "Sensor" +sensorId + @"
   LIMIT 1;";
            MySqlCommand tableCreationCmd = new MySqlCommand(creationString, dBconnection.DataBaseConnection);
            tableCreationCmd.Prepare();

            try
            {
                tableCreationCmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
               dBconnection.DataBaseConnection.Close();
                return false;
                
            }
            dBconnection.DataBaseConnection.Close();
            return true;
        }
    }
}
