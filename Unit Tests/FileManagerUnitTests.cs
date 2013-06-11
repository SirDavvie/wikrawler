using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using WiktionaryCrawler.Data;
using WiktionaryCrawler.Models;
using WiktionaryCrawler.Serializers;

namespace WiktionaryCrawler.UnitTests
{
	[TestFixture]
	public class FileManagerUnitTests
	{
		[Test]
		public void CheckExistenceReturnsTrueTest()
		{
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			FileManager testFC = new FileManager(testFileName);
			
			File.Create(testFileName);
			
			Assert.IsTrue(testFC.CheckExistence(), "The file existence check did not detect an existing file.");
		}
		
		[Test]
		public void CheckExistenceReturnsFalseTest()
		{
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			FileManager testFC = new FileManager(testFileName);
			
			if (File.Exists(testFileName))
			{
				File.Delete(testFileName);
			}
			
			Assert.IsFalse(testFC.CheckExistence(), "The file existence check detected an non-existant file.");
		}
		
		[Test]
		public void DeleteExistingForExistingFileTest()
		{
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			FileStream fs = File.Create(testFileName);
			fs.Close();
			fs.Dispose();
			
			FileManager testFC = new FileManager(testFileName);
			testFC.DeleteExisting();
			
			bool exists = File.Exists(testFileName);
			Assert.IsFalse(exists, "FileCreator did not delete the file as expected.");
		}
		
		[Test]
		public void DeleteExistingForNonexistentFileTest()
		{
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			bool wasSuccessful = true;
			if (File.Exists(testFileName))
			{
				File.Delete(testFileName);
			}
			
			FileManager testFC = new FileManager(testFileName);
			try
			{
				testFC.DeleteExisting();				
			}
			catch
			{
				wasSuccessful = false;
			}
			
			bool exists = File.Exists(testFileName);
			Assert.IsTrue(wasSuccessful && !exists, "FileCreator did not delete the file as expected.");			
		}
	
		[Test]
		public void CreateNewForExistingFileTest()
		{
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			bool wasSuccessful = true;
			if (File.Exists(testFileName))
			{
				FileStream fs = File.Create(testFileName);
				fs.Close();
				fs.Dispose();
			}
			
			FileManager testFC = new FileManager(testFileName);
			try
			{
				testFC.CreateNew();
			}
			catch
			{
				wasSuccessful = false;
			}
			
			bool exists = File.Exists(testFileName);
			Assert.IsTrue(wasSuccessful && exists, "FileCreator did not create the file as expected.");			
		}
		
		[Test]
		public void CreateNewForNonexistentFileTest()
		{
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			bool wasSuccessful = true;
			if (File.Exists(testFileName))
			{
				File.Delete(testFileName);
			}
			
			FileManager testFC = new FileManager(testFileName);
			try
			{
				testFC.CreateNew();
			}
			catch
			{
				wasSuccessful = false;
			}
			
			bool exists = File.Exists(testFileName);
			Assert.IsTrue(wasSuccessful && exists, "FileCreator did not create the file as expected.");			
		}
	
		[Test]
		public void CreateNewReleasesLockTest()
		{
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			bool isLocked = false;
			FileStream fs = null;
			string errorMessage = null;
			
			if (File.Exists(testFileName))
			{
				File.Delete(testFileName);
			}
			
			FileManager testFC = new FileManager(testFileName);
			try
			{
				testFC.CreateNew();
				fs = File.OpenRead(testFileName);
			}
			catch (Exception e)
			{
				isLocked = true;
				errorMessage = e.Message;
			}
			finally
			{
				fs.Close();
				fs.Dispose();
			}
			
			Assert.IsFalse(isLocked, "FileCreator did not properly release the lock; threw error: " + errorMessage);			
		}
	
