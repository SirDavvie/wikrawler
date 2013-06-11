using System;
using HtmlAgilityPack;

namespace WiktionaryCrawler.Data
{
	/// <summary>
	/// The contract for a method that accesses the raw wikitionary data (for instance: web, api, mock)
	/// </summary>
	public interface IDataAccessor
	{
		string StartUrl { get; }
		string BaseUrl { get; }
		
		HtmlDocument GetStartHtmlDocument();
		
		HtmlDocument GetHtmlDocumentFromRelativeUrl(string relativeUrl);
	}
}
