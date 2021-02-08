# SqliteEf6Console
After scouring the Internet, this is the only working project running under VS2019, .NET Framework 4.72 and EntityFramework 6.4.4 that I could find/create. I was never able to get app.config to properly load the DLLs. I resorted to using `DbConfiguration` class and an attribute on the context to get Sqlite to properly load and migrate its database.

Minor build issue when moving the project into source control was to force reinstall `System.Data.SQLite.Core` to fix error loading `Sqlite.Interop.dll`.

`PM> Update-Package -reinstall System.Data.SQLite.Core`
