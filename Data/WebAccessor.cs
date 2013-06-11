using System;
using HtmlAgilityPack;

namespace WiktionaryCrawler.Data
{
	/// <summary>
	/// Gets data from wiktionary.org.
	/// </summary>
	public class WebAccessor : IDataAccessor
	{
		public string StartUrl { get; private set; }
		public string BaseUrl { get; private set; }
		internal HtmlWeb interwubs;		
		
		public WebAccessor()
		{
			interwubs = new HtmlWeb();
			StartUrl = "/wiki/Index:English/0";
			BaseUrl = "http://en.wiktionary.org";
		}
		
		/// <summary>
		/// Gets a page that contains all dictionary letter pages.
		/// </summary>
		/// <returns>An HtmlDocument.</returns>
		public HtmlDocument GetStartHtmlDocument()
		{
			return interwubs.Load(BaseUrl + StartUrl);				
		}
		
		/// <summary>
		/// Gets the specified page from a relative Url.
		/// </summary>
		/// <param name="relativeUrl">The Url to retrieve from.</param>
		/// <returns>The requested HtmlDocument.</returns>
		public HtmlDocument GetHtmlDocumentFromRelativeUrl(string relativeUrl)
		{
			return interwubs.Load(BaseUrl + relativeUrl);
		}
	}
}
