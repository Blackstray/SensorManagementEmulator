using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SensorManagementEmulator.Models;

namespace SensorManagementEmulator.services
{
    public static class DBUpdateService
    {
        public static Sensor<double> UpdateSensorByNewSensor(Sensor<double> sensor)
        {
            DBconnectionService.DataBaseConnection.Open();
            using (DBconnectionService.DataBaseConnection)
            {
                string oString = @"
                USE Emulator;

            UPDATE Sensors
            SET
               Name = @Name
                ,Type = @Type
                ,MinValue = @MinValue
                ,`MaxValue` = @MaxValue
                ,GenInterValue = @GenInterValue
                WHERE 
                idSensor = @Id
            ;";

                MySqlCommand oCmd = new MySqlCommand(oString, DBconnectionService.DataBaseConnection);

                oCmd.Parameters.AddWithValue("@Name", sensor.Name);
                oCmd.Parameters.AddWithValue("@Type", sensor.Type);
                oCmd.Parameters.AddWithValue("@MinValue", sensor.MinValue);
                oCmd.Parameters.AddWithValue("@MaxValue", sensor.MaxValue);
                oCmd.Parameters.AddWithValue("@GenInterValue", sensor.GenInterValue);
                oCmd.Parameters.AddWithValue("@Id", sensor.Id);

                oCmd.ExecuteNonQuery();
            }
            DBconnectionService.DataBaseConnection.Close();
            return sensor;
        }
    }
}
