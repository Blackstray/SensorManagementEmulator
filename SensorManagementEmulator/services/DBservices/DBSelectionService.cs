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
    public class DBSelectionService
    {
        public IList<Sensor<double>> GetSensors()
        {
            List<Sensor<double>> sensors = new List<Sensor<double>>();

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();

            using (dBconnection.DataBaseConnection)
            {
                string oString = @"SELECT
                Sensors.*
                    FROM Sensors";

                MySqlCommand oCmd = new MySqlCommand(oString, dBconnection.DataBaseConnection);
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
            dBconnection.DataBaseConnection.Close();
            return sensors;
        }

        public Sensor<double> GetSensorById(int sensorId)
        {

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();

            Sensor<double> sensor = new Sensor<double>();
            using (dBconnection.DataBaseConnection)
            {
                string oString = @"SELECT
                Sensors.*
                    FROM Sensors
                    WHERE Sensors.idSensor = @id";

                MySqlCommand oCmd = new MySqlCommand(oString, dBconnection.DataBaseConnection);
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
           dBconnection.DataBaseConnection.Close();
            return sensor;
        }
    }
}
