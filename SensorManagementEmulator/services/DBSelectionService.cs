using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SensorManagementEmulator.Models;

namespace SensorManagementEmulator
{
    public class DBSelectionService
    {
        public static IList<Sensor<double>> GetSensors()
        {
            List<Sensor<double>> sensors = new List<Sensor<double>>();
            DBconnectionService.DataBaseConnection.Open();
            using (DBconnectionService.DataBaseConnection)
            {
                string oString = @"SELECT
                Sensors.*
                    FROM Sensors";

                MySqlCommand oCmd = new MySqlCommand(oString, DBconnectionService.DataBaseConnection);
                Sensor<double> sensor = new Sensor<double>();
                MySqlDataReader oReader = oCmd.ExecuteReader();

                while (oReader.Read())
                {
                    sensors.Add(new Sensor<double>
                    {
                        Id = long.Parse(oReader["idSensor"].ToString()),
                        Name = oReader["Name"].ToString(),
                        Type = oReader["Type"].ToString(),
                        MinValue = double.Parse(oReader["MinValue"].ToString()),
                        MaxValue = double.Parse(oReader["MaxValue"].ToString()),
                        GenInterValue = int.Parse(oReader["GenInterValue"].ToString()),
                    });
                }
            }
            DBconnectionService.DataBaseConnection.Close();
            return sensors;
        }

        public static Sensor<double> GetSensorById(int sensorId)
        {
            DBconnectionService.DataBaseConnection.Open();
            Sensor<double> sensor = new Sensor<double>();
            using (DBconnectionService.DataBaseConnection)
            {
                string oString = @"SELECT
                Sensors.*
                    FROM Sensors
                    WHERE Sensors.idSensor = @id";

                MySqlCommand oCmd = new MySqlCommand(oString, DBconnectionService.DataBaseConnection);
                oCmd.Parameters.AddWithValue(@"id", sensorId);
                MySqlDataReader oReader = oCmd.ExecuteReader();

                while (oReader.Read())
                {

                    sensor = new Sensor<double>()
                    {
                        Id = long.Parse(oReader["idSensor"].ToString()),
                        Name = oReader["Name"].ToString(),
                        Type = oReader["Type"].ToString(),
                        MinValue = double.Parse(oReader["MinValue"].ToString()),
                        MaxValue = double.Parse(oReader["MaxValue"].ToString()),
                        GenInterValue = int.Parse(oReader["GenInterValue"].ToString()),
                    };
                }
            }
            DBconnectionService.DataBaseConnection.Close();
            return sensor;
        }
    }
}
