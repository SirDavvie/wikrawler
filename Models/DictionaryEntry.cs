using System;

namespace WiktionaryCrawler.Models
{
	/// <summary>
	/// Description of dictionaryEntry.
	/// </summary>
	public class DictionaryEntry
	{
		public PartOfSpeech WordPartOfSpeech { get; set; }
		public string Word { get; set; }
		public string WordUrl { get; set; }
		public string Definitions { get; set; }
		
		#region Constructors
		/// <summary>
		/// Creates a new dictionary entry.
		/// </summary>
		/// <param name="word">The word from the dictionary.</param>
		/// <param name="partOfSpeechId">A string that represents the part of speech defined.</param>
		/// <param name="wordUrl">The wiktionary.org Url from which this word can be retrieved.</param>
		/// <param name="definitions">The defitions provided by wiktionary.org</param>
		/// <param name="isPosAbbr">An optional parameter that indicates whether the string that was provided is 
		/// a Part of Speech abbreviation )true, default), or a Part of Speech name (false, not default).</param>
		public DictionaryEntry(string word, string partOfSpeechId, string wordUrl, string definitions, bool isPosAbbr=true)
		{
			PartOfSpeech wpos;
			if (isPosAbbr)
			{
				wpos = PartOfSpeech.FromPosAbbreviation(partOfSpeechId);
			}
			else
			{
				wpos = PartOfSpeech.FromPosName(partOfSpeechId);
			}
			SetupDictionaryEntry(word, wpos, wordUrl, definitions);
		}
		
		/// <summary>
		/// Creates a new dictionary entry.
		/// </summary>
		/// <param name="word">The word from the dictionary.</param>
		/// <param name="wordPartOfSpeech">The PartOfSpeech defined.</param>
		/// <param name="wordUrl">The wiktionary.org Url from which this word can be retrieved.</param>
		/// <param name="definitions">The defitions provided by wiktionary.org</param>
		public DictionaryEntry(string word, PartOfSpeech wordPartOfSpeech, string wordUrl, string definitions)
		{
			SetupDictionaryEntry(word, wordPartOfSpeech, wordUrl, definitions);
		}
		
		/// <summary>
		/// Copies an existing dictionary entry.
		/// </summary>
		/// <param name="toCopy">The dictionary entry to copy.</param>
		public DictionaryEntry(DictionaryEntry toCopy)
		{
			SetupDictionaryEntry(toCopy.Word, toCopy.WordPartOfSpeech, toCopy.WordUrl, toCopy.Definitions);
		}
		
		/// <summary>
		/// Constructs an unitialized Dictionary Entry.
		/// </summary>
		public DictionaryEntry()
		{
			
		}
		
		/// <summary>
		/// A helper function to ensure all constructors work the same.
		/// </summary>
		/// <param name="word">The word.</param>
		/// <param name="wordPartOfSpeech">The word's part of speech.</param>
		/// <param name="wordUrl">The wiktionary.org Url from which the word was retrieved.</param>
		/// <param name="definitions">The definitions listed by wikitionary.org</param>
		private void SetupDictionaryEntry(string word, PartOfSpeech wordPartOfSpeech, string wordUrl, string definitions)
		{
			WordPartOfSpeech = wordPartOfSpeech;
			Word = word;
			WordUrl = wordUrl;
			Definitions = definitions;
		}
		#endregion
		
		/// <summary>
		/// Converts the Dictionary Entry to a string.
		/// </summary>
		/// <returns>A string in the format: "{Word} {(part of speech abbreviation)}: {definition} Retrieved from: {wordUrl}"</returns>
		public override string ToString()
		{
			return string.Format("{0} ({1}): {2} Retrieved from: {3}", Word, WordPartOfSpeech.PosAbbreviation, Definitions, WordUrl);
		}

		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			DictionaryEntry other = obj as DictionaryEntry;
			if (other == null)
				return false;
			return this.WordPartOfSpeech == other.WordPartOfSpeech && this.Word == other.Word;
		}
		
		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (WordPartOfSpeech != null)
					hashCode += 1000000007 * WordPartOfSpeech.GetHashCode();
				if (Word != null)
					hashCode += 1000000009 * Word.GetHashCode();
			}
			return hashCode;
		}
		
		public static bool operator ==(DictionaryEntry lhs, DictionaryEntry rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}
		
		public static bool operator !=(DictionaryEntry lhs, DictionaryEntry rhs)
		{
			return !(lhs == rhs);
		}
		#endregion
	}
}
