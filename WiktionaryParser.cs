using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WiktionaryCrawler.Data;
using WiktionaryCrawler.Models;
using WiktionaryCrawler.Serializers;

namespace WiktionaryCrawler
{
	/// <summary>
	/// A class that parses the Html from the web page.
	/// </summary>
	public class WiktionaryParser
	{	
		public IDataAccessor DataAccess { get; set; }
		public IWiktionarySerializer WikiSerializer { get; set; }
		
		#region Constructors
		/// <summary>
		/// Constructs a new WiktionaryParser with a web accessor and a file manager.
		/// </summary>
		public WiktionaryParser()
		{
			DataAccess = new WebAccessor();
			WikiSerializer = new FileManager();
		}
		
		/// <summary>
		/// Constructs a new WiktionaryParser.
		/// </summary>
		/// <param name="wikiSerializer">An object that serializes a List of Dictionary Entries (implements IWiktionarySerializer).</param>
		/// <param name="dataAccess">An object that accesses wikitionary.org (implements IDataAccessor)</param>
		public WiktionaryParser(IWiktionarySerializer wikiSerializer, IDataAccessor dataAccess)
		{
			DataAccess = dataAccess;
			WikiSerializer = wikiSerializer;
		}
		
		/// <summary>
		/// Copies an existing WiktionaryParser.
		/// </summary>
		/// <param name="toCopy">The WiktionaryParser to copy.</param>
		public WiktionaryParser(WiktionaryParser toCopy)
		{
			DataAccess = toCopy.DataAccess;
			WikiSerializer = toCopy.WikiSerializer;
		}
		#endregion
		
		/// <summary>
		/// Retrieves the current version of wiktionary.org and saves it to the specified medium.
		/// </summary>
		/// <returns>True if the list of dictionary entries was created successfully, false otherwise.</returns>
		public bool GetDictionary()
		{
			List<string> pages = GetListOfLetterPages();
			List<DictionaryEntry> wiktionary = new List<DictionaryEntry>();

			foreach (string s in pages)
			{
				wiktionary = GetWordsFromPage(s);
				WikiSerializer.SerializeWiktionary(wiktionary);
			}
			return true;
		}
		
		/// <summary>
		/// To comply with the Wikimedia Terms of Service, this method exposes the Urls from which the dictionary is scraped.
		/// </summary>
		/// <returns>A list of Urls as strings.</returns>
		public List<string> GetListOfLetterPages()
		{
			HtmlDocument wikiDoc = DataAccess.GetStartHtmlDocument();
			List<string> letterUrls = new List<string>();
			foreach (HtmlNode link in wikiDoc.DocumentNode.SelectNodes("//div[@id='mw-content-text']/center/p/a[@href]"))
			{
				foreach (HtmlAttribute att in link.Attributes.AttributesWithName("href"))
				{
					letterUrls.Add(att.Value.ToString());
				}
			}
			//Include the starting Url, since it's disabled on the start page
			letterUrls.Add(DataAccess.StartUrl);			
			return letterUrls;
		}
		
		/// <summary>
		/// Gets the list of words from a page of wiktionary.org.
		/// </summary>
		/// <param name="path">The relative path of the page of words to be parsed.</param>
		/// <returns>A list of DictionaryEntries.</returns>
		public List<DictionaryEntry> GetWordsFromPage(string path)
		{
			string currWord;
			string currWordUri;
			Dictionary<PartOfSpeech, string> currDefinitions;
			List<DictionaryEntry> wiktionaryPage = new List<DictionaryEntry>();
			
			HtmlDocument wikiDoc = DataAccess.GetHtmlDocumentFromRelativeUrl(path);
			HtmlNodeCollection hnc = wikiDoc.DocumentNode.SelectNodes("//div[@id='mw-content-text']/div[@class='index']/ol/li");
			if (hnc == null || hnc.Count < 1)
			{
				return null;
			}
			foreach (HtmlNode entry in hnc)
			{
				//Omit words that have no part of speech
				if (entry.LastChild.HasAttributes)
				{
					continue;
				}
				currWord = entry.FirstChild.InnerText;
				currWordUri = GetFirstAttributeByName(entry.FirstChild, "href");
				currDefinitions = GetDefinitions(currWordUri);
				if (currDefinitions == null)
				{
					continue;
				}
				foreach (PartOfSpeech k in currDefinitions.Keys)
				{
					wiktionaryPage.Add(new DictionaryEntry(currWord, k, currWordUri, currDefinitions[k]));
				}
			}
			return wiktionaryPage;
		}
		
