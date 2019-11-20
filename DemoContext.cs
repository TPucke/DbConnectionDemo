using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace DbConnectionDemo
{
    public class EntityOne
    {
        public Guid Id { get; set; }

        public string FieldOne { get; set; }
    }

    public class DemoContext : DbContext
    {
        public static string _connectionString { get; set; } = "Server=localhost;Port=5433;Database=connectiondemo;User Id=postgres;Password=postgres;";
        public static ILoggerFactory _loggerFactory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseNpgsql(_connectionString);
            contextOptionsBuilder.EnableDetailedErrors();
            if (_loggerFactory != default)
            {
                contextOptionsBuilder.UseLoggerFactory(_loggerFactory);
            }
        }

        public DbSet<EntityOne> EntityOne { get; set; }
    }
}
