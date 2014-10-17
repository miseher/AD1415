using System;
using MySql.Data.MySqlClient;
namespace PHolaMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{


			MySqlConnection mySqlConnection = new MySqlConnection (
				"Server=localhost;Database=dbprueba;User ID=root;Password=sistemas");

			mySqlConnection.Open ();

			Console.WriteLine ("Hola MySql");

			/*MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText =string.Format("insert into categoria (nombre) values ('{0}')",
			                                        DateTime.Now);

			mySqlCommand.BeginExecuteNonQuery ();*/


			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();

			mySqlCommand.CommandText = "select * from categoria";

			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

			Console.WriteLine ("FieldCount={0}", mySqlDataReader.FieldCount);

			for (int i=0; i<mySqlDataReader.FieldCount; i++) {
				Console.WriteLine ("Column index={0}={1}", i, mySqlDataReader.GetName(i));
			}

			mySqlConnection.Close ();
		}
	}
}
