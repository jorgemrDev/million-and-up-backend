using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MilionAndUp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Api.PropertyImages.Context
{
    public class PropertyContext : DbContext
    {
        public PropertyContext(DbContextOptions<PropertyContext> options) : base(options)
        {

        }

        public DbSet<Owner> Owner { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyImage> PropertyImage { get; set; }
        public DbSet<PropertyTrace> PropertyTrace { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PropertyContext>
    {
        public PropertyContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MilionAndUp.Api.Property/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<PropertyContext>();
            var connectionString = configuration.GetConnectionString("MillionAndUpConnection");
            builder.UseSqlServer(connectionString);
            return new PropertyContext(builder.Options);
        }
    }
}