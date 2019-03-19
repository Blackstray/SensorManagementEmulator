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
        public static string Usage = @"Usage:
C:\> dotnet run command sensormanagementproject
Where command is one of
    initialize-project-id
    add-data-1
    add-data-2
    retrieve-all-documents
";
        public static void InitializeProjectId(string project)
        {
            // [START fs_initialize_project_id]
            FirestoreDb db = FirestoreDb.Create(project);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", project);
            // [END fs_initialize_project_id]
        }

        public async Task UpdateValue(string SensorId,string ValueName, object value)
        {
            FirestoreDb db = FirestoreDb.Create(FBConst.ProjectName);
            DocumentReference docRef = db.Collection("Sensors").Document(SensorId);
            await db.RunTransactionAsync(async transaction =>
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
                Dictionary<string, object> documentDictionary = sensors.ToDictionary();

                foreach (KeyValuePair<string, object> sensorField in documentDictionary)
                {

                    foreach (var d in FBConst.Metrics)
                    {
                        if (String.CompareOrdinal(sensorField.Key, d) == 0)
                        {
                            temp.id = sensors.Id;
                            temp.values.Add(sensorField.Key,double.Parse(sensorField.Value.ToString()));
                            double dmin = double.NaN;
                            double dmax = double.NaN;
                            
                            int found = 0;
                            foreach (KeyValuePair<string, object> sen in documentDictionary)
                            {
                                if (String.Compare(sen.Key, d + FBConst.Seperator + FBConst.Min, StringComparison.Ordinal) == 0)
                                {
                                    dmin = double.Parse(sen.Value.ToString());
                                    found++;
                                    if(found==2)
                                    break;
                                }
                                if (String.Compare(sen.Key, d + FBConst.Seperator + FBConst.Max, StringComparison.Ordinal) == 0)
                                {
                                    dmax = double.Parse(sen.Value.ToString());
                                    found++;
                                    if (found == 2)
                                        break;
                                }
                                if (String.Compare(sen.Key, d + FBConst.Seperator + FBConst.TimeInterval + FBConst.Seperator +
                                                            FBConst.IntervalTimeUnit, StringComparison.Ordinal) == 0)
                                {
                                    temp.GenInterValue = int.Parse(sen.Value.ToString());
                                }
                            }
                            temp.MinMax.Add(new KeyValuePair<string, double[]>(d, new [] { dmin, dmax }));
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
