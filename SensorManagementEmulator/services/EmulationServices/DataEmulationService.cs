using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorManagementEmulator;
using SensorManagementEmulator.Constants;
using SensorManagementEmulator.Firebase;
using SensorManagementEmulator.Models;

namespace SensorManagementEmulatorDataEmulation
{
    public class DataEmulationService
    {
        public Action<bool> StopEmulation;
        public Action<bool> EmulateFailure;

        public async Task EmulateDouble(Sensor<double> sensor, string database, string table)
        {
            bool duration = true;

            StopEmulation += b => { duration = false; };

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();
            Random randomDouble = new Random();
            DBInsertionService insertData = new DBInsertionService();
            while (duration)
            {
                insertData.InsertSensorData(database, table, randomDouble.NextDouble(),
                    DateTimeOffset.Now.ToUnixTimeMilliseconds(), false, false, (int) sensor.Id, dBconnection);
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
            bool failure = false;

            DBconnectionService dBconnection = new DBconnectionService();
            dBconnection.Connect(DBconnection.Username, DBconnection.Password, DBconnection.HostName);
            dBconnection.DataBaseConnection.Open();
            Random randomDouble = new Random();
            DBInsertionService insertData = new DBInsertionService();
            int i = 0;
            if (waitTime < sensor.GenInterValue - 10)
            {
                waitTime = sensor.GenInterValue + 100;
            }

            watch.Start();
            while (duration)
            {
                data.Add(new SensorValueData
                {
                    Data = GetRandomDoubleNumber(sensor.MinValue, sensor.MaxValue),
                    Time = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                });
                if (watch.ElapsedMilliseconds > waitTime)
                {
                    
                    await Task.Factory.StartNew(() =>
                        insertData.InsertSensorListData(database, table, data, false, false, (int) sensor.Id,
                            dBconnection));
                    data.Clear();
                    watch.Reset();
                    watch.Start();

                }

                await Task.Delay(sensor.GenInterValue);
            }

            dBconnection.DataBaseConnection.Close();
        }

        public async Task EmulateDoubleTemp(Sensor<double> sensor, string which)
        {
            string key = which + FBConst.Seperator + FBConst.TimeInterval + FBConst.Seperator +
                         FBConst.IntervalTimeUnit;
            bool duration = true;
            bool failure = false;
            double proc=0.03;
            Stopwatch watch = new Stopwatch();
            EmulateFailure += b =>
            {
                failure = b;
                proc = 0.20;
            };
            StopEmulation += b => { duration = false; };
            var fire = new FireBaseDataRetrieve();
            int EmulationCount = 0;

            watch.Start();
            try
            {
                while (duration)
                {
                    if (watch.ElapsedMilliseconds > sensor.GenerIntervals[key])
                    {
                        
                        await Task.Factory.StartNew(() => fire.UpdateValue(sensor.id, which,
                            //GetRandomDoubleNumber(sensor.MinMax[which][0], sensor.MinMax[which][1])
                            GeneratedValue(sensor.MinMax[which][0], sensor.MinMax[which][1], sensor.values[which],
                                failure,EmulationCount,(sensor.MinMax[which][0]+ sensor.MinMax[which][1])/2,proc)
                            ));

                        watch.Reset();
                        watch.Start();

                    }

                    await Task.Delay(sensor.GenerIntervals[key]);
                    if (sensor.GenerIntervals[key] == 0)
                        duration = false;

                }
            }
            catch (Exception e)
            {
                duration = false;
            }
        }

        private double NormalValue(double min, double max)
        {
            return (min + max) / 2;
        }
        private double GetRandomDoubleNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return Math.Truncate((random.NextDouble() * (maximum - minimum) + minimum) * 1000) / 1000;
        }

        private double GeneratedValue(double min, double max, double currentValue, bool k, int ecount, double enomValue, double proc)
        {
            //klaida += b => { error = true; };
            double curValue = currentValue;
            Random random = new Random();
            if (k == false)
            {
                double nomValue = (max + min) / 2;
                //pridedama arba atimama reiksme
                double modValue = nomValue * random.NextDouble() * proc;
                double maxValue = nomValue + nomValue * proc;
                double minValue = nomValue - nomValue * proc;
                if (curValue < minValue || curValue > maxValue)
                {
                    curValue = nomValue;
                }
                if (curValue == nomValue)
                {
                    int chance = random.Next(0, 3);
                    //Sugeneruojamas skaicius nuo 0 iki 2. Jei 2 pridedame, jei 0 atimame. Dar tikriname kad verte nekerta min arba maks reiksmiu.
                    if (chance == 2 && curValue + modValue < maxValue)
                    {
                        curValue = curValue + modValue;
                    }
                    if (chance == 1 && curValue - modValue > minValue)
                    {
                        curValue = curValue - modValue;
                    }
                }
                else if (curValue < nomValue)
                {
                    int chance = random.Next(0, 5);
                    //Sugeneruojamas skaicius nuo 1 iki 4. Jei 1 atimame.
                    if (chance == 1 && curValue - modValue > minValue)
                    {
                        curValue = curValue - modValue;
                    }
                    else
                        curValue = curValue + modValue;
                }
                else if (curValue > nomValue)
                {
                    int chance = random.Next(0, 5);
                    //Sugeneruojamas skaicius nuo 0 iki 5. Jei 2 pridedame
                    if (chance == 2 && curValue + modValue < maxValue)
                    {
                        curValue = curValue + modValue;
                    }
                    else
                        curValue = curValue - modValue;
                }
            }
            else
            {
                //Vidutine reiksme
                if (ecount == 0)
                {
                    enomValue = curValue;
                }
                double nomValue = enomValue;
                
                //pridedama arba atimama reiksme
                double modValue = nomValue * random.NextDouble() * proc;
                double maxValue = nomValue + nomValue * proc;
                double minValue = nomValue - nomValue * proc;

                if (curValue == nomValue)
                {
                    int chance = random.Next(0, 3);
                    //Sugeneruojamas skaicius nuo 0 iki 2. Jei 2 pridedame, jei 0 atimame. Dar tikriname kad verte nekerta min arba maks reiksmiu.
                    if (chance == 2 && curValue + modValue < maxValue)
                    {
                        curValue = curValue + modValue;
                    }
                    if (chance == 1 && curValue - modValue > minValue)
                    {
                        curValue = curValue - modValue;
                    }
                }
                else if (curValue < nomValue)
                {
                    int chance = random.Next(0, 5);
                    //Sugeneruojamas skaicius nuo 1 iki 4. Jei 1 atimame.
                    if (chance == 1 && curValue - modValue > minValue)
                    {
                        curValue = curValue - modValue;
                    }
                    else
                        curValue = curValue + modValue;
                }
                else if (curValue > nomValue)
                {
                    int chance = random.Next(0, 5);
                    //Sugeneruojamas skaicius nuo 0 iki 5. Jei 2 pridedame
                    if (chance == 2 && curValue + modValue < maxValue)
                    {
                        curValue = curValue + modValue;
                    }
                    else
                        curValue = curValue - modValue;
                }
            }
            return double.Parse(curValue.ToString("#.000"));
        }
    }
}
