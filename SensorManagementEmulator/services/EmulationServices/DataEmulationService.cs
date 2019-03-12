using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorManagementEmulator;
using SensorManagementEmulator.Constants;
using SensorManagementEmulator.Models;

namespace SensorManagementEmulatorDataEmulation
{
    public class DataEmulationService
    {
        public Action<bool> StopEmulation;
        public async Task EmulateDouble(Sensor<double> sensor, string database, string table)
        {
            bool duration = true;

            StopEmulation += b => { duration = false; };

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username,DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();
            Random randomDouble = new Random();
            DBInsertionService insertData = new DBInsertionService();
            while (duration)
            {
                insertData.InsertSensorData(database, table, randomDouble.NextDouble(), DateTimeOffset.Now.ToUnixTimeMilliseconds(), false, false, (int)sensor.Id,dBconnection);
               await Task.Delay(sensor.GenInterValue);
            }
            dBconnection.DataBaseConnection.Close();
        }
        public async Task EmulateDoubleList(Sensor<double> sensor, string database, string table)
        {
            bool duration = true;
            Stopwatch watch = new Stopwatch();
            List<SensorValueData> data = new List<SensorValueData>();
            StopEmulation += b => { duration = false; };

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();
            Random randomDouble = new Random();
            DBInsertionService insertData = new DBInsertionService();
            int i = 0;
            watch.Start();
            while (duration)
            {
                data.Add(new SensorValueData
                {
                    Data = GetRandomDoubleNumber(sensor.MinValue, sensor.MaxValue), Time = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                });
                if (watch.ElapsedMilliseconds > 1000)
                {
                    await Task.Factory.StartNew(()=>insertData.InsertSensorListData(database, table, data, false, false, (int) sensor.Id, dBconnection));
                    data.Clear();
                    watch.Reset();
                    watch.Start();
                    
                }

                await Task.Delay(sensor.GenInterValue);
            }
            dBconnection.DataBaseConnection.Close();
        }
        private double GetRandomDoubleNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
