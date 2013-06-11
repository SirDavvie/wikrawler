using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using WiktionaryCrawler.Models;

namespace WiktionaryCrawler.Serializers
{
	/// <summary>
	/// Creates and retrieves a dictionary from file.
	/// </summary>
	public class FileManager : IWiktionarySerializer
	{
		public string FilePath { get; set; }
		
		/// <summary>
		/// Construct a new file manager.
		/// </summary>
		/// <param name="filePath">The path of the file to be created/retrieved from.</param>
		public FileManager(string filePath = "wiktionary.txt")
		{
			FilePath = filePath;
		}
		
		/// <summary>
		/// Checks if the file already exists.
		/// </summary>
		/// <returns>True if the file exists, false otherwise.</returns>
		public Boolean CheckExistence()
		{
			return File.Exists(FilePath);
		}
		
		/// <summary>
		/// Deletes the file.
		/// </summary>
		public void DeleteExisting()
		{
			File.Delete(FilePath);
			return;
		}
		
		/// <summary>
		/// Creates a new file.
		/// </summary>
		public void CreateNew()
		{
			FileStream fs = File.Create(FilePath);
			using (StreamWriter sw = new StreamWriter(fs))
			{
				sw.WriteLine("Wiktionary retrieved on: " + DateTime.Now + "; columns: Word|Part Of Speech|Definitions|Word Url");
			}
			fs.Close();
			fs.Dispose();
		}
		
		/// <summary>
		/// Saves a wiktionary, or some part thereof, to file.  Appends to the end of the existing file.
		/// </summary>
		/// <param name="wiktionary">The list of DictionaryEntries to be saved.</param>
		public void SerializeWiktionary(List<DictionaryEntry> wiktionary)
		{
			bool isDone = false;
			while (!isDone)
			{
				try
				{
					using (StreamWriter sw = new StreamWriter(FilePath, true))
					{
						foreach (DictionaryEntry de in wiktionary)
						{
							sw.WriteLine(de.Word + "|" + de.WordPartOfSpeech.PosName + "|" + de.Definitions + "|" + de.WordUrl);
						}
					}
					isDone = true;					
				}
				catch (IOException e)
				{
					Thread.Sleep(10000);
				}
			}
		}
	
		/// <summary>
		/// Retrieves a wiktionary from file.
		/// </summary>
		/// <returns>The list of DictionaryEntries stored in the file.</returns>
		public List<DictionaryEntry> DeserializeWiktionary()
		{
			List<DictionaryEntry> wiktionary = new List<DictionaryEntry>();
			int lineNumber = 0;
			string currentLine;
			using (StreamReader sr = new StreamReader(FilePath))
			{
				while (sr.Peek() >= 0)
				{
					currentLine = sr.ReadLine();
					lineNumber++;
					if (lineNumber > 1 && !string.IsNullOrWhiteSpace(currentLine))
					{
						wiktionary.Add(GetDictionaryEntryFromString(currentLine));
					}
				}
			}
			return wiktionary;
		}
		
		/// <summary>
		/// A helper method that parses a single line of the file into a DictionaryEntry.
		/// </summary>
		/// <param name="dictionaryEntryString">The string from the file.</param>
		/// <returns>The DictionaryEntry that was saved in the string.</returns>
		internal DictionaryEntry GetDictionaryEntryFromString(string dictionaryEntryString)
		{
			DictionaryEntry de = new DictionaryEntry();
			int counter = 0;
			string deDefs = null;
			string deWord = null;
			string dePos = null;
			string deUrl = null;
			
			foreach (string s in dictionaryEntryString.Split('|'))
			{
				switch (counter)
				{
					case 0:
						deWord = s;
						break;
					case 1:
						dePos = s;
						break;
					case 2:
						deDefs = s;
						break;
					case 3:
						deUrl = s;
						break;
				}
				counter++;
			}
			return new DictionaryEntry(deWord, dePos, deUrl, deDefs, false);
		}
	}
}
