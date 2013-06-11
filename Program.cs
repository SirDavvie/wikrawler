using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WiktionaryCrawler.Data;
using WiktionaryCrawler.Models;
using WiktionaryCrawler.Serializers;

namespace WiktionaryCrawler
{
	/// <summary>
	/// The console app to create and retrieve a copy of the wiktionary.
	/// </summary>
	class Program
	{
		/// <summary>
		/// The entry point of the application.
		/// </summary>
		public static void Main()
		{
			Console.WriteLine("Please wait; initializing...");
			IWiktionarySerializer iws;
			string userInput;
			int menuOption;
			
			if(ChooseMenuOption(out menuOption) || menuOption == 3)
			{
				return;
			}
			if(GetIWS(menuOption, out iws))
			{
				return;
			}
			
			if (iws.CheckExistence())
			{
				Console.WriteLine("The file or table already exists.  Delete it?");
				if (GetUserInput(out userInput))
				{
					return;
				}
				if (userInput.ToUpper()[0] == 'N')
				{
					return;
				}
				iws.DeleteExisting();
			}
			iws.CreateNew();
			Console.WriteLine("Creating and serializing dictionary...");
			WiktionaryParser wc = new WiktionaryParser();
			if (wc.GetDictionary())
			{
				Console.WriteLine("Creation and serialization complete. Press any key to exit.");				
			}
			else
			{
				Console.WriteLine("Creation and serialization failed. Try again?");
				string tryAgainUI;
				if (GetUserInput(out tryAgainUI))
				{
					return;
				}
				if (tryAgainUI.ToUpper()[0] == 'Y')
				{
					Main();
				}
			}

			Console.WriteLine("Press any key to exit.");	
			Console.ReadKey();
		}
		
		/// <summary>
		/// A Ui method to show the main menu.
		/// </summary>
		/// <param name="menuChoice">An out parameter that indicates what menu option was chosen.</param>
		/// <returns>True if the user chose to quit, false otherwise.</returns>
		public static bool ChooseMenuOption(out int menuChoice)
		{
			string userInput;
			menuChoice = 0;
			
			Console.WriteLine("Welcome to Doug's Wikitionary scraper!");
			Console.WriteLine("Q Quits at any time.");
			Console.WriteLine("1.) Create the wiktionary and write it to file.");
			Console.WriteLine("2.) Create the wiktionary and write it to a SqlServer instance.");
			Console.WriteLine("3.) Quit.");
			if(GetUserInput(out userInput) || userInput == "3")
			{
				return true;
			}
			if (!int.TryParse(userInput, out menuChoice) || menuChoice < 0 || menuChoice > 4)
			{
				Console.WriteLine("Please enter a valid int between 1 and 3.");
				return ChooseMenuOption(out menuChoice);
			}
			return false;
		}
		
		/// <summary>
		/// A Ui method that aids creation of the wikitionary serializer the user chose.
		/// </summary>
		/// <param name="option">The menu option for the wiktionary serializer chosen.</param>
		/// <param name="iws">An out parameter that returns the user-chosen class that implements IWiktionarySerializer.</param>
		/// <returns>True if the user chose to quit, false otherwise.</returns>
		public static bool GetIWS(int option, out IWiktionarySerializer iws)
		{
			string name;
			string path;
			iws = null;
			bool isSqlServer = option == 2;
			
			if (isSqlServer)
			{
				Console.WriteLine("What table would you like to use? ");
				if (GetUserInput(out name) || GetSqlConnectionString(out path))
				{
					return true;
				}
				iws = new SqlManager(name, path);
				return false;
			}
			else
			{
				Console.WriteLine("Please enter a file name: ");
				if (GetUserInput(out name))
				{
					return true;
				}
				iws = string.IsNullOrWhiteSpace(name) ? new FileManager() : new FileManager(name);
				return false;
			}
		}
		
		/// <summary>
		/// A Ui method that aids creation of the Sql connection string for a SqlManager.
		/// </summary>
		/// <param name="sqlConnectionString">An out string of the final Sql connection.</param>
		/// <returns>True if the user chose to quit, false otherwise.</returns>
		public static bool GetSqlConnectionString(out string sqlConnectionString)
		{
			Boolean connectionMade = false;
			sqlConnectionString = null;
			string userInput;
			
			while(!connectionMade)
			{
				Console.WriteLine("Enter a Sql connection string directly? ");
				if (Console.ReadLine().ToUpper()[0] == 'Y')
				{
					Console.WriteLine("Enter: ");
					if (GetUserInput(out sqlConnectionString))
					{
						return true;
					}
				}
				else
				{
					if(BuildSqlConnectionString(out sqlConnectionString))
					{
						return true;
					}
				}
				SqlConnection sqlconn = new SqlConnection(sqlConnectionString);
				try 
				{
					sqlconn.Open();
					Console.WriteLine("Testing Connection...");
					Console.WriteLine(sqlconn.ServerVersion);
					Console.WriteLine("Success!");
					connectionMade = true;
				}
				catch
				{
					Console.WriteLine("Connection failed...");
					connectionMade = false;
				}
				finally
				{
					sqlconn.Close();
				}
				if (connectionMade)
				{
					return false;
				}
				Console.WriteLine("Try Again?");
				if (GetUserInput(out userInput))
				{
					return true;
				}
				if (userInput.ToUpper()[0] == 'N')
				{
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// A helper Ui method that gets string input from the user.
		/// </summary>
		/// <param name="userInput">An out string that contains the string the user input.</param>
		/// <returns>True if the user chose to quit, false otherwise.</returns>
		public static bool GetUserInput(out string userInput)
		{
			userInput = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(userInput))
			{
				Console.WriteLine("Please try again.");
				GetUserInput(out userInput);
			}
			else if (userInput.ToUpper()[0] == 'Q')
			{
				return true;
			} 
			return false;
		}
		
		/// <summary>
		/// A helper Ui method that helps a user build their own Sql connection string.
		/// </summary>
		/// <param name="sqlConnStr">An out string that contains the final Sql connection.</param>
		/// <returns>True if the user chose to quit, false otherwise.</returns>
		public static bool BuildSqlConnectionString(out string sqlConnStr)
		{
			string userInput = "";
			sqlConnStr = "";
			SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
			Console.WriteLine("Server name: ");
			if (GetUserInput(out userInput))
			{
				return true;
			}
			sb.DataSource = userInput;
			Console.WriteLine("Database: ");
			if (GetUserInput(out userInput))
			{
				return true;
			}
			sb.InitialCatalog = userInput;
			Console.WriteLine("Use Windows integrated security?");
			if (GetUserInput(out userInput))
			{
				return true;
			}
			if (userInput.ToUpper()[0] == 'Y')
			{
				sb.IntegratedSecurity = true;
				sqlConnStr = sb.ToString();
				return false;
			}
			Console.WriteLine("User name: ");
			if (GetUserInput(out userInput))
			{
				return true;
			}
			sb.UserID = userInput;
			Console.WriteLine("Password: ");
			if (GetUserInput(out userInput))
			{
				return true;
			}
			sb.Password = userInput;
			sqlConnStr = sb.ConnectionString;
			return false;
		}
	}
}