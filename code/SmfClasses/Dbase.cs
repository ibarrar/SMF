using System;
using System.Data.OleDb;
using System.Data;

namespace SmfRewriteProject
{
	public class Dbase
	{
		public Dbase()
		{
			//connectionString = System.Configuration.ConfigurationSettings.AppSettings["CnStr"];
			connectionString = System.Configuration.ConfigurationSettings.AppSettings["SQLConnection"];
		}

		public DataRowCollection action(string query)
		{
			//query = "select * from T_SKILLS_EMPINFO where blah blah";
			OleDbConnection myConnection = new OleDbConnection( connectionString );
			//query = query.ToUpper();
			
			if (("INSERT".IndexOf(query) == -1) && ("DELETE".IndexOf(query) == -1) && ("UPDATE".IndexOf(query) == -1))
			{
				OleDbDataAdapter myAdapter = new OleDbDataAdapter( query, myConnection );
				DataTable tblData = new DataTable();
				myAdapter.Fill( tblData );
				rows = tblData.Rows;
			}
			else
			{
				myConnection.Open();
				OleDbCommand myCommand = new OleDbCommand();
				myCommand.CommandText = query;
				myCommand.Connection = myConnection;
				myCommand.ExecuteNonQuery();
				myConnection.Close();
			}

			return rows;
		}
		string connectionString;
		DataRowCollection rows;
	}
}
