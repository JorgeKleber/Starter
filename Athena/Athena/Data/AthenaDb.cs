using Athena.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Data
{
	public class AthenaDb
	{
		static SQLiteAsyncConnection Database;

		public static readonly AsyncLazy<AthenaDb> Instance = new AsyncLazy<AthenaDb>(async () =>
		{
			var instance = new AthenaDb();
			CreateTableResult result = await Database.CreateTableAsync<User>();
			return instance;
		});

		public AthenaDb()
		{
			Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
		}

		public Task<List<User>> GetItemsAsync()
		{
			return Database.Table<User>().ToListAsync();
		}

		public Task<List<User>> GetItemsNotDoneAsync()
		{
			// SQL queries are also possible
			return Database.QueryAsync<User>("SELECT * FROM [User] WHERE [Done] = 0");
		}

		public Task<User> GetItemAsync(int id)
		{
			return Database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
		}

		public Task<User> AuthUser(string userName, string password)
		{
			return Database.Table<User>().Where(i => i.Name == userName && i.Password == password).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(User item)
		{
			if (item.Id != 0)
			{
				return Database.UpdateAsync(item);
			}
			else
			{
				return Database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(User item)
		{
			return Database.DeleteAsync(item);
		}
	}
}
