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
            int waitTime = 1000;
            Stopwatch watch = new Stopwatch();
            List<SensorValueData> data = new List<SensorValueData>();
            StopEmulation += b => { duration = false; };

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();
            Random randomDouble = new Random();
            DBInsertionService insertData = new DBInsertionService();
            int i = 0;
            if (waitTime < sensor.GenInterValue-10)
            {
                waitTime = sensor.GenInterValue + 100;
            }
            watch.Start();
            while (duration)
            {
                data.Add(new SensorValueData
                {
                    Data = GetRandomDoubleNumber(sensor.MinValue, sensor.MaxValue), Time = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                });
                if (watch.ElapsedMilliseconds > waitTime)
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
        public async Task EmulateDoubleTemp(Sensor<double> sensor,string which)
        {
            bool duration = true;
            Stopwatch watch = new Stopwatch();

            StopEmulation += b => { duration = false; };
            var fire = new FireBaseDataRetrieve();

            watch.Start();
            while (duration)
            {
                if (watch.ElapsedMilliseconds > sensor.GenInterValue)
                {
                    await Task.Factory.StartNew(() => fire.UpdateValue(sensor.id,which,
                        GetRandomDoubleNumber(sensor.MinMax[which][0], sensor.MinMax[which][1])));
                    watch.Reset();
                    watch.Start();

                }
                await Task.Delay(sensor.GenInterValue);
            }
        }
        private double GetRandomDoubleNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return Math.Truncate((random.NextDouble() * (maximum - minimum) + minimum) * 1000)/1000;
        }
    }
}
