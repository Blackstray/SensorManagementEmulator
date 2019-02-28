using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SensorManagementEmulator.Models;

namespace SensorManagementEmulator
{
    public static class DBInsertionService
    {
        public static void Insert(Sensor<double> sensor)
        {
            string oString = @"
                USE Emulator;

            INSERT INTO Sensors
            (
                Name
                , Type
                , MinValue
                ,`MaxValue`
                , GenInterValue
                )
            VALUES
            (
                @Name
                , @Type
                , @MinValue
                , @MaxValue
                , @GenInterValue
                );
            ";
            DBconnectionService.DataBaseConnection.Open();
            MySqlCommand oCmd = new MySqlCommand(oString, DBconnectionService.DataBaseConnection);
            oCmd.Parameters.AddWithValue("@Name", sensor.Name);
            oCmd.Parameters.AddWithValue("@Type", sensor.Type);
            oCmd.Parameters.AddWithValue("@MinValue", sensor.MinValue);
            oCmd.Parameters.AddWithValue("@MaxValue", sensor.MaxValue);
            oCmd.Parameters.AddWithValue("@GenInterValue", sensor.GenInterValue);
            oCmd.Prepare();
            oCmd.ExecuteNonQuery();
            DBconnectionService.DataBaseConnection.Close();
        }
    }
}
