﻿using Npgsql;

namespace Terra.Utils
{
    public class DbConnector
    {
        private readonly string _connectionString = "Host=localhost;Username=postgres;Password=alexis27;Database=doamais";
        public DbConnector()
        {
        }

        public NpgsqlDataSource GetDataSource()
        {
            return NpgsqlDataSource.Create(_connectionString);
        }
    }
}
