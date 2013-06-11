using System;
using NUnit.Framework;
using WiktionaryCrawler.Models;

namespace WiktionaryCrawler.UnitTests
{
	[TestFixture]
	public class DictionaryEntryUnitTests
	{	
		[Test]
		public void ConstructorFromPosNameTest()
		{
			DictionaryEntry standardDE = new DictionaryEntry();
			standardDE.Word = "machinate";
			standardDE.WordPartOfSpeech = PartOfSpeech.Verb;
			standardDE.WordUrl = "http://en.wiktionary.org/wiki/machinate";
			standardDE.Definitions = "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.";
			
			DictionaryEntry testDE = new DictionaryEntry("machinate", 
			                                             "Verb", 
			                                             "http://en.wiktionary.org/wiki/machinate", 
			                                             "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.",
			                                             false);
			
			Assert.IsTrue(HasAllFieldsEqual(standardDE, testDE), "The PosName Constructor is not returning the expected object.");
		}
		
		[Test]
		public void ConstructorFromPosAbbreviationTest()
		{
			DictionaryEntry standardDE = new DictionaryEntry();
			standardDE.Word = "machinate";
			standardDE.WordPartOfSpeech = PartOfSpeech.Verb;
			standardDE.WordUrl = "http://en.wiktionary.org/wiki/machinate";
			standardDE.Definitions = "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.";
			
			DictionaryEntry testDE = new DictionaryEntry("machinate", 
			                                             "v", 
			                                             "http://en.wiktionary.org/wiki/machinate", 
			                                             "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.", 
			                                             true);
			
			Assert.IsTrue(HasAllFieldsEqual(standardDE, testDE), "The PosName Constructor is not returning the expected object.");
		}
		
		[Test]
		public void CopyConstructorEqualsOriginalTest()
		{
			DictionaryEntry originalDE = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			DictionaryEntry copyDE = new DictionaryEntry(originalDE);

			Assert.IsTrue(HasAllFieldsEqual(originalDE, copyDE), "The copy constructor doesn't produce an identical object.");
		}
		
		[Test]
		public void DotEqualsReturnsTrueTest()
		{
			DictionaryEntry deMock1 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			DictionaryEntry deMock2 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			
			Assert.IsTrue(deMock1.Equals(deMock2) && deMock2.Equals(deMock1), "The PartOfSpeech.Equals() override has failed.");
		}
		
		[Test]
		public void DotEqualsReturnsFalseTest()
		{
			DictionaryEntry deMock1 = new DictionaryEntry("vulgarian", 
			                                          PartOfSpeech.Noun, 
			                                          "http://en.wiktionary.org/wiki/vulgarian", 
			                                          "1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities.");
			DictionaryEntry deMock2 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                        "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			
			Assert.IsFalse(deMock1.Equals(deMock2) || deMock2.Equals(deMock1), "The PartOfSpeech.Equals() override has failed.");
		}
		
		[Test]
		public void GetHashCodeProducesUniqueValuesTest()
		{
			DictionaryEntry deMock1 = new DictionaryEntry("vulgarian", 
			                                          PartOfSpeech.Noun, 
			                                          "http://en.wiktionary.org/wiki/vulgarian", 
			                                          "1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities.");
			DictionaryEntry deMock2 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                        "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");

			Assert.IsTrue(deMock1.GetHashCode() != deMock2.GetHashCode(), "The == override claims non-equal values are equal.");
		}
		
		[Test]
		public void GetHashCodeProducesSameValuesTest()
		{
			DictionaryEntry deMock1 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			DictionaryEntry deMock2 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			
			Assert.IsTrue(deMock1.GetHashCode() == deMock2.GetHashCode(), 
			              "GetHashCode() does not produce the same hash code for the same dictionary entry.");
		}
		
		[Test]
		public void EqualityOperatorReturnsTrueTest()
		{
			DictionaryEntry deMock1 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			DictionaryEntry deMock2 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			
			Assert.IsTrue(deMock1 == deMock2 && deMock2 == deMock1, "The == override claims equal values are inequal.");
		}
		
		[Test]
		public void EqualityOperatorReturnsFalseTest()
		{
			DictionaryEntry deMock1 = new DictionaryEntry("vulgarian", 
			                                          PartOfSpeech.Noun, 
			                                          "http://en.wiktionary.org/wiki/vulgarian", 
			                                          "1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities.");
			DictionaryEntry deMock2 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                        "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");

			Assert.IsFalse(deMock1 == deMock2 || deMock2 == deMock1, "The == override claims non-equal values are equal.");
		}
		
		[Test]
		public void InequalityReturnsTrueTest()
		{
			DictionaryEntry deMock1 = new DictionaryEntry("vulgarian", 
			                                          PartOfSpeech.Noun, 
			                                          "http://en.wiktionary.org/wiki/vulgarian", 
			                                          "1.) A vulgar individual, especially one who emphasizes or is oblivious to their vulgar qualities.");
			DictionaryEntry deMock2 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                        "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			
			Assert.IsTrue(deMock1 != deMock2 && deMock2 != deMock1, "The != override claims inequal values are equal.");
		}
		
		[Test]
		public void InequalityReturnsFalseTest()
		{
			DictionaryEntry deMock1 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			DictionaryEntry deMock2 = new DictionaryEntry("machinate",
			                                         PartOfSpeech.Verb,
			                                         "http://en.wiktionary.org/wiki/machinate",
			                                         "1.) (transitive or intransitive) To devise a plot or secret plan; to conspire.");
			
			Assert.IsFalse(deMock1 != deMock2 || deMock2 != deMock1, "The != override claims equal values are inequal.");
		}
		
		public static bool HasAllFieldsEqual(DictionaryEntry deMock1, DictionaryEntry deMock2)
		{
			bool areEqual = deMock1.Equals(deMock2);
			
			var type = typeof(DictionaryEntry);
			var fields = type.GetProperties();
	
	        foreach (var info in fields)
	        {
	        	areEqual = areEqual && (info.GetValue(deMock1).ToString().Trim() == info.GetValue(deMock2).ToString().Trim());
	        }
			return areEqual;	        
		}
	}
}
