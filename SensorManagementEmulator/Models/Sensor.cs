using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace SensorManagementEmulator.Models
{
    public class Sensor<T>
    {
        public long Id;
        public T CurrentValue;
        public T MinValue;
        public T MaxValue;
        public string Name;
        public string Type;
        public int GenInterValue;
        public bool CompareTo(Sensor<T> sensor)
        {
            if (sensor is null)
                return false;
            return Id == sensor.Id
                   && Comparer<T>.Default.Compare(MinValue, sensor.MinValue) == 0
                   && Comparer<T>.Default.Compare(MaxValue, sensor.MaxValue) == 0
                   && Name.CompareTo(sensor.Name) == 0
                   && Type.CompareTo(sensor.Type) == 0
                   && GenInterValue == sensor.GenInterValue;
        }
    }

}
