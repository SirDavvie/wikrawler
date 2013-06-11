using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using HtmlAgilityPack;
using WiktionaryCrawler.Data;
using WiktionaryCrawler.Models;
using WiktionaryCrawler.Serializers;

namespace WiktionaryCrawler.UnitTests
{
	[TestFixture]
	public class WiktionaryParserUnitTests
	{
		[Test]
		public void GetDictionaryTest()
		{
			string testFileName = MethodBase.GetCurrentMethod().Name + "testfile.txt";
			FileManager fm = new FileManager(testFileName);
			if (fm.CheckExistence())
			{
				fm.DeleteExisting();
			}
			fm.CreateNew();
			WiktionaryParser wp = new WiktionaryParser(fm, new WebMock());
			if (!wp.GetDictionary())
			{
				Assert.Fail("GetDictionary reported failure.");
			}
			
			int lineCount = 0;
			using (FileStream fs = File.OpenRead(testFileName))
			{
				using (StreamReader sr = new StreamReader(fs))
				{
					string line = "";
					while (sr.Peek() >= 0)
					{
						line = sr.ReadLine();
						if (!string.IsNullOrWhiteSpace(line))
						{
							lineCount++;
						}
					}
				}
			}
		 	//Page reports 567 words x 2 parts of speech x 3 pages + 1 header line = 3403 lines.
		 	Assert.AreEqual(3403, lineCount, "GetDictionary() returned an incorrect number of entries.");
		}
		
		[Test]
		public void GetListOfLetterPagesTest()
		{
			WiktionaryParser wp = new WiktionaryParser(new FileManager("wiktionary.txt"), new WebMock());
			List<string> mockUrls = wp.GetListOfLetterPages();
			//A1, Z, and 0
			Assert.AreEqual(mockUrls.Count, 3, "GetListOfLetterPages() is not returning the expected number of pages.");
		}
		
		[Test]
		public void GetWordsFromPageTest()
		 {
		 	WiktionaryParser wp = new WiktionaryParser(new FileManager("wiktionary.txt"), new WebMock());
		 	List<DictionaryEntry> mockPages = wp.GetWordsFromPage("testPage");
		 	//Page reports 567 words x 2 parts of speech = 1180 dictionary entries.
		 	Assert.AreEqual(mockPages.Count, 1134, "GetWordsFromPage() is not returned the expected number of words.");
		 }
		
		[Test]
		public void GetFirstAttributeByNameForExistingAttributeTest()
		{
			string mockHtmlStr = "<!DOCTYPE html><a href='www.example.com'>1</a><a href='www.failedexample.com'>2</a></html>";
			HtmlDocument mockHtml = new HtmlDocument();
			
			mockHtml.LoadHtml(mockHtmlStr);
			WiktionaryParser wc = new WiktionaryParser();
			HtmlNode firstNode = wc.GetFirstNode(mockHtml.DocumentNode.SelectNodes("//a"));
			
			Assert.AreEqual("www.example.com",
			                wc.GetFirstAttributeByName(firstNode, "href"), 
			                "GetFirstAttributeByName() is not returning a present attribute.");
		}
		
		[Test]
		public void GetFirstAttributeByNameForNonexistentAttributeTest()
		{
			string mockHtmlStr = "<!DOCTYPE html><div id='testId'>1</div><div>2</div></html>";
			HtmlDocument mockHtml = new HtmlDocument();
			
			mockHtml.LoadHtml(mockHtmlStr);
			WiktionaryParser wc = new WiktionaryParser();
			HtmlNode firstNode = wc.GetFirstNode(mockHtml.DocumentNode.SelectNodes("//div"));
			
			Assert.IsNull(wc.GetFirstAttributeByName(firstNode, "href"),
			              "GetFirstAttributeByName() is returning an erroneous attribute.");
		}
		
