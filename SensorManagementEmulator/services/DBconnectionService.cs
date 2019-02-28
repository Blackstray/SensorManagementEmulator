using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorManagementEmulator.Models;
using MySql.Data.MySqlClient;

namespace SensorManagementEmulator
{

    public class DBconnectionService
    {
        private static string ConnectionString =
                                                 "Server=91.211.246.37;" +
                                                 "Port=3306;" +
                                                 "Database=Emulator;" +
                                                 "Uid=user1;" +
                                                 "password=123456798;";
        public static MySqlConnection DataBaseConnection;

        public static void Connect()
        {
            DataBaseConnection = new MySqlConnection(ConnectionString);
            DataBaseConnection.ConnectionString = ConnectionString;
        }
    }
}
