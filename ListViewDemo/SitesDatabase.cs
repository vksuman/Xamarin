using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace ListViewDemo
{
	public class SitesDatabase
	{
		readonly SQLiteAsyncConnection database;

		public SitesDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
		}

		public Task<List<Instruments>> GetInstrumentsAsync()
		{
			return database.Table<Instruments>().ToListAsync();
		}
	}
}
