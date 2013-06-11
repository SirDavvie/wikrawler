using System;
using System.Reflection;
using System.Data.SqlClient;
using NUnit.Framework;
using WiktionaryCrawler.Serializers;

namespace WiktionaryCrawler.UnitTests
{
	[TestFixture]
	public class TableCreatorUnitTests
	{
		public string SqlConnString = "Data Source=.\\sqlexpress;Initial Catalog=sqlexpress;Integrated Security=True;MultipleActiveResultSets=True";
		
		[Test]
		public void DBConnectionTest()
		{
			bool connectionMade = false;
			try
			{
				using (SqlConnection sqlconn = new SqlConnection(SqlConnString))
				{
					sqlconn.Open();
					if (!string.IsNullOrWhiteSpace(sqlconn.ServerVersion))
					{
						connectionMade = true;
					}
				}
			}
			catch
			{
				Assert.Fail("Table Creator Unit Tests cannot connect to your database.  Check the connection string.");
			}
			Assert.IsTrue(connectionMade, "Table Creator Unit Tests cannot connect to your database.  Check the connection string.");
		}
			
		[Test]
		public void CreateTableTest()
		{
			string testTableName = MethodBase.GetCurrentMethod().Name + "Table";
			SqlManager testTC = new SqlManager(testTableName, SqlConnString);
			bool wasSuccessful = false;
			try
			{
				if (testTC.CheckExistence())
				{
					testTC.DeleteExisting();
				}
				testTC.CreateNew();
				wasSuccessful = testTC.CheckExistence();
			}
			catch
			{
				Assert.Fail("CreateTableTest() threw an exception.");
			}
			Assert.IsTrue(wasSuccessful, "CreateTableTest() did not successfully create the table.");
		}
		
		[Test]
		public void DeleteTableTest()
		{
			string testTableName = MethodBase.GetCurrentMethod().Name + "Table";
			SqlManager testTC = new SqlManager(testTableName, SqlConnString);
			bool wasSuccessful = false;
			try
			{
				if (testTC.CheckExistence())
				{
					testTC.CreateNew();
				}
			}
			catch
			{
				Assert.Fail("DeleteTableTest() failed during setup.");
			}
			
			try
			{
				testTC.DeleteExisting();
				wasSuccessful = true;
			}
			catch
			{
				wasSuccessful = false;
			}
			
			Assert.IsTrue(wasSuccessful, "DeleteTableTest() failed.");
		}
	
		[Test]
		public void CheckExistenceReturnsTrueTest()
		{
			string testTableName = MethodBase.GetCurrentMethod().Name + "Table";
			SqlManager testTC = new SqlManager(testTableName, SqlConnString);
			bool wasSuccessful = false;
			try
			{
				if (!testTC.CheckExistence())
				{
					testTC.CreateNew();
				}
				wasSuccessful = testTC.CheckExistence();
			}
			catch
			{
				Assert.Fail("CreateTableTest() threw an exception.");
			}
			Assert.IsTrue(wasSuccessful, "CheckExistenceReturnsTrueTest() did not detect an existing table.");			
		}
	
		[Test]
		public void CheckExistenceReturnsFalseTest()
		{
			string testTableName = MethodBase.GetCurrentMethod().Name + "Table";
			SqlManager testTC = new SqlManager(testTableName, SqlConnString);
			bool wasSuccessful = false;
			try
			{
				if (testTC.CheckExistence())
				{
					testTC.DeleteExisting();
				}
				wasSuccessful = !testTC.CheckExistence();
			}
			catch
			{
				Assert.Fail("CheckExistenceReturnsFalseTest() threw an exception.");
			}
			Assert.IsTrue(wasSuccessful, "CheckExistenceReturnsFalseTest() detected a Nonexistent table.");				
		}
	}
}
