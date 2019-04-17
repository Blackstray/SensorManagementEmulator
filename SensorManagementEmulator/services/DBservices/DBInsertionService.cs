using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SensorManagementEmulator.Constants;
using SensorManagementEmulator.Models;

namespace SensorManagementEmulator
{
    public  class DBInsertionService
    {
        public void InsertSensor(Sensor<double> sensor)
        {
            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();
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

            MySqlCommand oCmd = new MySqlCommand(oString, dBconnection.DataBaseConnection);
            oCmd.Parameters.AddWithValue("@Name", sensor.Name);
            oCmd.Parameters.AddWithValue("@Type", sensor.Type);
            oCmd.Parameters.AddWithValue("@MinValue", sensor.MinValue);
            oCmd.Parameters.AddWithValue("@MaxValue", sensor.MaxValue);
            oCmd.Parameters.AddWithValue("@GenInterValue", sensor.GenInterValue);
            oCmd.Prepare();
            oCmd.ExecuteNonQuery();
            dBconnection.DataBaseConnection.Close();
        }

        public void InsertSensorData(string database, string table, double value, long time, bool closeConnection, bool openConnection, int sensorId, DBconnectionService dBconnection)
        {  
            string oString = @"
                USE " + database + @";

            INSERT INTO " + table + @"
            (
                SensorId 
                , Time
                , Value
                )
            VALUES
            (   
                 @SensorId
                , @Time
                , @Value
                );
            ";

            MySqlCommand oCmd = new MySqlCommand(oString, dBconnection.DataBaseConnection);
            oCmd.Parameters.AddWithValue("@Value", value);
            oCmd.Parameters.AddWithValue("@Time", time);
            oCmd.Parameters.AddWithValue("@SensorId", sensorId);
            oCmd.ExecuteNonQuery();
        }
        public  void InsertSensorListData(string database, string table, List<SensorValueData> values, bool closeConnection, bool openConnection, int sensorId, DBconnectionService dBconnection)
        {
            string oString = @"
                USE " + database + @";

            INSERT INTO " + table + @"
            (
                SensorId 
                , Time
                , Value
                )
            VALUES";
            foreach (SensorValueData value in values)
            {
                oString += $"({sensorId},{value.Time},{value.Data}),";
            }

            oString = oString.Remove(oString.Length - 1);

            MySqlCommand oCmd = new MySqlCommand(oString, dBconnection.DataBaseConnection);
            oCmd.ExecuteNonQuery();
        }
    }
}

