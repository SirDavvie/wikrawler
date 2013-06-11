using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using WiktionaryCrawler.Models;

namespace WiktionaryCrawler.Serializers
{
	/// <summary>
	/// Saves and retrieves a wiktionary to a Sql Server.
	/// </summary>
	public class SqlManager : IWiktionarySerializer
	{
		public string ServerConnectionString { get; set; }
		public string TableName { get; set; }
		
		/// <summary>
		/// Constructs a new SqlManager
		/// </summary>
		/// <param name="tableName">The table that will/does contain the wiktionary.</param>
		/// <param name="sqlServerConnectionString">The connection to the Sql server that will/does contain the wiktionary.</param>
		public SqlManager(string tableName, string sqlServerConnectionString)
		{
			ServerConnectionString = sqlServerConnectionString;
			TableName = tableName;
		}
		
		/// <summary>
		/// Checks to see if the table currently exists.
		/// </summary>
		/// <returns>True if the table exists, false otherwise.</returns>
		public Boolean CheckExistence()
		{
			string checkTableExistenceQueryString = "if object_id('" + TableName + "') is null "
				+ "begin select 0 end "
				+ "else "
				+ "begin select 1 end ";
			return ExecuteSqlQueryWithSuccess(checkTableExistenceQueryString);
		}
		
		/// <summary>
		/// Deletes the table.
		/// </summary>
		public void DeleteExisting()
		{
			string dropTableQueryString = "if object_id('" + TableName + "') is not null " + 
				"begin drop table " + TableName + " end ";
			ExecuteSqlQuery(dropTableQueryString);
			return;
		}
		
		/// <summary>
		/// Creates the table anew.
		/// </summary>
		public void CreateNew()
		{
			string createTableQueryString = "if object_id('" + TableName + "') is null " +
				"begin " + 
				"	create table " + TableName + " (" +
				"	word_key int identity " +
				"	,word varchar(200) " +
				"	,part_of_speech varchar(100) " +
				"   ,definitions varchar(8000) " +
				"   ,word_Url varchar(500) " +
				"	) end ";
			ExecuteSqlQuery(createTableQueryString);
			return;
		}
		
		/// <summary>
		/// Saves a list of dictionary entries to the Sql Server.
		/// </summary>
		/// <param name="wiktionary">The list of Dictionary Entries to be saved to the database.</param>
		public void SerializeWiktionary(List<DictionaryEntry> wiktionary)
		{
			int counter = 0;
			string query = " insert into " + TableName + " (word, part_of_speech, definitions, word_Url) values ";
			
			StringBuilder queryBuilder = new StringBuilder();
			foreach (DictionaryEntry de in wiktionary)
			{
				if (++counter % 100 == 0)
				{
					queryBuilder.Append("('" 
					                    + de.Word.Replace("'", "''") 
					                    + "', '" 
					                    + de.WordPartOfSpeech.PosName.Replace("'", "''") 
					                    + "', '"
					                    + de.Definitions.Replace("'", "''")
					                    + "', '" 
					                    + de.WordUrl.Replace("'", "''")
					                    + "')");
                    ExecuteSqlQuery(query + queryBuilder.ToString());
                    queryBuilder.Clear();
				}
				queryBuilder.Append("('" 
				                    + de.Word.Replace("'", "''") 
				                    + "', '" 
				                    + de.WordPartOfSpeech.PosName.Replace("'", "''")
				                    + "', '"
				                    + de.Definitions.Replace("'", "''")
				                    + "', '" 
				                    + de.WordUrl.Replace("'", "''")
				                    + "'),");
			}
		}
		
		/// <summary>
		/// A helper method that executes a sql query that returns a bit that indicates success.
		/// </summary>
		/// <param name="queryString">A string containing the sql query to be executed.</param>
		/// <returns>True if successful, false otherwise 
		/// (it is possible to hijack the bit to mean something else in the Sql query.</returns>
		protected Boolean ExecuteSqlQueryWithSuccess(string queryString)
		{
			using (SqlConnection sqlconn = new SqlConnection(ServerConnectionString))
			{
				SqlCommand query = new SqlCommand(queryString, sqlconn);
				SqlDataAdapter returnBool = new SqlDataAdapter(query);
				DataTable dt = new DataTable();
				returnBool.Fill(dt);
				return dt.Rows[0][0].ToString() == "1";
			}
		}
		
		/// <summary>
		/// A helper metheod that executes a Sql query.
		/// </summary>
		/// <param name="queryString">A string containing the Sql query to be executed.</param>
		protected void ExecuteSqlQuery(string queryString)
		{
			using (StreamWriter sw = new StreamWriter("errorlog.txt", true))
			{
				sw.WriteLine(queryString);
			}
			using (SqlConnection sqlconn = new SqlConnection(ServerConnectionString))
			{
				sqlconn.Open();
				SqlCommand query = new SqlCommand(queryString, sqlconn);
				query.ExecuteNonQuery();
				sqlconn.Close();
			}
			return;
		}
	}
}
