using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SensorManagementEmulator.Constants;
using SensorManagementEmulator.Models;

namespace SensorManagementEmulator.services
{
    public static class DBDeleteService
    {
        public static void DeleteById(int id)
        {
            string oString = @"USE Emulator;

            DELETE FROM Sensors
            WHERE
            idSensor = @Id
            ;";

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();

            MySqlCommand oCmd = new MySqlCommand(oString, dBconnection.DataBaseConnection);
            oCmd.Parameters.AddWithValue("@Id", id);
            oCmd.Prepare();
            oCmd.ExecuteNonQuery();
            dBconnection.DataBaseConnection.Close();
        }
    }
}