		[Test]
		public void GetDefinitionsTest()
		{
			WiktionaryParser wp = new WiktionaryParser(new FileManager("wiktionary.txt"), new WebMock());
			Dictionary<PartOfSpeech, string> wikiPage = wp.GetDefinitions("testWord");
			bool areEqual = true;
			Dictionary<PartOfSpeech, string> expected = new Dictionary<PartOfSpeech, string>();
			expected.Add(PartOfSpeech.Noun, 
			             "1.) (now Scotland) A pig, especially a young pig, or its meat; sometimes specifically, a breed of wild pig or boar native to Scotland, now extinct.1728, Robert Lindsay, The history of Scotland, from 21 February, 1436. to March, 1565: in which are contained accounts of many remarkable passages altogether differing from our other historians, and many facts are related, either concealed by some, or omitted by others, publ. Mr. Baskett and Company, pg.146:Further, there was of meats wheat bread, main-bread and ginge-bread with fleshes, beef, mutton, lamb, veal, venison, goose, grice, capon, coney, cran, swan, partridge, plover, duck, drake, brissel-cock and pawnies, black-cock and muir-fowl, cappercaillies;1789, William Thomson, Mammuth: or, human nature displayed on a grand scale: in a tour with the tinkers, into the inland parts of Africa. By the man in the moon. In two volumes. publ. G. and T. Wilkie, pg.105:Through a door to one of the galleries, left half open on purpose I was attracted to a dainty hot supper, consisting of stewed mushrooms and the fat paps and ears of very young pigs, or, as they call them, grice.2006, \"Extinct island pig spotted again,\" BBC News, 17 November 2006, [1]:A model of the grice - which was the size of a large dog and had tusks - has been created after work by researchers and a taxidermist.2.) (obsolete) A gree; a step.(Can we find and add a quotation of Ben Jonson to this entry?)3.) pig, piglet1817, Walter Scott, Rob Roy:‘Sae, an it come to the warst, I'se een lay the head o' the sow to the tail o' the grice.’");
			expected.Add(PartOfSpeech.Verb,
			             "1.) (UK, rail transport, slang) to act as a trainspotter; to partake in the activity or hobby of trainspotting.1999 March 29,   Polson, Tony, “Re: Do all UK rail staff get free unlimited Eurostar travel?”, uk.railway, Usenet:Many people joined the railways because the 'carrot' of a staff pass was a considerable attraction, whether for family travel or to grice at extremely low cost.2005, The Railway Magazine, volume 151, number 1252, IPC Business Press, page 55:?We can also roganise photo charters, large group footplate courses and gricing holidays [...]2010,  Adam Jacot de Boinod,  “Gricer's Daughter”, in  I Never Knew There Was a Word For It[4], ISBN 9780141028392:Trainspotters may be mocked by the outside world, but they don't take criticism lying down: the language of gricing is notable for its acidic descriptions of outsiders.");
			
			foreach (var k in expected.Keys)
			{
				areEqual = areEqual &&
					(wikiPage.ContainsKey(k)) &&
					(wikiPage[k] == expected[k]);
			}
			
			Assert.IsTrue(areEqual, "GetDefinitions() are not returning all expected keys.");
		}
		
		[Test]
		public void GetFirstNodeForExistingNodeTest()
		{
			string mockHtmlStr = "<!DOCTYPE html><div>1</div><div>2</div></html>";
			HtmlDocument mockHtml = new HtmlDocument();
			mockHtml.LoadHtml(mockHtmlStr);
			WiktionaryParser wc = new WiktionaryParser();
			
			string firstNodeContents = wc.GetFirstNode(mockHtml.DocumentNode.SelectNodes("//div")).InnerText;
			
			Assert.IsTrue(firstNodeContents == "1", "GetFirstNode is not returning the first node.");
		}
		
		[Test]
		public void GetFirstNodeForNonexistentNodeTest()
		{
			string mockHtmlStr = "<!DOCTYPE html><div>1</div><div>2</div></html>";
			HtmlDocument mockHtml = new HtmlDocument();
			mockHtml.LoadHtml(mockHtmlStr);
			WiktionaryParser wc = new WiktionaryParser();
			bool succeeded = true;
			
			HtmlNode hn = new HtmlNode(HtmlNodeType.Text, mockHtml, 2);
			try
			{
				hn = wc.GetFirstNode(mockHtml.DocumentNode.SelectNodes("//a"));
			}
			catch
			{
				succeeded = false;
			}
			
			Assert.IsTrue((hn == null) && succeeded, "GetFirstNode is not returning the first node.");
		}
	}
}
