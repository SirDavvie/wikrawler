using System;
using System.Collections.Generic;
using WiktionaryCrawler.Models;

namespace WiktionaryCrawler.Serializers
{
	/// <summary>
	/// A contract for a class that saves a wikitionary, for instance to Sql or to a file.
	/// </summary>
	public interface IWiktionarySerializer
	{
		Boolean CheckExistence();
		
		void DeleteExisting();
		
		void CreateNew();
		
		void SerializeWiktionary(List<DictionaryEntry> wiktionary);
	}
}
