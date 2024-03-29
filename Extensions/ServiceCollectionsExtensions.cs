﻿using Npgsql;
using static ApiTask.Data.TaskContext;

namespace ApiTask.Extensions
{
    public static class ServiceCollectionsExtensions
    {

        //This is the extension of the service collections

        //Adding the method AddPersistence to configure our Connection String
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddScoped<GetConnection>(sp => async () =>
            {
                var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();
                return connection;
            });
            return builder;
        }
    }
}
