using System;
using System.Collections.Generic;
using NUnit.Framework;
using WiktionaryCrawler.Models;

namespace WiktionaryCrawler.UnitTests
{
	[TestFixture]
	public class PartOfSpeechUnitTests
	{
		
		[Test]
		public void GetAllTest()
		{
			IEnumerable<PartOfSpeech> partsOfSpeech = PartOfSpeech.GetAll();
			int i = 0;
			foreach (PartOfSpeech pos in partsOfSpeech)
			{
				i++;
			}
			Assert.AreEqual(i, 27, "GetAll() isn't returning all of the parts of speech.");
		}

		[Test]
		public void FromPosAbbreviationTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Pronoun;
			PartOfSpeech pos2 = PartOfSpeech.FromPosAbbreviation("pronoun");
			Assert.AreEqual(pos1, pos2, "FromPosAbbreviation() is not getting the correct part of speech.");
		}
		
		[Test]
		public void FromPosNameTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Verb;
			PartOfSpeech pos2 = PartOfSpeech.FromPosName("Verb");
			Assert.AreEqual(pos1, pos2, "FromPosName() is not getting the correct part of speech.");
		}
		
		[Test]
		public void ToStringTest()
		{
			PartOfSpeech pos = PartOfSpeech.Verb;
			Assert.AreEqual(pos.ToString(), pos.PosName, "ToString() does not return the part of speech name.");
		}
		
		[Test]
		public void DotEqualsReturnsTrueTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Verb;
			PartOfSpeech pos2 = PartOfSpeech.Verb;
			
			Assert.IsTrue(pos1.Equals(pos2) && pos2.Equals(pos1), "The PartOfSpeech.Equals() returned false for equal parts of speech.");
		}
		
		[Test]
		public void DotEqualsReturnsFalseTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Verb;
			PartOfSpeech pos2 = PartOfSpeech.Noun;
			
			Assert.IsFalse(pos1.Equals(pos2) || pos2.Equals(pos1), "The PartOfSpeech.Equals() returned true for inequal parts of speech.");
		}
		
		[Test]
		public void GetHashCodeProducesUniqueValuesTest()
		{
			bool hasEqualHashCode = false;
			IEnumerable<PartOfSpeech> PosList = PartOfSpeech.GetAll();
			foreach (PartOfSpeech pos1 in PosList)
			{
				foreach (PartOfSpeech pos2 in PosList)
				{
					hasEqualHashCode = (!pos1.Equals(pos2) && pos1.GetHashCode() == pos2.GetHashCode());
				}
			}
			Assert.IsFalse(hasEqualHashCode, "Two different parts of speech have the same hash code.");
		}
		
		[Test]
		public void GetHashCodeProducesSameValuesTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Noun;
			PartOfSpeech pos2 = PartOfSpeech.Noun;
			
			Assert.IsTrue(pos1.GetHashCode() == pos2.GetHashCode()
			               , "The PartOfSpeech.GetHashCode() returned different hash codes for the same part of speech.");
		}
		
		[Test]
		public void EqualityOperatorReturnsTrueTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Verb;
			PartOfSpeech pos2 = PartOfSpeech.Verb;
			
			Assert.IsTrue(pos1 == pos2 && pos2 == pos1, "The == override claims equal values are non-equal.");
		}
		
		[Test]
		public void EqualityOperatorReturnsFalseTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Verb;
			PartOfSpeech pos2 = PartOfSpeech.Noun;
			
			Assert.IsFalse(pos1 == pos2 || pos2 == pos1, "The == override claims non-equal values are equal.");
		}
		
		[Test]
		public void InequalityReturnsTrueTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Verb;
			PartOfSpeech pos2 = PartOfSpeech.Noun;
			
			Assert.IsTrue(pos1 != pos2 && pos2 != pos1, "The != override claims inequal values are equal.");
		}
		
		[Test]
		public void InequalityReturnsFalseTest()
		{
			PartOfSpeech pos1 = PartOfSpeech.Verb;
			PartOfSpeech pos2 = PartOfSpeech.Verb;
			
			Assert.IsFalse(pos1 != pos2 || pos2 != pos1, "The != override claims equal values are inequal.");
		}
	}
}
