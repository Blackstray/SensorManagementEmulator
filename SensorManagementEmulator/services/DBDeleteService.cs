using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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

            DBconnectionService.DataBaseConnection.Open();
            MySqlCommand oCmd = new MySqlCommand(oString, DBconnectionService.DataBaseConnection);
            oCmd.Parameters.AddWithValue("@Id", id);
            oCmd.Prepare();
            oCmd.ExecuteNonQuery();
            DBconnectionService.DataBaseConnection.Close();
        }
    }
}
