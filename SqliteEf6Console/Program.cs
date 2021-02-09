using SqliteEf6Console.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteEf6Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Error loading Sqlite.Interop.dll?
            // PM> Update-Package -reinstall System.Data.SQLite.Core
            using (SqliteEf6Context context = new SqliteEf6Context())
            {
                context.People.Add(new Person { Name = Guid.NewGuid().ToString(), Birthday = DateTime.Now.AddYears(-20) });
                context.SaveChanges();
            }
        }
    }
}
