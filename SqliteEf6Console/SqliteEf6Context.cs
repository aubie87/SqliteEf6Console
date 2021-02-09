using SQLite.CodeFirst;
using SqliteEf6Console.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteEf6Console
{
    public class SQLiteConfiguration : DbConfiguration
    {
        public SQLiteConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }

    [DbConfigurationType(typeof(SQLiteConfiguration))]
    public class SqliteEf6Context : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var model = modelBuilder.Build(Database.Connection);
            //ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            //string sql = sqlGenerator.Generate(model.StoreModel);
            //Debug.WriteLine("OnModelCreating: " + sql);

            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SqliteEf6Context>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            //var model = modelBuilder.Build(Database.Connection);
            //IDatabaseCreator sqliteDatabaseCreator = new SqliteDatabaseCreator();
            //sqliteDatabaseCreator.Create(Database, model);
        }

    }
}
