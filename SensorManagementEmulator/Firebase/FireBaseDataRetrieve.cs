using Google.Cloud.Firestore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using SensorManagementEmulator.Firebase;
using SensorManagementEmulator.Models;
using SensorManagementEmulator.UserControls;

namespace SensorManagementEmulator
{
    public class FireBaseDataRetrieve
    {

        public async Task UpdateValue(string SensorId, string ValueName, object value)
        {
            FirestoreDb Db = FirestoreDb.Create(FBConst.ProjectName);
            DocumentReference docRef = Db.Collection("Sensors").Document(SensorId);
            await Db.RunTransactionAsync(async transaction =>
            {
                DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(docRef);
                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { ValueName, value}
                };
                transaction.Update(docRef, updates);
            });
        }

        public async Task<IList<Sensor<double>>> RetrieveAllDocuments(string project)
        {
            var Sensors = new List<Sensor<double>>();
            FirestoreDb db = FirestoreDb.Create(project);
            CollectionReference usersRef = db.Collection("Sensors");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();

            foreach (DocumentSnapshot sensors in snapshot.Documents)
            {
                Sensor<double> temp = new Sensor<double>();
                temp.MinMax = new ConcurrentDictionary<string, double[]>();
                temp.values = new ConcurrentDictionary<string, double>();
                temp.GenerIntervals = new Dictionary<string, int>();
                Dictionary<string, object> documentDictionary = sensors.ToDictionary();

                foreach (KeyValuePair<string, object> sensorField in documentDictionary)
                {
                    if (String.Compare(sensorField.Key, FBConst.Type, StringComparison.Ordinal) == 0)
                        temp.Type = (string)sensorField.Value;

                    foreach (var d in FBConst.Metrics)
                    {
                        if (String.CompareOrdinal(sensorField.Key, d) == 0)
                        {
                            temp.id = sensors.Id;
                            temp.values.Add(sensorField.Key, double.Parse(sensorField.Value.ToString()));
                            double dmin = double.NaN;
                            double dmax = double.NaN;

                            int found = 0;
                            foreach (KeyValuePair<string, object> sen in documentDictionary)
                            {
                                if (String.Compare(sen.Key, d + FBConst.Seperator + FBConst.Min, StringComparison.Ordinal) == 0)
                                {
                                    dmin = double.Parse(sen.Value.ToString());
                                    found++;


                                }
                                if (String.Compare(sen.Key, d + FBConst.Seperator + FBConst.Max, StringComparison.Ordinal) == 0)
                                {
                                    dmax = double.Parse(sen.Value.ToString());
                                    found++;


                                }
                                if (String.Compare(sen.Key, d + FBConst.Seperator + FBConst.TimeInterval + FBConst.Seperator +
                                                            FBConst.IntervalTimeUnit, StringComparison.Ordinal) == 0)
                                {
                                    temp.GenerIntervals.Add(sen.Key, int.Parse(sen.Value.ToString()));
                                }

                            }
                            temp.MinMax.Add(new KeyValuePair<string, double[]>(d, new[] { dmin, dmax }));
                            temp.Name = sensors.GetValue<string>(FBConst.Name);
                        }
                    }


                }
                Sensors.Add(temp);
            }

            return Sensors;
        }

    }
}
