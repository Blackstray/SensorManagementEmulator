using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorManagementEmulator.Firebase
{
    class FBConst
    {
        public static readonly string Name = "name";
        public static readonly string Status = "status";
        public static readonly string StatusA = "Active";
        public static readonly string StatusD = "Disabled";
        public static readonly string Type = "type";
        public static readonly string Min = "min";
        public static readonly string Max = "max";
        public static readonly string Seperator = "_";
        public static readonly string Unit = "u";
        public static readonly string ProjectName = "sensormanagementproject";
        public static readonly string TimeInterval = "interval";
        public static readonly string IntervalTimeUnit = "ms";

        public static readonly IList<String> Metrics = new ReadOnlyCollection<string>
        (new List<String>
        {"amperage","power","voltage","temperature"
        });



        //public readonly string Max = "Max";
    }

}

