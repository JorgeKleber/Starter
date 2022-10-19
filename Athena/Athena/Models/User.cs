using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Athena.Models
{
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public byte[] ProfileImage { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public double Income { get; set; }//renda mensal

		//user this tutorial for save the image in sqlite.
		//https://stackoverflow.com/questions/57192117/how-to-save-an-image-in-sqlite-in-xamarin-forms
	}
}