		[Test]
		public void SerializeWiktionaryReleasesLockTest()
		{
			List<DictionaryEntry> wikiMock = new List<DictionaryEntry>();
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			bool isLocked = false;
			
			wikiMock.Add(new DictionaryEntry("vulgarian", 
	                                          PartOfSpeech.Noun, 
	                                          "http://en.wiktionary.org/wiki/vulgarian", 
	                                          "1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities."));
			wikiMock.Add(new DictionaryEntry("machinate",
	                                         PartOfSpeech.Verb,
	                                         "http://en.wiktionary.org/wiki/machinate",
	                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire."));
			
			FileManager fc = new FileManager(testFileName);
			if(fc.CheckExistence())
			{
				fc.DeleteExisting();
			}
			fc.SerializeWiktionary(wikiMock);
			
			try
			{
				FileStream fs = File.OpenRead(testFileName);
				fs.Close();
				fs.Dispose();
			}
			catch
			{
				isLocked = true;
			}

			Assert.IsFalse(isLocked, "The file is still locked.");
		}
		
		[Test]
		public void SerializeWiktionaryTest()
		{
			List<DictionaryEntry> wikiMock = new List<DictionaryEntry>();
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			bool matchesExpected = true;
			
			wikiMock.Add(new DictionaryEntry("vulgarian", 
	                                          PartOfSpeech.Noun, 
	                                          "http://en.wiktionary.org/wiki/vulgarian", 
	                                          "1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities."));
			wikiMock.Add(new DictionaryEntry("machinate",
	                                         PartOfSpeech.Verb,
	                                         "http://en.wiktionary.org/wiki/machinate",
	                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire."));
			
			FileManager fc = new FileManager(testFileName);
			if(fc.CheckExistence())
			{
				fc.DeleteExisting();
			}
			fc.CreateNew();
			fc.SerializeWiktionary(wikiMock);
			
			using (FileStream fs = File.OpenRead(testFileName))
			{
				using (StreamReader sr = new StreamReader(fs))
				{
					int counter = 0;
					string line = "";
					while (sr.Peek() >= 0)
					{
						line = sr.ReadLine();
						switch (counter)
						{
							case 0:
								matchesExpected = matchesExpected
									//Check for the two parts that aren't the date
									&& line.Contains("Wiktionary retrieved on: ") 
									&& line.Contains(" columns: Word|Part Of Speech|Definitions|Word Url");
								break;
							case 1:
								matchesExpected = matchesExpected 
									&& line == "vulgarian|Noun|1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities.|http://en.wiktionary.org/wiki/vulgarian";
								break;
							case 2:
								matchesExpected = matchesExpected
									&& line == "machinate|Verb|1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.|http://en.wiktionary.org/wiki/machinate";
								break;
							default:
								if (!string.IsNullOrWhiteSpace(line))
								{
									matchesExpected = false;
								}
								break;
						}
						counter++;
					}
					Assert.IsTrue(matchesExpected, "The serialized file was not as expected.");
				}
			}
		}
	
		[Test]
		public void GetDictionaryEntryFromStringTest()
		{
			string fileContentsMock = "vulgarian|Noun|1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities.|http://en.wiktionary.org/wiki/vulgarian";
			DictionaryEntry deExpected = new DictionaryEntry("vulgarian", 
					                                          PartOfSpeech.Noun, 
					                                          "http://en.wiktionary.org/wiki/vulgarian", 
					                                          "1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities.");
			FileManager fm = new FileManager();
			DictionaryEntry deTest = fm.GetDictionaryEntryFromString(fileContentsMock);
			Console.WriteLine(deTest.ToString());
			
			Assert.IsTrue(DictionaryEntryUnitTests.HasAllFieldsEqual(deExpected, deTest),
			              "The dictionary entry was not rehydrated properly.");
		}
		
		[Test]
		public void DeserializeWiktionaryTest()
		{
			List<DictionaryEntry> wikiMock = new List<DictionaryEntry>();
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			
			wikiMock.Add(new DictionaryEntry("vulgarian", 
	                                          PartOfSpeech.Noun, 
	                                          "http://en.wiktionary.org/wiki/vulgarian", 
	                                          "1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities."));
			wikiMock.Add(new DictionaryEntry("machinate",
	                                         PartOfSpeech.Verb,
	                                         "http://en.wiktionary.org/wiki/machinate",
	                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire."));
			
			FileManager fm = new FileManager(testFileName);
			if(fm.CheckExistence())
			{
				fm.DeleteExisting();
			}
			fm.CreateNew();
			fm.SerializeWiktionary(wikiMock);

			List<DictionaryEntry> testWiki = fm.DeserializeWiktionary();
			Assert.AreEqual(wikiMock, testWiki, "The file did not deserialize properly.");
		}
	}
}
