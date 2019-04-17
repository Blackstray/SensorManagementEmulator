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
        private string ConnectionString;
        public MySqlConnection DataBaseConnection;

        public void Connect(string username, string password, string serverHost)
        {
            ConnectionString =
            "Server=" + serverHost + ";" +
                "Port=3306;" +
                "Database=Emulator;" +
                "Uid="+username+";" +
                "password=" + password + ";";
            DataBaseConnection = new MySqlConnection(ConnectionString);
            DataBaseConnection.ConnectionString = ConnectionString;
        }
    }
}
