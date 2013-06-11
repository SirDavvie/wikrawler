using System;
using System.Collections.Generic;
using System.Reflection;

namespace WiktionaryCrawler.Models
{
	/// <summary>
	/// A Enum-like class that represents a part of speech (noun, verb &c.)
	/// </summary>
	public sealed class PartOfSpeech
	{
		public readonly string PosAbbreviation;
		public readonly string PosName;
		
		#region Constructors; for use in this class only.
		/// <summary>
		/// Constructs a new part of speech.  The recommended constructor.
		/// </summary>
		/// <param name="abbr">The abbreviation used by wiktionary.org.</param>
		/// <param name="name">The name of the part of speech used by wiktionary.org.</param>
		private PartOfSpeech(string abbr, string name)
		{
			PosAbbreviation = abbr;
			PosName = name;
		}
		
		/// <summary>
		/// Constructs an unitialized Part of Speech.
		/// </summary>
		private PartOfSpeech()
		{
		}
		#endregion

		#region Valid Parts Of Speech
		public static PartOfSpeech Abbreviation = new PartOfSpeech("abbr","Abbreviation");
		public static PartOfSpeech Acronym = new PartOfSpeech("acronym","Acronym");
		public static PartOfSpeech Adjective = new PartOfSpeech("adj","Adjective");
		public static PartOfSpeech Adverb = new PartOfSpeech("adv","Adverb");		
		public static PartOfSpeech Affix = new PartOfSpeech("affix","Affix");
		public static PartOfSpeech Article = new PartOfSpeech("article","Article");
		public static PartOfSpeech Conjunction = new PartOfSpeech("conj","Conjunction");
		public static PartOfSpeech Contraction = new PartOfSpeech("contraction","Contraction");
		public static PartOfSpeech Determiner = new PartOfSpeech("determiner","Determiner");
		public static PartOfSpeech Idiom = new PartOfSpeech("idiom","Idiom");
		public static PartOfSpeech Infix = new PartOfSpeech("infix","Infix");
		public static PartOfSpeech Initialism = new PartOfSpeech("init","Initialism");
		public static PartOfSpeech Interjection = new PartOfSpeech("int","Interjection");
		public static PartOfSpeech Letter = new PartOfSpeech("letter","Letter");
		public static PartOfSpeech Noun = new PartOfSpeech("n","Noun");
		public static PartOfSpeech Cardinal = new PartOfSpeech("num","Cardinal numeral");
		public static PartOfSpeech Particle = new PartOfSpeech("particle","Particle");
		public static PartOfSpeech Phrase = new PartOfSpeech("phrase","Phrase");
		public static PartOfSpeech Postposition = new PartOfSpeech("postposition","Abbreviation");
		public static PartOfSpeech Prefix = new PartOfSpeech("prefix","Prefix");
		public static PartOfSpeech Preposition = new PartOfSpeech("prep","Preposition");
		public static PartOfSpeech Pronoun = new PartOfSpeech("pronoun","Pronoun");
		public static PartOfSpeech ProperNoun = new PartOfSpeech("proper","Proper noun");
		public static PartOfSpeech Proverb = new PartOfSpeech("proverb","Proverb");
		public static PartOfSpeech Suffix = new PartOfSpeech("suffix","Suffix");
		public static PartOfSpeech Symbol = new PartOfSpeech("symbol","Symbol");
		public static PartOfSpeech Verb = new PartOfSpeech("v","Verb");	
		#endregion
		
		/// <summary>
		/// Gets a Part of Speech from the abbreviation.
		/// </summary>
		/// <param name="PosAbbreviation">A string that represents a Part of Speech (n, v).</param>
		/// <returns>The PartOfSpeech.</returns>
		public static PartOfSpeech FromPosAbbreviation(string PosAbbreviation)
	    {
	    	IEnumerable<PartOfSpeech> partsOfSpeech = GetAll();
	    	foreach (PartOfSpeech pos in partsOfSpeech)
	    	{
	    		if (pos.PosAbbreviation == PosAbbreviation)
	    		{
	    			return pos;
	    		}
	    	}
	        return null;
	    }
		
		/// <summary>
		/// Gets a PartOfSpeech from the part of speech name.
		/// </summary>
		/// <param name="PosName">A string that names a Part of Speech (noun, verb).</param>
		/// <returns>The PartOfSpeech.</returns>
	    public static PartOfSpeech FromPosName(string PosName)
	    {
	    	IEnumerable<PartOfSpeech> partsOfSpeech = GetAll();
	    	foreach (PartOfSpeech pos in partsOfSpeech)
	    	{
	    		if (pos.PosName == PosName)
	    		{
	    			return pos;
	    		}
	    	}
	        return null;
	    }
		
	    /// <summary>
	    /// Gets all valid Parts of Speech.
	    /// </summary>
	    /// <returns>An IEnumerable of all Parts of Speech in this Enum-like class.</returns>
	    public static IEnumerable<PartOfSpeech> GetAll()
	    {
	        var type = typeof(PartOfSpeech);
	        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
	
	        foreach (var info in fields)
	        {
	            var instance = new PartOfSpeech();
	            var locatedValue = info.GetValue(instance) as PartOfSpeech;
	
	            if (locatedValue != null)
	            {
	                yield return locatedValue;
	            }
	        }
	    }
	    
	    /// <summary>
	    /// Converts the part of speech to a string.
	    /// </summary>
	    /// <returns>A string equal to the part of speech name.</returns>
	    public override string ToString()
		{
			return string.Format("{0}", PosName);
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			PartOfSpeech other = obj as PartOfSpeech;
			if (other == null)
				return false;
			return this.PosAbbreviation == other.PosAbbreviation && this.PosName == other.PosName;
		}
		
		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (PosAbbreviation != null)
					hashCode += 1000000007 * PosAbbreviation.GetHashCode();
				if (PosName != null)
					hashCode += 1000000009 * PosName.GetHashCode();
			}
			return hashCode;
		}
		
		public static bool operator ==(PartOfSpeech lhs, PartOfSpeech rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}
		
		public static bool operator !=(PartOfSpeech lhs, PartOfSpeech rhs)
		{
			return !(lhs == rhs);
		}
		#endregion
	}
}