		/// <summary>
		/// Gets the first attribute in a node by name.
		/// </summary>
		/// <param name="node">The node to search for the attribute.</param>
		/// <param name="attributeName">The attribute to retrieve.</param>
		/// <returns>The first value of the attribute if it exists, null otherwise.</returns>
		internal string GetFirstAttributeByName(HtmlNode node, string attributeName)
		{
			//HtmlAttribute doesn't support an index and doesn't have a getfirstElement method 
			foreach (HtmlAttribute att in node.Attributes.AttributesWithName(attributeName))
			{
				return att.Value.ToString();
			}
			return null;
		}
		
		/// <summary>
		/// Gets the definitions listed on a page for a single word.
		/// </summary>
		/// <param name="wordUrl">The relative Url of the word.</param>
		/// <returns>A Dictionary of parts of speech and definitions from the page.</returns>
 		internal Dictionary<PartOfSpeech, string> GetDefinitions(string wordUrl)
		{
			if (wordUrl.Contains("redlink"))
			{
				return null;
			}
			HtmlDocument wordPage = DataAccess.GetHtmlDocumentFromRelativeUrl(wordUrl);
			HtmlNode textContent = GetFirstNode(wordPage.DocumentNode.SelectNodes("//div[@id='mw-content-text']"));
			HtmlNodeCollection definitionNodes = textContent.SelectNodes("ol");	
			Dictionary<PartOfSpeech, List<string>> defsDict = new Dictionary<PartOfSpeech, List<string>>();
			StringBuilder defBuilder = new StringBuilder();
			HtmlNode currPosNode;
			string currPosText;
			PartOfSpeech currPos;
			
			if (definitionNodes == null)
			{
				return null;
			}
			for (int i = 0; i < definitionNodes.Count; i++)
			{
				currPosNode = definitionNodes[i].PreviousSibling.PreviousSibling;
				currPosText = currPosNode.InnerText;
				
				if (currPosText.Contains("["))
			    {
					currPos = PartOfSpeech.FromPosName(currPosText.Substring(0,currPosNode.InnerText.IndexOf("[")));			    	
			    }
				else
				{
					currPos = PartOfSpeech.FromPosName(currPosText.Trim());
				}
				if (currPos == null)
				{
					continue;
				}
				if (!defsDict.ContainsKey(currPos))
				{
					defsDict.Add(currPos, new List<string>());
				}
				foreach (HtmlNode li in definitionNodes[i].SelectNodes("li"))
				{
					foreach (HtmlNode child in li.ChildNodes)
					{
						defBuilder.Append(child.InnerText);
					}
					defsDict[currPos].Add(defBuilder.ToString());
					defBuilder.Clear();
				}
			}
			
			return FinalizeDictionary(defsDict);
		}
		
 		/// <summary>
 		/// Gets the first node from node collection.
 		/// </summary>
 		/// <param name="hnc">The node to get the first node from.</param>
 		/// <returns>The first node in the collection if it exists, null otherwise.</returns>
		internal HtmlNode GetFirstNode(HtmlNodeCollection hnc)
		{
			if (hnc == null)
			{
				return null;
			}
			foreach (HtmlNode hn in hnc)
			{
				return hn;
			}
			return null;
		}
	
		/// <summary>
		/// Converts a list of definitions to a definition string in a dictionary.
		/// </summary>
		/// <param name="workingDict">The dictionary to be finalized.</param>
		/// <returns>The dictionary ready to pack up into a List of DictionaryEntry.</returns>
		internal Dictionary<PartOfSpeech, string> FinalizeDictionary(Dictionary<PartOfSpeech, List<string>> workingDict)
		{
			Dictionary<PartOfSpeech, string> finalDict = new Dictionary<PartOfSpeech, string>();
			StringBuilder defsBuilder = new StringBuilder();
			int counter = 0;
			
			foreach (PartOfSpeech k in workingDict.Keys)
			{
				foreach (string s in workingDict[k])
				{
					counter++;
					defsBuilder.Append(counter.ToString() + ".) " + s);
				}
				finalDict.Add(k, defsBuilder.ToString());
				counter = 0;
				defsBuilder.Clear();
			}
			return finalDict;
		}
	}
}
