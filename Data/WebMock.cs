using System;
using HtmlAgilityPack;

namespace WiktionaryCrawler.Data
{
	/// <summary>
	/// A class for unit tests; simulates accessing a wikitionary web pages as of 6/2013.
	/// </summary>
	public class WebMock : IDataAccessor
	{
		public string StartUrl { get; private set; }
		public string BaseUrl { get; private set; }		
		
		public WebMock()
		{
			StartUrl = "/wiki/Index:English/0";
			BaseUrl = "http://en.wiktionary.org";			
		}
		
		/// <summary>
		/// Gets a page that contains links to all the pages with the words.
		/// </summary>
		/// <returns>An HtmlDocument.</returns>
		public HtmlDocument GetStartHtmlDocument()
		{
			string mockWebCall = GetMockPage("startDoc");
			HtmlDocument mockHtml = new HtmlDocument();
			mockHtml.LoadHtml(mockWebCall);
			return mockHtml;
		}
		
		/// <summary>
		/// Gets fake web pages.
		/// </summary>
		/// <param name="relativeUrl">A fake Url.</param>
		/// <returns>An HtmlDocument.</returns>
		public HtmlDocument GetHtmlDocumentFromRelativeUrl(string relativeUrl)
		{
			string mockWebCall;
			if (relativeUrl == "startDoc" || relativeUrl == "testWord" || relativeUrl == "testPage")
			{
				mockWebCall = GetMockPage(relativeUrl);
			}
			else if (relativeUrl.Contains("/wiki/Index:English/"))
			{
				mockWebCall = GetMockPage("testPage");
			}
			else
			{
				mockWebCall = GetMockPage("testWord");
			}
			HtmlDocument mockHtml = new HtmlDocument();
			mockHtml.LoadHtml(mockWebCall);
			return mockHtml;			
		}
		
		/// <summary>
		/// A helper method that stores Html from wiktionary.org, retrieved 6/2013, for unit testing.
		/// </summary>
		/// <param name="relativeUrl">A fake Url. "startDoc" returns a page with a mock list of pages that have a list of words;
		/// "testWord" returns the page for the word Grice; and "testPage" returns the page for the letter X.</param>
		/// <returns>A string containing an Html document for testing.</returns>
		internal string GetMockPage(string relativeUrl)
		{
			string wikiPage = "";
			switch(relativeUrl)
			{
				case "startDoc":
					wikiPage = "<!DOCTYPE html>" + 
								"<html lang=\"en\" dir=\"ltr\" class=\"client-nojs\">" + 
								"<head></head>" + 
								"<body class=\"mediawiki ltr sitedir-ltr ns-104 ns-subject page-Index_English_0 skin-vector action-view vector-animateLayout\">" + 
								"<div id=\"mw-content-text\" lang=\"en\" dir=\"ltr\" class=\"mw-content-ltr\"><dl>" + 
								"<dd><i>The <b>453</b> terms on this page were extracted from the 2012-Apr-28 database dump.</i></dd>" + 
								"</dl>" + 
								"<hr />" + 
								"<center>" + 
								"<p><strong class=\"selflink\">#</strong> • <a href=\"/wiki/Index:English/a1\" title=\"Index:English/a1\">A<sup>m</sup></a> • <a href=\"/wiki/Index:English/z\" title=\"Index:English/z\">Z</a></p>" + 
								"</center>" + 
								"<hr />" + 
								"</div>" + 
								"</body>" + 
								"</html>";
					break;
				case "testWord":
					#region testWord html
					wikiPage = "<!DOCTYPE html>" + 
								"<html lang=\"en\" dir=\"ltr\" class=\"client-nojs\">" + 
								"<head>" + 
								"<meta charset=\"UTF-8\" /><title>grice - Wiktionary</title>" + 
								"<meta name=\"generator\" content=\"MediaWiki 1.22wmf5\" />" + 
								"<link rel=\"alternate\" type=\"application/x-wiki\" title=\"Edit\" href=\"/w/index.php?title=grice&amp;action=edit\" />" + 
								"<link rel=\"edit\" title=\"Edit\" href=\"/w/index.php?title=grice&amp;action=edit\" />" + 
								"<link rel=\"apple-touch-icon\" href=\"//bits.wikimedia.org/apple-touch/wiktionary/en.png\" />" + 
								"<link rel=\"shortcut icon\" href=\"//bits.wikimedia.org/favicon/wiktionary/en.ico\" />" + 
								"<link rel=\"search\" type=\"application/opensearchdescription+xml\" href=\"/w/opensearch_desc.php\" title=\"Wiktionary (en)\" />" + 
								"<link rel=\"EditURI\" type=\"application/rsd+xml\" href=\"//en.wiktionary.org/w/api.php?action=rsd\" />" + 
								"<link rel=\"copyright\" href=\"//creativecommons.org/licenses/by-sa/3.0/\" />" + 
								"<link rel=\"alternate\" type=\"application/atom+xml\" title=\"Wiktionary Atom feed\" href=\"/w/index.php?title=Special:RecentChanges&amp;feed=atom\" />" + 
								"<link rel=\"stylesheet\" href=\"//bits.wikimedia.org/en.wiktionary.org/load.php?debug=false&amp;lang=en&amp;modules=ext.rtlcite%2Cwikihiero%7Cmediawiki.legacy.commonPrint%2Cshared%7Cmw.PopUpMediaTransform%7Cskins.vector&amp;only=styles&amp;skin=vector&amp;*\" />" + 
								"<meta name=\"ResourceLoaderDynamicStyles\" content=\"\" />" + 
								"<link rel=\"stylesheet\" href=\"//bits.wikimedia.org/en.wiktionary.org/load.php?debug=false&amp;lang=en&amp;modules=site&amp;only=styles&amp;skin=vector&amp;*\" />" + 
								"<style>a:lang(ar),a:lang(ckb),a:lang(fa),a:lang(kk-arab),a:lang(mzn),a:lang(ps),a:lang(ur){text-decoration:none}" + 
								"/* cache key: enwiktionary:resourceloader:filter:minify-css:7:b993e01c31a73e3898d134787e33b4ac */</style>" + 
								"" + 
								"<script src=\"//bits.wikimedia.org/en.wiktionary.org/load.php?debug=false&amp;lang=en&amp;modules=startup&amp;only=scripts&amp;skin=vector&amp;*\"></script>" + 
								"<script>if(window.mw){" + 
								"mw.config.set({\"wgCanonicalNamespace\":\"\",\"wgCanonicalSpecialPageName\":false,\"wgNamespaceNumber\":0,\"wgPageName\":\"grice\",\"wgTitle\":\"grice\",\"wgCurRevisionId\":20582334,\"wgArticleId\":1480017,\"wgIsArticle\":true,\"wgAction\":\"view\",\"wgUserName\":null,\"wgUserGroups\":[\"*\"],\"wgCategories\":[\"English terms derived from Old Norse\",\"English nouns\",\"English countable nouns\",\"Scottish English\",\"Language code missing/context\",\"English terms with unknown etymologies\",\"term cleanup\",\"English back-formations\",\"English verbs\",\"British English\",\"en:Rail transportation\",\"English slang\",\"Context label called directly\",\"English terms with obsolete senses\",\"Requests for quotation\",\"Webster 1913\",\"Scots terms derived from Old Norse\",\"Scots nouns\"],\"wgBreakFrames\":false,\"wgPageContentLanguage\":\"en\",\"wgPageContentModel\":\"wikitext\",\"wgSeparatorTransformTable\":[\"\",\"\"],\"wgDigitTransformTable\":[\"\",\"\"],\"wgDefaultDateFormat\":\"dmy\",\"wgMonthNames\":[\"\",\"January\",\"February\",\"March\",\"April\",\"May\",\"June\",\"July\",\"August\",\"September\",\"October\",\"November\",\"December\"],\"wgMonthNamesShort\":[\"\",\"Jan\",\"Feb\",\"Mar\",\"Apr\",\"May\",\"Jun\",\"Jul\",\"Aug\",\"Sep\",\"Oct\",\"Nov\",\"Dec\"],\"wgRelevantPageName\":\"grice\",\"wgRestrictionEdit\":[],\"wgRestrictionMove\":[],\"wgVectorEnabledModules\":{\"collapsiblenav\":true,\"collapsibletabs\":true,\"expandablesearch\":false,\"footercleanup\":false,\"sectioneditlinks\":false,\"experiments\":true},\"wgWikiEditorEnabledModules\":{\"toolbar\":true,\"dialogs\":true,\"hidesig\":true,\"templateEditor\":false,\"templates\":false,\"preview\":false,\"previewDialog\":false,\"publish\":false,\"toc\":false},\"wgCategoryTreePageCategoryOptions\":\"{\"mode\":0,\"hideprefix\":20,\"showcount\":true,\"namespaces\":false}\",\"Geo\":{\"city\":\"\",\"country\":\"\"},\"wgNoticeProject\":\"wiktionary\"});" + 
								"}</script><script>if(window.mw){" + 
								"mw.loader.implement(\"user.options\",function(){mw.user.options.set({\"ccmeonemails\":0,\"cols\":80,\"date\":\"default\",\"diffonly\":0,\"disablemail\":0,\"disablesuggest\":0,\"editfont\":\"default\",\"editondblclick\":0,\"editsection\":1,\"editsectiononrightclick\":0,\"enotifminoredits\":0,\"enotifrevealaddr\":0,\"enotifusertalkpages\":1,\"enotifwatchlistpages\":0,\"extendwatchlist\":0,\"fancysig\":0,\"forceeditsummary\":0,\"gender\":\"unknown\",\"hideminor\":0,\"hidepatrolled\":0,\"imagesize\":2,\"justify\":0,\"math\":0,\"minordefault\":0,\"newpageshidepatrolled\":0,\"nocache\":0,\"noconvertlink\":0,\"norollbackdiff\":0,\"numberheadings\":0,\"previewonfirst\":0,\"previewontop\":1,\"rcdays\":7,\"rclimit\":50,\"rememberpassword\":0,\"rows\":25,\"searchlimit\":20,\"showhiddencats\":false,\"showjumplinks\":1,\"shownumberswatching\":1,\"showtoc\":1,\"showtoolbar\":1,\"skin\":\"vector\",\"stubthreshold\":0,\"thumbsize\":4,\"underline\":2,\"uselivepreview\":0,\"usenewrc\":0,\"watchcreations\":1,\"watchdefault\":0,\"watchdeletion\":0,\"watchlistdays\":3,\"watchlisthideanons\":0,\"watchlisthidebots\":0," + 
								"\"watchlisthideliu\":0,\"watchlisthideminor\":0,\"watchlisthideown\":0,\"watchlisthidepatrolled\":0,\"watchmoves\":0,\"wllimit\":250,\"useeditwarning\":1,\"vector-simplesearch\":1,\"vector-collapsiblenav\":1,\"usebetatoolbar\":1,\"usebetatoolbar-cgd\":1,\"lqtnotifytalk\":false,\"lqtdisplaydepth\":5,\"lqtdisplaycount\":25,\"lqtcustomsignatures\":true,\"lqt-watch-threads\":true,\"variant\":\"en\",\"language\":\"en\",\"searchNs0\":true,\"searchNs1\":false,\"searchNs2\":false,\"searchNs3\":false,\"searchNs4\":false,\"searchNs5\":false,\"searchNs6\":false,\"searchNs7\":false,\"searchNs8\":false,\"searchNs9\":false,\"searchNs10\":false,\"searchNs11\":false,\"searchNs12\":false,\"searchNs13\":false,\"searchNs14\":false,\"searchNs15\":false,\"searchNs90\":false,\"searchNs91\":false,\"searchNs92\":false,\"searchNs93\":false,\"searchNs100\":false,\"searchNs101\":false,\"searchNs102\":false,\"searchNs103\":false,\"searchNs104\":false,\"searchNs105\":false,\"searchNs106\":false,\"searchNs107\":false,\"searchNs108\":false,\"searchNs109\":false,\"searchNs110\":false,\"searchNs111\":false,\"searchNs114\"" + 
								":false,\"searchNs115\":false,\"searchNs116\":false,\"searchNs117\":false,\"searchNs828\":false,\"searchNs829\":false,\"gadget-PatrollingEnhancements\":1,\"webfontsEnable\":true});},{},{});mw.loader.implement(\"user.tokens\",function(){mw.user.tokens.set({\"editToken\":\"+\\\",\"patrolToken\":false,\"watchToken\":false});},{},{});" + 
								"/* cache key: enwiktionary:resourceloader:filter:minify-js:7:d7bf777c47625e314c6479a740492c45 */" + 
								"}</script>" + 
								"<script>if(window.mw){" + 
								"mw.loader.load([\"mediawiki.page.startup\",\"mediawiki.legacy.wikibits\",\"mediawiki.legacy.ajax\",\"ext.webfonts.init\",\"ext.centralNotice.bannerController\"]);" + 
								"}</script>" + 
								"<script src=\"//bits.wikimedia.org/geoiplookup\"></script><link rel=\"dns-prefetch\" href=\"//meta.wikimedia.org\" /><!--[if lt IE 7]><style type=\"text/css\">body{behavior:url(\"/w/static-1.22wmf5/skins/vector/csshover.min.htc\")}</style><![endif]--></head>" + 
								"<body class=\"mediawiki ltr sitedir-ltr ns-0 ns-subject page-grice skin-vector action-view vector-animateLayout\">" + 
								"		<div id=\"mw-page-base\" class=\"noprint\"></div>" + 
								"		<div id=\"mw-head-base\" class=\"noprint\"></div>" + 
								"		<div id=\"content\" class=\"mw-body\" role=\"main\">" + 
								"			<a id=\"top\"></a>" + 
								"			<div id=\"mw-js-message\" style=\"display:none;\"></div>" + 
								"						<div id=\"siteNotice\"><!-- CentralNotice --><script>document.write(\"\u003Cdiv id=\"localNotice\" lang=\"en\" dir=\"ltr\"\u003E\u003Cp\u003E\u003Cspan\u003E\u003C/span\u003E\n\u003C/p\u003E\u003C/div\u003E\");</script></div>" + 
								"						<h1 id=\"firstHeading\" class=\"firstHeading\" lang=\"en\"><span dir=\"auto\">grice</span></h1>" + 
								"			<div id=\"bodyContent\">" + 
								"								<div id=\"siteSub\">Definition from Wiktionary, the free dictionary</div>" + 
								"								<div id=\"contentSub\"></div>" + 
								"																<div id=\"jump-to-nav\" class=\"mw-jump\">" + 
								"					Jump to:					<a href=\"#mw-navigation\">navigation</a>, 					<a href=\"#p-search\">search</a>" + 
								"				</div>" + 
								"								<div id=\"mw-content-text\" lang=\"en\" dir=\"ltr\" class=\"mw-content-ltr\"><table id=\"toc\" class=\"toc\">" + 
								"<tr>" + 
								"<td>" + 
								"<div id=\"toctitle\">" + 
								"<h2>Contents</h2>" + 
								"</div>" + 
								"<ul>" + 
								"<li class=\"toclevel-1 tocsection-1\"><a href=\"#English\"><span class=\"tocnumber\">1</span> <span class=\"toctext\">English</span></a>" + 
								"<ul>" + 
								"<li class=\"toclevel-2 tocsection-2\"><a href=\"#Pronunciation\"><span class=\"tocnumber\">1.1</span> <span class=\"toctext\">Pronunciation</span></a></li>" + 
								"<li class=\"toclevel-2 tocsection-3\"><a href=\"#Etymology_1\"><span class=\"tocnumber\">1.2</span> <span class=\"toctext\">Etymology 1</span></a>" + 
								"<ul>" + 
								"<li class=\"toclevel-3 tocsection-4\"><a href=\"#Noun\"><span class=\"tocnumber\">1.2.1</span> <span class=\"toctext\">Noun</span></a></li>" + 
								"</ul>" + 
								"</li>" + 
								"<li class=\"toclevel-2 tocsection-5\"><a href=\"#Etymology_2\"><span class=\"tocnumber\">1.3</span> <span class=\"toctext\">Etymology 2</span></a>" + 
								"<ul>" + 
								"<li class=\"toclevel-3 tocsection-6\"><a href=\"#Verb\"><span class=\"tocnumber\">1.3.1</span> <span class=\"toctext\">Verb</span></a>" + 
								"<ul>" + 
								"<li class=\"toclevel-4 tocsection-7\"><a href=\"#Related_terms\"><span class=\"tocnumber\">1.3.1.1</span> <span class=\"toctext\">Related terms</span></a></li>" + 
								"</ul>" + 
								"</li>" + 
								"</ul>" + 
								"</li>" + 
								"<li class=\"toclevel-2 tocsection-8\"><a href=\"#Etymology_3\"><span class=\"tocnumber\">1.4</span> <span class=\"toctext\">Etymology 3</span></a>" + 
								"<ul>" + 
								"<li class=\"toclevel-3 tocsection-9\"><a href=\"#Noun_2\"><span class=\"tocnumber\">1.4.1</span> <span class=\"toctext\">Noun</span></a></li>" + 
								"</ul>" + 
								"</li>" + 
								"</ul>" + 
								"</li>" + 
								"<li class=\"toclevel-1 tocsection-10\"><a href=\"#Scots\"><span class=\"tocnumber\">2</span> <span class=\"toctext\">Scots</span></a>" + 
								"<ul>" + 
								"<li class=\"toclevel-2 tocsection-11\"><a href=\"#Etymology\"><span class=\"tocnumber\">2.1</span> <span class=\"toctext\">Etymology</span></a></li>" + 
								"<li class=\"toclevel-2 tocsection-12\"><a href=\"#Pronunciation_2\"><span class=\"tocnumber\">2.2</span> <span class=\"toctext\">Pronunciation</span></a></li>" + 
								"<li class=\"toclevel-2 tocsection-13\"><a href=\"#Noun_3\"><span class=\"tocnumber\">2.3</span> <span class=\"toctext\">Noun</span></a></li>" + 
								"</ul>" + 
								"</li>" + 
								"</ul>" + 
								"</td>" + 
								"</tr>" + 
								"</table>" + 
								"<h2><span class=\"mw-headline\" id=\"English\">English</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=1\" title=\"Edit section: English\">edit</a>]</span></h2>" + 
								"<h3><span class=\"mw-headline\" id=\"Pronunciation\">Pronunciation</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=2\" title=\"Edit section: Pronunciation\">edit</a>]</span></h3>" + 
								"<ul>" + 
								"<li><span class=\"ib-brac\"><span class=\"qualifier-brac\">(</span></span><span class=\"ib-content\"><span class=\"qualifier-content\"><a href=\"//en.wikipedia.org/wiki/British_English\" class=\"extiw\" title=\"w:British English\">UK</a></span></span><span class=\"ib-brac\"><span class=\"qualifier-brac\">)</span></span> <a href=\"/wiki/Appendix:English_pronunciation\" title=\"Appendix:English pronunciation\">IPA</a>: <span class=\"IPA\" lang=\"\" xml:lang=\"\">/g???s/</span></li>" + 
								"</ul>" + 
								"<h3><span class=\"mw-headline\" id=\"Etymology_1\">Etymology 1</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=3\" title=\"Edit section: Etymology 1\">edit</a>]</span></h3>" + 
								"<p>From <span class=\"etyl\">Old Norse</span> <span class=\"Latn mention-Latn\" lang=\"non\" xml:lang=\"non\"><a href=\"/w/index.php?title=gr%C3%ADss&amp;action=edit&amp;redlink=1\" class=\"new\" title=\"gríss (page does not exist)\">gríss</a></span>.</p>" + 
								"<h4><span class=\"mw-headline\" id=\"Noun\">Noun</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=4\" title=\"Edit section: Noun\">edit</a>]</span></h4>" + 
								"<p><span class=\"infl-inline\"><strong class=\"headword\">grice</strong> (<i>plural</i>&#160;<span class=\"form-of plural-form-of lang-en\"><strong class=\"selflink\">grice</strong> or <i>rare</i>, <b><a href=\"/wiki/grices\" title=\"grices\">grices</a></b></span>)</span></p>" + 
								"<ol>" + 
								"<li><span class=\"ib-brac qualifier-brac\">(</span><span class=\"ib-content qualifier-content\">now <a href=\"/wiki/Scottish_English\" title=\"Scottish English\">Scotland</a></span><span class=\"ib-brac qualifier-brac\">)</span> A <a href=\"/wiki/pig\" title=\"pig\">pig</a>, especially a young <a href=\"/wiki/pig\" title=\"pig\">pig</a>, or its meat; sometimes specifically, a breed of wild <a href=\"/wiki/pig\" title=\"pig\">pig</a> or <a href=\"/wiki/boar\" title=\"boar\">boar</a> native to Scotland, now <a href=\"/wiki/extinct\" title=\"extinct\">extinct</a>." + 
								"<ul>" + 
								"<li><b>1728</b>, Robert Lindsay, <i>The history of Scotland, from 21 February, 1436. to March, 1565: in which are contained accounts of many remarkable passages altogether differing from our other historians, and many facts are related, either concealed by some, or omitted by others</i>, publ. Mr. Baskett and Company, <a rel=\"nofollow\" class=\"external text\" href=\"http://books.google.com/books?id=AKUvAAAAMAAJ&amp;pg=PA146&amp;vq=grice\">pg.146</a>:" + 
								"<dl>" + 
								"<dd>Further, there was of meats wheat bread, main-bread and ginge-bread with fleshes, beef, mutton, lamb, veal, venison, goose, <b>grice</b>, capon, coney, cran, swan, partridge, plover, duck, drake, brissel-cock and pawnies, black-cock and muir-fowl, cappercaillies;</dd>" + 
								"</dl>" + 
								"</li>" + 
								"<li><b>1789</b>, William Thomson, <i>Mammuth: or, human nature displayed on a grand scale: in a tour with the tinkers, into the inland parts of Africa. By the man in the moon. In two volumes.</i> publ. G. and T. Wilkie, <a rel=\"nofollow\" class=\"external text\" href=\"http://books.google.com/books?id=EsENAAAAQAAJ&amp;pg=PA105&amp;dq=grice\">pg.105</a>:" + 
								"<dl>" + 
								"<dd>Through a door to one of the galleries, left half open on purpose I was attracted to a dainty hot supper, consisting of stewed mushrooms and the fat paps and ears of very young pigs, or, as they call them, <b>grice</b>.</dd>" + 
								"</dl>" + 
								"</li>" + 
								"<li><b>2006</b>, \"Extinct island pig spotted again,\" <i>BBC News</i>, 17 November 2006, <a rel=\"nofollow\" class=\"external autonumber\" href=\"http://news.bbc.co.uk/2/hi/uk_news/scotland/north_east/6155172.stm\">[1]</a>:" + 
								"<dl>" + 
								"<dd>A model of the <b>grice</b> - which was the size of a large dog and had tusks - has been created after work by researchers and a taxidermist.</dd>" + 
								"</dl>" + 
								"</li>" + 
								"</ul>" + 
								"</li>" + 
								"</ol>" + 
								"<h3><span class=\"mw-headline\" id=\"Etymology_2\">Etymology 2</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=5\" title=\"Edit section: Etymology 2\">edit</a>]</span></h3>" + 
								"<p>Unknown, possibly from Richard Grice, the first champion <a href=\"/wiki/trainspotter\" title=\"trainspotter\">trainspotter</a><a rel=\"nofollow\" class=\"external autonumber\" href=\"http://books.google.co.uk/books?id=rdU1xtIWJz0C&amp;q=grice+trainspotter&amp;dq=grice+trainspotter&amp;hl=en&amp;sa=X&amp;ei=afhsT5ChFe-R0QWF8K3HBg&amp;redir_esc=y\">[2]</a>, alternatively perhaps a humorous representation of an upper-class pronunciation of <span class=\"missing-language\"><i class=\"None mention-None\" lang=\"und\" xml:lang=\"und\"><a href=\"/wiki/grouser\" title=\"grouser\">grouser</a></i></span>&#160;<span class=\"mention-gloss-paren\">(</span><span class=\"mention-gloss-double-quote\">“</span><span class=\"mention-gloss\">grouse-shooter</span><span class=\"mention-gloss-double-quote\">”</span><span class=\"mention-gloss-paren\">)</span><a rel=\"nofollow\" class=\"external autonumber\" href=\"http://oxforddictionaries.com/definition/gricer\">[3]</a>. In either case the derivation could be direct or a <a href=\"/wiki/Appendix:Glossary#back-formation\" title=\"Appendix:Glossary\">back-formation</a> from <span class=\"Latn mention-Latn\" lang=\"en\" xml:lang=\"en\"><a href=\"/wiki/gricer#English\" title=\"gricer\">gricer</a></span>.</p>" + 
								"<h4><span class=\"mw-headline\" id=\"Verb\">Verb</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=6\" title=\"Edit section: Verb\">edit</a>]</span></h4>" + 
								"<p><span class=\"infl-inline\"><strong class=\"Latn headword\" lang=\"en\" xml:lang=\"en\">grice</strong> (<i>third-person singular simple present</i> <span class=\"form-of third-person-singular-form-of\"><b><span class=\"Latn\" lang=\"en\" xml:lang=\"en\"><a href=\"/wiki/grices#English\" title=\"grices\">grices</a></span></b></span>, <i>present participle</i> <span class=\"form-of present-participle-form-of\"><b><span class=\"Latn\" lang=\"en\" xml:lang=\"en\"><a href=\"/wiki/gricing#English\" title=\"gricing\">gricing</a></span></b></span>, <i>simple past and past participle</i> <span class=\"form-of simple-past-and-participle-form-of\"><b><span class=\"Latn\" lang=\"en\" xml:lang=\"en\"><a href=\"/wiki/griced#English\" title=\"griced\">griced</a></span></b></span>)</span></p>" + 
								"<ol>" + 
								"<li><span class=\"ib-brac qualifier-brac\">(</span><span class=\"ib-content qualifier-content\"><a href=\"/wiki/British_English\" title=\"British English\">UK</a><span class=\"ib-comma qualifier-comma\">,</span> rail transport<span class=\"ib-comma\"><span class=\"qualifier-comma\">,</span></span> <a href=\"/wiki/Appendix:Glossary#slang\" title=\"Appendix:Glossary\">slang</a></span><span class=\"ib-brac qualifier-brac\">)</span> to act as a <a href=\"/wiki/trainspotter\" title=\"trainspotter\">trainspotter</a>; to partake in the activity or hobby of <a href=\"/wiki/trainspotting\" title=\"trainspotting\">trainspotting</a>." + 
								"<ul>" + 
								"<li><span class=\"citation-whole\"><span class=\"cited-source\"><b>1999</b> March 29,   Polson, Tony, “<a rel=\"nofollow\" class=\"external text\" href=\"http://groups.google.com/group/uk.railway/msg/226e540c55c506ac\">Re: Do all UK rail staff get free unlimited Eurostar travel?</a>”, <tt><cite>uk.railway</cite></tt>, <a href=\"//en.wikipedia.org/wiki/Usenet\" class=\"extiw\" title=\"w:Usenet\">Usenet</a>:</span></span>" + 
								"<dl>" + 
								"<dd><span class=\"cited-passage\">Many people joined the railways because the 'carrot' of a staff pass was a considerable attraction, whether for family travel or to <b>grice</b> at extremely low cost.</span></dd>" + 
								"</dl>" + 
								"</li>" + 
								"<li><span class=\"citation-whole\"><span class=\"cited-source\"><cite style=\"font-style:normal\"><b>2005</b>, <cite>The Railway Magazine</cite>, volume 151, number 1252, IPC Business Press, <a rel=\"nofollow\" class=\"external text\" href=\"http://books.google.co.uk/books?id=ijlWAAAAMAAJ\">page 55</a></cite>:?</span></span>" + 
								"<dl>" + 
								"<dd><span class=\"cited-passage\">We can also roganise photo charters, large group footplate courses and <b>gricing</b> holidays [...]</span></dd>" + 
								"</dl>" + 
								"</li>" + 
								"<li><span class=\"citation-whole\"><span class=\"cited-source\"><span class=\"book\"><b>2010</b>,  Adam Jacot de Boinod,  “Gricer's Daughter”, in  <cite>I Never Knew There Was a Word For It</cite><sup><a rel=\"nofollow\" class=\"external autonumber\" href=\"http://books.google.co.uk/books?id=ItYq7wYG634C&amp;dq\">[4]</a></sup>, <a href=\"/wiki/Special:BookSources/9780141028392\" class=\"internal mw-magiclink-isbn\">ISBN 9780141028392</a></span>:</span></span>" + 
								"<dl>" + 
								"<dd><span class=\"cited-passage\">Trainspotters may be mocked by the outside world, but they don't take criticism lying down: the language of <b>gricing</b> is notable for its acidic descriptions of outsiders.</span></dd>" + 
								"</dl>" + 
								"</li>" + 
								"</ul>" + 
								"</li>" + 
								"</ol>" + 
								"<h5><span class=\"mw-headline\" id=\"Related_terms\">Related terms</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=7\" title=\"Edit section: Related terms\">edit</a>]</span></h5>" + 
								"<ul>" + 
								"<li><a href=\"/wiki/gricer\" title=\"gricer\">gricer</a></li>" + 
								"</ul>" + 
								"<h3><span class=\"mw-headline\" id=\"Etymology_3\">Etymology 3</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=8\" title=\"Edit section: Etymology 3\">edit</a>]</span></h3>" + 
								"<h4><span class=\"mw-headline\" id=\"Noun_2\">Noun</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=9\" title=\"Edit section: Noun\">edit</a>]</span></h4>" + 
								"<p><span class=\"infl-inline\"><strong class=\"headword\">grice</strong> (<i>plural</i>&#160;<span class=\"form-of plural-form-of lang-en\"><b><span class=\"Latn\" lang=\"en\" xml:lang=\"en\"><a href=\"/wiki/grices#English\" title=\"grices\">grices</a></span></b></span>)</span></p>" + 
								"<ol>" + 
								"<li><span class=\"ib-brac qualifier-brac\">(</span><span class=\"ib-content qualifier-content\"><a href=\"/wiki/Appendix:Glossary#obsolete\" title=\"Appendix:Glossary\">obsolete</a></span><span class=\"ib-brac qualifier-brac\">)</span> A <a href=\"/wiki/gree\" title=\"gree\">gree</a>; a <a href=\"/wiki/step\" title=\"step\">step</a>." + 
								"<dl>" + 
								"<dd><span style=\"color: #777777;\">(Can we <a href=\"/wiki/Category:Requests_for_quotation\" title=\"Category:Requests for quotation\">find and add</a> a quotation of Ben Jonson to this entry?)</span></dd>" + 
								"</dl>" + 
								"</li>" + 
								"</ol>" + 
								"<div style=\"background-color: #f0f0f0;\">" + 
								"<p><i>Part or all of this entry has been imported from the 1913 edition of <a href=\"/wiki/Wiktionary:Webster%27s_Dictionary,_1913\" title=\"Wiktionary:Webster's Dictionary, 1913\">Webster’s Dictionary</a>, which is now free of copyright and hence in the public domain. The imported definitions may be significantly out of date, and any more recent senses may be completely missing.</i></p>" + 
								"</div>" + 
								"<hr />" + 
								"<h2><span class=\"mw-headline\" id=\"Scots\">Scots</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=10\" title=\"Edit section: Scots\">edit</a>]</span></h2>" + 
								"<h3><span class=\"mw-headline\" id=\"Etymology\">Etymology</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=11\" title=\"Edit section: Etymology\">edit</a>]</span></h3>" + 
								"<p>From <span class=\"etyl\">Old Norse</span> <span class=\"Latn mention-Latn\" lang=\"non\" xml:lang=\"non\"><a href=\"/w/index.php?title=gr%C3%ADss&amp;action=edit&amp;redlink=1\" class=\"new\" title=\"gríss (page does not exist)\">gríss</a></span>.</p>" + 
								"<h3><span class=\"mw-headline\" id=\"Pronunciation_2\">Pronunciation</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=12\" title=\"Edit section: Pronunciation\">edit</a>]</span></h3>" + 
								"<ul>" + 
								"<li><span style=\"cursor:help\" title=\"Scots\"><a href=\"//en.wikipedia.org/wiki/Special:Search/Scots_phonology\" class=\"extiw\" title=\"wikipedia:Special:Search/Scots phonology\">IPA</a></span>: <span class=\"IPA\" lang=\"\" xml:lang=\"\">/gr?is/</span></li>" + 
								"</ul>" + 
								"<p><br /></p>" + 
								"<h3><span class=\"mw-headline\" id=\"Noun_3\">Noun</span><span class=\"mw-editsection\">[<a href=\"/w/index.php?title=grice&amp;action=edit&amp;section=13\" title=\"Edit section: Noun\">edit</a>]</span></h3>" + 
								"<p><span class=\"infl-inline\"><b>grice</b> (<i>plural</i> <span class=\"form-of plural-form-of lang-sco\"><b><span class=\"Latn\" lang=\"sco\" xml:lang=\"sco\"><a href=\"/wiki/grices#Scots\" title=\"grices\">grices</a></span></b></span>)</span></p>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/pig\" title=\"pig\">pig</a>, <a href=\"/wiki/piglet\" title=\"piglet\">piglet</a>" + 
								"<ul>" + 
								"<li><b>1817</b>, <a href=\"//en.wikipedia.org/wiki/Walter_Scott\" class=\"extiw\" title=\"wikipedia:Walter Scott\">Walter Scott</a>, <i>Rob Roy</i>:" + 
								"<dl>" + 
								"<dd>‘Sae, an it come to the warst, I'se een lay the head o' the sow to the tail o' the <b>grice</b>.’</dd>" + 
								"</dl>" + 
								"</li>" + 
								"</ul>" + 
								"</li>" + 
								"</ol>" + 
								"" + 
								"" + 
								"<!-- " + 
								"NewPP limit report" + 
								"Preprocessor visited node count: 3347/1000000" + 
								"Preprocessor generated node count: 24501/1500000" + 
								"Post-expand include size: 25405/2048000 bytes" + 
								"Template argument size: 6222/2048000 bytes" + 
								"Highest expansion depth: 19/40" + 
								"Expensive parser function count: 9/500" + 
								"Lua time usage: 0.248s" + 
								"Lua memory usage: 9.32 MB" + 
								"-->" + 
								"" + 
								"<!-- Saved in parser cache with key enwiktionary:pcache:idhash:1480017-0!*!0!!en!*!* and timestamp 20130604200129 -->" + 
								"</div>								<div class=\"printfooter\">" + 
								"				Retrieved from \"<a href=\"http://en.wiktionary.org/w/index.php?title=grice&amp;oldid=20582334\">http://en.wiktionary.org/w/index.php?title=grice&amp;oldid=20582334</a>\"				</div>" + 
								"												<div id='catlinks' class='catlinks'><div id=\"mw-normal-catlinks\" class=\"mw-normal-catlinks\"><a href=\"/wiki/Special:Categories\" title=\"Special:Categories\">Categories</a>: <ul><li><a href=\"/wiki/Category:English_terms_derived_from_Old_Norse\" title=\"Category:English terms derived from Old Norse\">English terms derived from Old Norse</a></li><li><a href=\"/wiki/Category:English_nouns\" title=\"Category:English nouns\">English nouns</a></li><li><a href=\"/wiki/Category:English_countable_nouns\" title=\"Category:English countable nouns\">English countable nouns</a></li><li><a href=\"/wiki/Category:Scottish_English\" title=\"Category:Scottish English\">Scottish English</a></li><li><a href=\"/wiki/Category:English_terms_with_unknown_etymologies\" title=\"Category:English terms with unknown etymologies\">English terms with unknown etymologies</a></li><li><a href=\"/wiki/Category:English_back-formations\" title=\"Category:English back-formations\">English back-formations</a></li><li><a href=\"/wiki/Category:English_verbs\" title=\"Category:English verbs\">English verbs</a></li><li><a href=\"/wiki/Category:British_English\" title=\"Category:British English\">British English</a></li><li><a href=\"/wiki/Category:en:Rail_transportation\" title=\"Category:en:Rail transportation\">en:Rail transportation</a></li><li><a href=\"/wiki/Category:English_slang\" title=\"Category:English slang\">English slang</a></li><li><a href=\"/wiki/Category:English_terms_with_obsolete_senses\" title=\"Category:English terms with obsolete senses\">English terms with obsolete senses</a></li><li><a href=\"/wiki/Category:Webster_1913\" title=\"Category:Webster 1913\">Webster 1913</a></li><li><a href=\"/wiki/Category:Scots_terms_derived_from_Old_Norse\" title=\"Category:Scots terms derived from Old Norse\">Scots terms derived from Old Norse</a></li><li><a href=\"/wiki/Category:Scots_nouns\" title=\"Category:Scots nouns\">Scots nouns</a></li></ul></div><div id=\"mw-hidden-catlinks\" class=\"mw-hidden-catlinks mw-hidden-cats-hidden\">Hidden categories: <ul><li><a href=\"/wiki/Category:Language_code_missing/context\" title=\"Category:Language code missing/context\">Language code missing/context</a></li><li><a href=\"/wiki/Category:term_cleanup\" title=\"Category:term cleanup\">term cleanup</a></li><li><a href=\"/wiki/Category:Context_label_called_directly\" title=\"Category:Context label called directly\">Context label called directly</a></li><li><a href=\"/wiki/Category:Requests_for_quotation\" title=\"Category:Requests for quotation\">Requests for quotation</a></li></ul></div></div>												<div class=\"visualClear\"></div>" + 
								"							</div>" + 
								"		</div>" + 
								"		<div id=\"mw-navigation\">" + 
								"			<h2>Navigation menu</h2>" + 
								"			<div id=\"mw-head\">" + 
								"				<div id=\"p-personal\" role=\"navigation\" class=\"\">" + 
								"	<h3>Personal tools</h3>" + 
								"	<ul>" + 
								"<li id=\"pt-createaccount\"><a href=\"/w/index.php?title=Special:UserLogin&amp;returnto=grice&amp;type=signup\">Create account</a></li><li id=\"pt-login\"><a href=\"/w/index.php?title=Special:UserLogin&amp;returnto=grice\" title=\"You are encouraged to log in; however, it is not mandatory [o]\" accesskey=\"o\">Log in</a></li>	</ul>" + 
								"</div>" + 
								"				<div id=\"left-navigation\">" + 
								"					<div id=\"p-namespaces\" role=\"navigation\" class=\"vectorTabs\">" + 
								"	<h3>Namespaces</h3>" + 
								"	<ul>" + 
								"					<li  id=\"ca-nstab-main\" class=\"selected\"><span><a href=\"/wiki/grice\"  title=\"View the content page [c]\" accesskey=\"c\">Entry</a></span></li>" + 
								"					<li  id=\"ca-talk\" class=\"new\"><span><a href=\"/w/index.php?title=Talk:grice&amp;action=edit&amp;redlink=1\"  title=\"Discussion about the content page [t]\" accesskey=\"t\">Discussion</a></span></li>" + 
								"			</ul>" + 
								"</div>" + 
								"<div id=\"p-variants\" role=\"navigation\" class=\"vectorMenu emptyPortlet\">" + 
								"	<h3 id=\"mw-vector-current-variant\">" + 
								"		</h3>" + 
								"	<h3><span>Variants</span><a href=\"#\"></a></h3>" + 
								"	<div class=\"menu\">" + 
								"		<ul>" + 
								"					</ul>" + 
								"	</div>" + 
								"</div>" + 
								"				</div>" + 
								"				<div id=\"right-navigation\">" + 
								"					<div id=\"p-views\" role=\"navigation\" class=\"vectorTabs\">" + 
								"	<h3>Views</h3>" + 
								"	<ul>" + 
								"					<li id=\"ca-view\" class=\"selected\"><span><a href=\"/wiki/grice\" >Read</a></span></li>" + 
								"					<li id=\"ca-edit\"><span><a href=\"/w/index.php?title=grice&amp;action=edit\"  title=\"You can edit this page. Please use the preview button before saving [e]\" accesskey=\"e\">Edit</a></span></li>" + 
								"					<li id=\"ca-history\" class=\"collapsible\"><span><a href=\"/w/index.php?title=grice&amp;action=history\"  title=\"Past revisions of this page [h]\" accesskey=\"h\">History</a></span></li>" + 
								"			</ul>" + 
								"</div>" + 
								"<div id=\"p-cactions\" role=\"navigation\" class=\"vectorMenu emptyPortlet\">" + 
								"	<h3><span>Actions</span><a href=\"#\"></a></h3>" + 
								"	<div class=\"menu\">" + 
								"		<ul>" + 
								"					</ul>" + 
								"	</div>" + 
								"</div>" + 
								"<div id=\"p-search\" role=\"search\">" + 
								"	<h3><label for=\"searchInput\">Search</label></h3>" + 
								"	<form action=\"/w/index.php\" id=\"searchform\">" + 
								"				<div id=\"simpleSearch\">" + 
								"						<input name=\"search\" placeholder=\"Search\" title=\"Search Wiktionary [f]\" accesskey=\"f\" id=\"searchInput\" />						<button type=\"submit\" name=\"button\" title=\"Search the pages for this text\" id=\"searchButton\"><img src=\"//bits.wikimedia.org/static-1.22wmf5/skins/vector/images/search-ltr.png?303-4\" alt=\"Search\" width=\"12\" height=\"13\" /></button>								<input type='hidden' name=\"title\" value=\"Special:Search\"/>" + 
								"		</div>" + 
								"	</form>" + 
								"</div>" + 
								"				</div>" + 
								"			</div>" + 
								"			<div id=\"mw-panel\">" + 
								"					<div id=\"p-logo\" role=\"banner\"><a style=\"background-image: url(//upload.wikimedia.org/wiktionary/en/b/bc/Wiki.png);\" href=\"/wiki/Wiktionary:Main_Page\"  title=\"Visit the main page\"></a></div>" + 
								"				<div class=\"portal\" role=\"navigation\" id='p-navigation'>" + 
								"	<h3>Navigation</h3>" + 
								"	<div class=\"body\">" + 
								"		<ul>" + 
								"			<li id=\"n-mainpage-text\"><a href=\"/wiki/Wiktionary:Main_Page\">Main Page</a></li>" + 
								"			<li id=\"n-portal\"><a href=\"/wiki/Wiktionary:Community_portal\" title=\"About the project, what you can do, where to find things\">Community portal</a></li>" + 
								"			<li id=\"n-wiktprefs\"><a href=\"/wiki/Wiktionary:Per-browser_preferences\">Preferences</a></li>" + 
								"			<li id=\"n-requestedarticles\"><a href=\"/wiki/Wiktionary:Requested_entries\">Requested entries</a></li>" + 
								"			<li id=\"n-recentchanges\"><a href=\"/wiki/Special:RecentChanges\" title=\"A list of recent changes in the wiki [r]\" accesskey=\"r\">Recent changes</a></li>" + 
								"			<li id=\"n-randompage\"><a href=\"/wiki/Special:Random\" title=\"Load a random page [x]\" accesskey=\"x\">Random entry</a></li>" + 
								"			<li id=\"n-randompagebylanguage\"><a href=\"/wiki/Wiktionary:Random_page\">(by language)</a></li>" + 
								"			<li id=\"n-help\"><a href=\"/wiki/Help:Contents\" title=\"The place to find out\">Help</a></li>" + 
								"			<li id=\"n-sitesupport\"><a href=\"//donate.wikimedia.org/wiki/Special:FundraiserRedirector?utm_source=donate&amp;utm_medium=sidebar&amp;utm_campaign=C13_en.wiktionary.org&amp;uselang=en\" title=\"Support us\">Donations</a></li>" + 
								"			<li id=\"n-contact\"><a href=\"/wiki/Wiktionary:Contact_us\">Contact us</a></li>" + 
								"		</ul>" + 
								"	</div>" + 
								"</div>" + 
								"<div class=\"portal\" role=\"navigation\" id='p-tb'>" + 
								"	<h3>Toolbox</h3>" + 
								"	<div class=\"body\">" + 
								"		<ul>" + 
								"			<li id=\"t-whatlinkshere\"><a href=\"/wiki/Special:WhatLinksHere/grice\" title=\"A list of all wiki pages that link here [j]\" accesskey=\"j\">What links here</a></li>" + 
								"			<li id=\"t-recentchangeslinked\"><a href=\"/wiki/Special:RecentChangesLinked/grice\" title=\"Recent changes in pages linked from this page [k]\" accesskey=\"k\">Related changes</a></li>" + 
								"			<li id=\"t-upload\"><a href=\"//commons.wikimedia.org/wiki/Special:Upload\" title=\"Upload files [u]\" accesskey=\"u\">Upload file</a></li>" + 
								"			<li id=\"t-specialpages\"><a href=\"/wiki/Special:SpecialPages\" title=\"A list of all special pages [q]\" accesskey=\"q\">Special pages</a></li>" + 
								"			<li id=\"t-print\"><a href=\"/w/index.php?title=grice&amp;printable=yes\" rel=\"alternate\" title=\"Printable version of this page [p]\" accesskey=\"p\">Printable version</a></li>" + 
								"			<li id=\"t-permalink\"><a href=\"/w/index.php?title=grice&amp;oldid=20582334\" title=\"Permanent link to this revision of the page\">Permanent link</a></li>" + 
								"			<li id=\"t-info\"><a href=\"/w/index.php?title=grice&amp;action=info\">Page information</a></li>" + 
								"<li id=\"t-cite\"><a href=\"/w/index.php?title=Special:Cite&amp;page=grice&amp;id=20582334\" title=\"Information on how to cite this page\">Cite this page</a></li>		</ul>" + 
								"	</div>" + 
								"</div>" + 
								"<div class=\"portal\" role=\"navigation\" id='p-lang'>" + 
								"	<h3>In other languages</h3>" + 
								"	<div class=\"body\">" + 
								"		<ul>" + 
								"			<li class=\"interwiki-it\"><a href=\"//it.wiktionary.org/wiki/grice\" title=\"grice\" lang=\"it\" hreflang=\"it\">Italiano</a></li>" + 
								"			<li class=\"interwiki-ku\"><a href=\"//ku.wiktionary.org/wiki/grice\" title=\"grice\" lang=\"ku\" hreflang=\"ku\">Kurdî</a></li>" + 
								"			<li class=\"interwiki-ml\"><a href=\"//ml.wiktionary.org/wiki/grice\" title=\"grice\" lang=\"ml\" hreflang=\"ml\">??????</a></li>" + 
								"		</ul>" + 
								"	</div>" + 
								"</div>" + 
								"			</div>" + 
								"		</div>" + 
								"		<div id=\"footer\" role=\"contentinfo\">" + 
								"							<ul id=\"footer-info\">" + 
								"											<li id=\"footer-info-lastmod\"> This page was last modified on 20 May 2013, at 18:56.</li>" + 
								"											<li id=\"footer-info-copyright\">Text is available under the <a href=\"//creativecommons.org/licenses/by-sa/3.0/\">Creative Commons Attribution/Share-Alike License</a>; additional terms may apply.  By using this site, you agree to the <a href=\"//wikimediafoundation.org/wiki/Terms_of_Use\">Terms of Use</a> and <a href=\"//wikimediafoundation.org/wiki/Privacy_policy\">Privacy Policy.</a></li>" + 
								"									</ul>" + 
								"							<ul id=\"footer-places\">" + 
								"											<li id=\"footer-places-privacy\"><a href=\"//wikimediafoundation.org/wiki/Privacy_policy\" title=\"wikimedia:Privacy policy\">Privacy policy</a></li>" + 
								"											<li id=\"footer-places-about\"><a href=\"/wiki/Wiktionary:About\" title=\"Wiktionary:About\">About Wiktionary</a></li>" + 
								"											<li id=\"footer-places-disclaimer\"><a href=\"/wiki/Wiktionary:General_disclaimer\" title=\"Wiktionary:General disclaimer\">Disclaimers</a></li>" + 
								"											<li id=\"footer-places-mobileview\"><a href=\"http://en.m.wiktionary.org/wiki/grice\" class=\"noprint stopMobileRedirectToggle\">Mobile view</a></li>" + 
								"									</ul>" + 
								"										<ul id=\"footer-icons\" class=\"noprint\">" + 
								"					<li id=\"footer-copyrightico\">" + 
								"						<a href=\"//wikimediafoundation.org/\"><img src=\"//bits.wikimedia.org/images/wikimedia-button.png\" width=\"88\" height=\"31\" alt=\"Wikimedia Foundation\"/></a>" + 
								"					</li>" + 
								"					<li id=\"footer-poweredbyico\">" + 
								"						<a href=\"//www.mediawiki.org/\"><img src=\"//bits.wikimedia.org/static-1.22wmf5/skins/common/images/poweredby_mediawiki_88x31.png\" alt=\"Powered by MediaWiki\" width=\"88\" height=\"31\" /></a>" + 
								"					</li>" + 
								"				</ul>" + 
								"						<div style=\"clear:both\"></div>" + 
								"		</div>" + 
								"		<script>/*<![CDATA[*/window.jQuery && jQuery.ready();/*]]>*/</script><script>if(window.mw){" + 
								"mw.loader.state({\"site\":\"loading\",\"user\":\"ready\",\"user.groups\":\"ready\"});" + 
								"}</script>" + 
								"<script>if(window.mw){" + 
								"mw.loader.load([\"mobile.desktop\",\"mediawiki.action.view.postEdit\",\"mediawiki.user\",\"mediawiki.hidpi\",\"mediawiki.page.ready\",\"mediawiki.searchSuggest\",\"mw.MwEmbedSupport.style\",\"ext.vector.collapsibleNav\",\"ext.vector.collapsibleTabs\",\"ext.navigationTiming\",\"mw.PopUpMediaTransform\",\"skins.vector.js\"],null,true);" + 
								"}</script>" + 
								"<script src=\"//bits.wikimedia.org/en.wiktionary.org/load.php?debug=false&amp;lang=en&amp;modules=site&amp;only=scripts&amp;skin=vector&amp;*\"></script>" + 
								"<!-- Served by mw1166 in 0.141 secs. -->" + 
								"	</body>" + 
								"</html>";
					#endregion
					break;
				case "testPage":
					#region testPage html
					wikiPage =  "<!DOCTYPE html>" + 
								"<html lang=\"en\" dir=\"ltr\" class=\"client-nojs\">" + 
								"<head>" + 
								"<title>Index:English/x - Wiktionary</title>" + 
								"<meta charset=\"UTF-8\" />" + 
								"<meta name=\"generator\" content=\"MediaWiki 1.22wmf4\" />" + 
								"<link rel=\"alternate\" type=\"application/x-wiki\" title=\"Edit\" href=\"/w/index.php?title=Index:English/x&amp;action=edit\" />" + 
								"<link rel=\"edit\" title=\"Edit\" href=\"/w/index.php?title=Index:English/x&amp;action=edit\" />" + 
								"<link rel=\"apple-touch-icon\" href=\"//bits.wikimedia.org/apple-touch/wiktionary/en.png\" />" + 
								"<link rel=\"shortcut icon\" href=\"//bits.wikimedia.org/favicon/wiktionary/en.ico\" />" + 
								"<link rel=\"search\" type=\"application/opensearchdescription+xml\" href=\"/w/opensearch_desc.php\" title=\"Wiktionary (en)\" />" + 
								"<link rel=\"EditURI\" type=\"application/rsd+xml\" href=\"//en.wiktionary.org/w/api.php?action=rsd\" />" + 
								"<link rel=\"copyright\" href=\"//creativecommons.org/licenses/by-sa/3.0/\" />" + 
								"<link rel=\"alternate\" type=\"application/atom+xml\" title=\"Wiktionary Atom feed\" href=\"/w/index.php?title=Special:RecentChanges&amp;feed=atom\" />" + 
								"<link rel=\"stylesheet\" href=\"//bits.wikimedia.org/en.wiktionary.org/load.php?debug=false&amp;lang=en&amp;modules=ext.wikihiero%7Cmediawiki.legacy.commonPrint%2Cshared%7Cmw.PopUpMediaTransform%7Cskins.vector&amp;only=styles&amp;skin=vector&amp;*\" />" + 
								"<meta name=\"ResourceLoaderDynamicStyles\" content=\"\" />" + 
								"<link rel=\"stylesheet\" href=\"//bits.wikimedia.org/en.wiktionary.org/load.php?debug=false&amp;lang=en&amp;modules=site&amp;only=styles&amp;skin=vector&amp;*\" />" + 
								"<style>a:lang(ar),a:lang(ckb),a:lang(fa),a:lang(kk-arab),a:lang(mzn),a:lang(ps),a:lang(ur){text-decoration:none}" + 
								"/* cache key: enwiktionary:resourceloader:filter:minify-css:7:b993e01c31a73e3898d134787e33b4ac */</style>" + 
								"" + 
								"<script src=\"//bits.wikimedia.org/en.wiktionary.org/load.php?debug=false&amp;lang=en&amp;modules=startup&amp;only=scripts&amp;skin=vector&amp;*\"></script>" + 
								"<script>if(window.mw){" + 
								"mw.config.set({\"wgCanonicalNamespace\":\"Index\",\"wgCanonicalSpecialPageName\":false,\"wgNamespaceNumber\":104,\"wgPageName\":\"Index:English/x\",\"wgTitle\":\"English/x\",\"wgCurRevisionId\":16756295,\"wgArticleId\":2836,\"wgIsArticle\":true,\"wgAction\":\"view\",\"wgUserName\":null,\"wgUserGroups\":[\"*\"],\"wgCategories\":[],\"wgBreakFrames\":false,\"wgPageContentLanguage\":\"en\",\"wgPageContentModel\":\"wikitext\",\"wgSeparatorTransformTable\":[\"\",\"\"],\"wgDigitTransformTable\":[\"\",\"\"],\"wgDefaultDateFormat\":\"dmy\",\"wgMonthNames\":[\"\",\"January\",\"February\",\"March\",\"April\",\"May\",\"June\",\"July\",\"August\",\"September\",\"October\",\"November\",\"December\"],\"wgMonthNamesShort\":[\"\",\"Jan\",\"Feb\",\"Mar\",\"Apr\",\"May\",\"Jun\",\"Jul\",\"Aug\",\"Sep\",\"Oct\",\"Nov\",\"Dec\"],\"wgRelevantPageName\":\"Index:English/x\",\"wgRestrictionEdit\":[],\"wgRestrictionMove\":[],\"wgVectorEnabledModules\":{\"collapsiblenav\":true,\"collapsibletabs\":true,\"expandablesearch\":false,\"footercleanup\":false,\"sectioneditlinks\":false,\"experiments\":true},\"wgWikiEditorEnabledModules\":{\"toolbar\":true,\"dialogs\":true,\"hidesig\":true,\"templateEditor\":false,\"templates\":false,\"preview\":false,\"previewDialog\":false,\"publish\":false,\"toc\":false},\"wgCategoryTreePageCategoryOptions\":\"{\"mode\":0,\"hideprefix\":20,\"showcount\":true,\"namespaces\":false}\",\"Geo\":{\"city\":\"\",\"country\":\"\"},\"wgNoticeProject\":\"wiktionary\"});" + 
								"}</script><script>if(window.mw){" + 
								"mw.loader.implement(\"user.options\",function(){mw.user.options.set({\"ccmeonemails\":0,\"cols\":80,\"date\":\"default\",\"diffonly\":0,\"disablemail\":0,\"disablesuggest\":0,\"editfont\":\"default\",\"editondblclick\":0,\"editsection\":1,\"editsectiononrightclick\":0,\"enotifminoredits\":0,\"enotifrevealaddr\":0,\"enotifusertalkpages\":1,\"enotifwatchlistpages\":0,\"extendwatchlist\":0,\"fancysig\":0,\"forceeditsummary\":0,\"gender\":\"unknown\",\"hideminor\":0,\"hidepatrolled\":0,\"imagesize\":2,\"justify\":0,\"math\":0,\"minordefault\":0,\"newpageshidepatrolled\":0,\"nocache\":0,\"noconvertlink\":0,\"norollbackdiff\":0,\"numberheadings\":0,\"previewonfirst\":0,\"previewontop\":1,\"rcdays\":7,\"rclimit\":50,\"rememberpassword\":0,\"rows\":25,\"searchlimit\":20,\"showhiddencats\":false,\"showjumplinks\":1,\"shownumberswatching\":1,\"showtoc\":1,\"showtoolbar\":1,\"skin\":\"vector\",\"stubthreshold\":0,\"thumbsize\":4,\"underline\":2,\"uselivepreview\":0,\"usenewrc\":0,\"watchcreations\":1,\"watchdefault\":0,\"watchdeletion\":0,\"watchlistdays\":3,\"watchlisthideanons\":0,\"watchlisthidebots\":0," + 
								"\"watchlisthideliu\":0,\"watchlisthideminor\":0,\"watchlisthideown\":0,\"watchlisthidepatrolled\":0,\"watchmoves\":0,\"wllimit\":250,\"useeditwarning\":1,\"vector-simplesearch\":1,\"vector-collapsiblenav\":1,\"usebetatoolbar\":1,\"usebetatoolbar-cgd\":1,\"lqtnotifytalk\":false,\"lqtdisplaydepth\":5,\"lqtdisplaycount\":25,\"lqtcustomsignatures\":true,\"lqt-watch-threads\":true,\"variant\":\"en\",\"language\":\"en\",\"searchNs0\":true,\"searchNs1\":false,\"searchNs2\":false,\"searchNs3\":false,\"searchNs4\":false,\"searchNs5\":false,\"searchNs6\":false,\"searchNs7\":false,\"searchNs8\":false,\"searchNs9\":false,\"searchNs10\":false,\"searchNs11\":false,\"searchNs12\":false,\"searchNs13\":false,\"searchNs14\":false,\"searchNs15\":false,\"searchNs90\":false,\"searchNs91\":false,\"searchNs92\":false,\"searchNs93\":false,\"searchNs100\":false,\"searchNs101\":false,\"searchNs102\":false,\"searchNs103\":false,\"searchNs104\":false,\"searchNs105\":false,\"searchNs106\":false,\"searchNs107\":false,\"searchNs108\":false,\"searchNs109\":false,\"searchNs110\":false,\"searchNs111\":false,\"searchNs114\"" + 
								":false,\"searchNs115\":false,\"searchNs116\":false,\"searchNs117\":false,\"searchNs828\":false,\"searchNs829\":false,\"gadget-PatrollingEnhancements\":1,\"webfontsEnable\":true});},{},{});mw.loader.implement(\"user.tokens\",function(){mw.user.tokens.set({\"editToken\":\"+\\\",\"patrolToken\":false,\"watchToken\":false});},{},{});" + 
								"/* cache key: enwiktionary:resourceloader:filter:minify-js:7:d7bf777c47625e314c6479a740492c45 */" + 
								"}</script>" + 
								"<script>if(window.mw){" + 
								"mw.loader.load([\"mediawiki.page.startup\",\"mediawiki.legacy.wikibits\",\"mediawiki.legacy.ajax\",\"ext.webfonts.init\",\"ext.centralNotice.bannerController\"]);" + 
								"}</script>" + 
								"<script src=\"//bits.wikimedia.org/geoiplookup\"></script><link rel=\"dns-prefetch\" href=\"//meta.wikimedia.org\" /><!--[if lt IE 7]><style type=\"text/css\">body{behavior:url(\"/w/static-1.22wmf4/skins/vector/csshover.min.htc\")}</style><![endif]--></head>" + 
								"<body class=\"mediawiki ltr sitedir-ltr ns-104 ns-subject page-Index_English_x skin-vector action-view vector-animateLayout\">" + 
								"		<div id=\"mw-page-base\" class=\"noprint\"></div>" + 
								"		<div id=\"mw-head-base\" class=\"noprint\"></div>" + 
								"		<div id=\"content\" class=\"mw-body\" role=\"main\">" + 
								"			<a id=\"top\"></a>" + 
								"			<div id=\"mw-js-message\" style=\"display:none;\"></div>" + 
								"						<div id=\"siteNotice\"><!-- CentralNotice --><script>document.write(\"\u003Cdiv id=\"localNotice\" lang=\"en\" dir=\"ltr\"\u003E\u003Cp\u003E\u003Cspan\u003E\u003C/span\u003E\n\u003C/p\u003E\u003C/div\u003E\");</script></div>" + 
								"						<h1 id=\"firstHeading\" class=\"firstHeading\" lang=\"en\"><span dir=\"auto\">Index:English/x</span></h1>" + 
								"			<div id=\"bodyContent\">" + 
								"								<div id=\"siteSub\">Definition from Wiktionary, the free dictionary</div>" + 
								"								<div id=\"contentSub\"><span class=\"subpages\">&lt; <a href=\"/wiki/Index:English\" title=\"Index:English\">Index:English</a></span></div>" + 
								"																<div id=\"jump-to-nav\" class=\"mw-jump\">" + 
								"					Jump to:					<a href=\"#mw-navigation\">navigation</a>, 					<a href=\"#p-search\">search</a>" + 
								"				</div>" + 
								"								<div id=\"mw-content-text\" lang=\"en\" dir=\"ltr\" class=\"mw-content-ltr\"><dl>" + 
								"<dd><i>The <b>590</b> terms on this page were extracted from the 2012-Apr-28 database dump.</i></dd>" + 
								"</dl>" + 
								"<hr />" + 
								"<center>" + 
								"<p><a href=\"/wiki/Index:English/0\" title=\"Index:English/0\">#</a> • <a href=\"/wiki/Index:English/a1\" title=\"Index:English/a1\">A<sup>m</sup></a> <a href=\"/wiki/Index:English/a2\" title=\"Index:English/a2\">A<sup>n</sup></a> • <a href=\"/wiki/Index:English/b1\" title=\"Index:English/b1\">B<sup>m</sup></a> <a href=\"/wiki/Index:English/b2\" title=\"Index:English/b2\">B<sup>n</sup></a> • <a href=\"/wiki/Index:English/c1\" title=\"Index:English/c1\">C<sup>m</sup></a> <a href=\"/wiki/Index:English/c2\" title=\"Index:English/c2\">C<sup>n</sup></a> • <a href=\"/wiki/Index:English/d1\" title=\"Index:English/d1\">D<sup>m</sup></a> • <a href=\"/wiki/Index:English/d2\" title=\"Index:English/d2\">D<sup>n</sup></a> • <a href=\"/wiki/Index:English/e\" title=\"Index:English/e\">E</a> • <a href=\"/wiki/Index:English/f\" title=\"Index:English/f\">F</a> • <a href=\"/wiki/Index:English/g\" title=\"Index:English/g\">G</a> • <a href=\"/wiki/Index:English/h\" title=\"Index:English/h\">H</a> • <a href=\"/wiki/Index:English/i\" title=\"Index:English/i\">I</a> • <a href=\"/wiki/Index:English/j\" title=\"Index:English/j\">J</a> • <a href=\"/wiki/Index:English/k\" title=\"Index:English/k\">K</a> • <a href=\"/wiki/Index:English/l\" title=\"Index:English/l\">L</a> • <a href=\"/wiki/Index:English/m1\" title=\"Index:English/m1\">M<sup>m</sup></a> <a href=\"/wiki/Index:English/m2\" title=\"Index:English/m2\">M<sup>n</sup></a> • <a href=\"/wiki/Index:English/n\" title=\"Index:English/n\" class=\"mw-redirect\">N<sup>m</sup></a> • <a href=\"/wiki/Index:English/n2\" title=\"Index:English/n2\">N<sup>n</sup></a> • <a href=\"/wiki/Index:English/o\" title=\"Index:English/o\">O</a> • <a href=\"/wiki/Index:English/p1\" title=\"Index:English/p1\">P<sup>m</sup></a> <a href=\"/wiki/Index:English/p2\" title=\"Index:English/p2\">P<sup>n</sup></a> • <a href=\"/wiki/Index:English/q\" title=\"Index:English/q\">Q</a> • <a href=\"/wiki/Index:English/r1\" title=\"Index:English/r1\">R<sup>m</sup></a> <a href=\"/wiki/Index:English/r2\" title=\"Index:English/r2\">R<sup>n</sup></a> • <a href=\"/wiki/Index:English/s1\" title=\"Index:English/s1\">S<sup>m</sup></a> <a href=\"/wiki/Index:English/s2\" title=\"Index:English/s2\">S<sup>n</sup></a> • <a href=\"/wiki/Index:English/t1\" title=\"Index:English/t1\">T<sup>m</sup></a> <a href=\"/wiki/Index:English/t2\" title=\"Index:English/t2\">T<sup>n</sup></a> • <a href=\"/wiki/Index:English/u\" title=\"Index:English/u\">U</a> • <a href=\"/wiki/Index:English/v\" title=\"Index:English/v\">V</a> • <a href=\"/wiki/Index:English/w\" title=\"Index:English/w\">W</a> • <strong class=\"selflink\">X</strong> • <a href=\"/wiki/Index:English/y\" title=\"Index:English/y\">Y</a> • <a href=\"/wiki/Index:English/z\" title=\"Index:English/z\">Z</a></p>" + 
								"</center>" + 
								"<hr />" + 
								"<div class=\"index\">" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"x\">x</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/-x\" title=\"-x\">-x</a> <i>suffix</i></li>" + 
								"<li><a href=\"/wiki/X#English\" title=\"X\">X</a> <i>num n adj abbr</i></li>" + 
								"<li><a href=\"/wiki/X11\" title=\"X11\">X11</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/x86\" title=\"x86\">x86</a> <i>proper</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xa\">xa</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/Xaasongaxango\" title=\"Xaasongaxango\">Xaasongaxango</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/X-Acto\" title=\"X-Acto\">X-Acto</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xacuti\" title=\"xacuti\">xacuti</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xalam\" title=\"xalam\">xalam</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xalapa\" title=\"Xalapa\">Xalapa</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xaliproden\" title=\"xaliproden\">xaliproden</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xamir\" title=\"Xamir\">Xamir</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xamoterol\" title=\"xamoterol\">xamoterol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xamtanga\" title=\"Xamtanga\">Xamtanga</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xan\" title=\"Xan\">Xan</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xanadu\" title=\"Xanadu\">Xanadu</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xanax\" title=\"Xanax\">Xanax</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xancidae\" title=\"Xancidae\">Xancidae</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xander\" title=\"Xander\">Xander</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xandra\" title=\"Xandra\">Xandra</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xanomeline\" title=\"xanomeline\">xanomeline</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanorphica\" title=\"xanorphica\">xanorphica</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanoxic_acid\" title=\"xanoxic acid\">xanoxic acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanth-\" title=\"xanth-\">xanth-</a> <i>prefix</i></li>" + 
								"<li><a href=\"/wiki/xanthamide\" title=\"xanthamide\">xanthamide</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthan\" title=\"xanthan\">xanthan</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthan_gum\" title=\"xanthan gum\">xanthan gum</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthate\" title=\"xanthate\">xanthate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthation\" title=\"xanthation\">xanthation</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xanthe\" title=\"Xanthe\">Xanthe</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xanthein\" title=\"xanthein\">xanthein</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthelasma\" title=\"xanthelasma\">xanthelasma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthemia\" title=\"xanthemia\">xanthemia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthene\" title=\"xanthene\">xanthene</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthene_dye\" title=\"xanthene dye\">xanthene dye</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthenic\" title=\"xanthenic\">xanthenic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/Xanthian\" title=\"Xanthian\">Xanthian</a> <i>adj n</i></li>" + 
								"<li><a href=\"/wiki/xanthic\" title=\"xanthic\">xanthic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthic_acid\" title=\"xanthic acid\">xanthic acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthid\" title=\"xanthid\">xanthid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthine\" title=\"xanthine\">xanthine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthine_oxidase\" title=\"xanthine oxidase\">xanthine oxidase</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthinol\" title=\"xanthinol\">xanthinol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthinuria\" title=\"xanthinuria\">xanthinuria</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthiosite\" title=\"xanthiosite\">xanthiosite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xanthippe\" title=\"Xanthippe\">Xanthippe</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthippic\" title=\"xanthippic\">xanthippic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthism\" title=\"xanthism\">xanthism</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthitane\" title=\"xanthitane\">xanthitane</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthite\" title=\"xanthite\">xanthite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xantho-\" title=\"xantho-\">xantho-</a> <i>prefix</i></li>" + 
								"<li><a href=\"/wiki/xanthocarpous\" title=\"xanthocarpous\">xanthocarpous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/Xanthochroi\" title=\"Xanthochroi\">Xanthochroi</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xanthochroic\" title=\"xanthochroic\">xanthochroic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthochroid\" title=\"xanthochroid\">xanthochroid</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthochrome\" title=\"xanthochrome\">xanthochrome</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthochromia\" title=\"xanthochromia\">xanthochromia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthochroous\" title=\"xanthochroous\">xanthochroous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthoconite\" title=\"xanthoconite\">xanthoconite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthocroic\" title=\"xanthocroic\">xanthocroic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthoderm\" title=\"xanthoderm\">xanthoderm</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthoderma\" title=\"xanthoderma\">xanthoderma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthodermic\" title=\"xanthodermic\">xanthodermic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthogen\" title=\"xanthogen\">xanthogen</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/0/0c/En-uk-xanthogen.ogg\" class=\"internal\" title=\"en-uk-xanthogen.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xanthogenate\" title=\"xanthogenate\">xanthogenate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthogenic_acid\" title=\"xanthogenic acid\">xanthogenic acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthogranuloma\" title=\"xanthogranuloma\">xanthogranuloma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthogranulomatous\" title=\"xanthogranulomatous\">xanthogranulomatous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthoma\" title=\"xanthoma\">xanthoma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthomatosis\" title=\"xanthomatosis\">xanthomatosis</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/8/84/En-uk-xanthomatosis.ogg\" class=\"internal\" title=\"en-uk-xanthomatosis.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xanthomatotic\" title=\"xanthomatotic\">xanthomatotic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthomatous\" title=\"xanthomatous\">xanthomatous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthomegnin\" title=\"xanthomegnin\">xanthomegnin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthomonad\" title=\"xanthomonad\">xanthomonad</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthomous\" title=\"xanthomous\">xanthomous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthone\" title=\"xanthone\">xanthone</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthonoid\" title=\"xanthonoid\">xanthonoid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthophobia\" title=\"xanthophobia\">xanthophobia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthophore\" title=\"xanthophore\">xanthophore</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthophyll\" title=\"xanthophyll\">xanthophyll</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthophyllic\" title=\"xanthophyllic\">xanthophyllic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthophyllite\" title=\"xanthophyllite\">xanthophyllite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthophyte\" title=\"xanthophyte\">xanthophyte</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthopicrite\" title=\"xanthopicrite\">xanthopicrite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthoproteic\" title=\"xanthoproteic\">xanthoproteic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xanthoproteic_acid\" title=\"xanthoproteic acid\">xanthoproteic acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthoprotein\" title=\"xanthoprotein\">xanthoprotein</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthopsia\" title=\"xanthopsia\">xanthopsia</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/d/d8/En-uk-xanthopsia.ogg\" class=\"internal\" title=\"en-uk-xanthopsia.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xanthopsydracia\" title=\"xanthopsydracia\">xanthopsydracia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthopterin\" title=\"xanthopterin\">xanthopterin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthopuccine\" title=\"xanthopuccine\">xanthopuccine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthorhamnin\" title=\"xanthorhamnin\">xanthorhamnin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthorin\" title=\"xanthorin\">xanthorin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthorrhoea\" title=\"xanthorrhoea\">xanthorrhoea</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthosine\" title=\"xanthosine\">xanthosine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthosis\" title=\"xanthosis\">xanthosis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthous\" title=\"xanthous\">xanthous</a> <i>adj</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/8/8d/En-us-xanthous.ogg\" class=\"internal\" title=\"en-us-xanthous.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xanthoxenite\" title=\"xanthoxenite\">xanthoxenite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthoxylene\" title=\"xanthoxylene\">xanthoxylene</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthyl\" title=\"xanthyl\">xanthyl</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xanthylic\" title=\"xanthylic\">xanthylic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xantifibrate\" title=\"xantifibrate\">xantifibrate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xantinol_nicotinate\" title=\"xantinol nicotinate\">xantinol nicotinate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xantocillin\" title=\"xantocillin\">xantocillin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xantusiid\" title=\"xantusiid\">xantusiid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X%C3%A2r%C3%A2c%C3%B9%C3%B9\" title=\"Xârâcùù\">Xârâcùù</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xat\" title=\"xat\">xat</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xav\" title=\"Xav\">Xav</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xav%C3%A1nte\" title=\"Xavánte\">Xavánte</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xaverian\" title=\"Xaverian\">Xaverian</a> <i>n adj</i></li>" + 
								"<li><a href=\"/wiki/Xavier\" title=\"Xavier\">Xavier</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xavierite\" title=\"Xavierite\">Xavierite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/x-axis\" title=\"x-axis\">x-axis</a> <i>n</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xb\">xb</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/X-bar\" title=\"X-bar\">X-bar</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-bar_theory\" title=\"X-bar theory\">X-bar theory</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xbox\" title=\"Xbox\">Xbox</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xboxer\" title=\"Xboxer\">Xboxer</a> <i>n</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xc\">xc</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XC#English\" title=\"XC\">XC</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/X-certificate\" title=\"X-certificate\">X-certificate</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/X-chair\" title=\"X-chair\">X-chair</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X_chromosome\" title=\"X chromosome\">X chromosome</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-country\" title=\"X-country\">X-country</a> <i>n adv</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xd\">xd</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/xd\" title=\"xd\">xd</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/x-direction\" title=\"x-direction\">x-direction</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/x-div.\" title=\"x-div.\">x-div.</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/xdiv\" title=\"xdiv\">xdiv</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/XDR#English\" title=\"XDR\">XDR</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XDR-TB\" title=\"XDR-TB\">XDR-TB</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/xDSL\" title=\"xDSL\">xDSL</a> <i>proper</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xe\">xe</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/xe\" title=\"xe\">xe</a> <i>pronoun</i></li>" + 
								"<li><a href=\"/wiki/xebec\" title=\"xebec\">xebec</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeer\" title=\"xeer\">xeer</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xem\" title=\"xem\">xem</a> <i>pronoun</i></li>" + 
								"<li><a href=\"/wiki/xeme\" title=\"xeme\">xeme</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xemilofiban\" title=\"xemilofiban\">xemilofiban</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xemu\" title=\"Xemu\">Xemu</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xena\" title=\"Xena\">Xena</a> <i>proper n</i></li>" + 
								"<li><a href=\"/wiki/xenagogue\" title=\"xenagogue\">xenagogue</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenagogy\" title=\"xenagogy\">xenagogy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenalipin\" title=\"xenalipin\">xenalipin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xenaphile\" title=\"Xenaphile\">Xenaphile</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenarthran\" title=\"xenarthran\">xenarthran</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenate\" title=\"xenate\">xenate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xenaverse\" title=\"Xenaverse\">Xenaverse</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xenazoic_acid\" title=\"xenazoic acid\">xenazoic acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenbucin\" title=\"xenbucin\">xenbucin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenelasia\" title=\"xenelasia\">xenelasia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenelasy\" title=\"xenelasy\">xenelasy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenharmonic\" title=\"xenharmonic\">xenharmonic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenia\" title=\"xenia\">xenia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xenia\" title=\"Xenia\">Xenia</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xenial\" title=\"xenial\">xenial</a> <i>adj</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/3/32/En-us-xenial.ogg\" class=\"internal\" title=\"en-us-xenial.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/Xenical\" title=\"Xenical\">Xenical</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xenipentone\" title=\"xenipentone\">xenipentone</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenna-\" title=\"xenna-\">xenna-</a> <i>prefix</i></li>" + 
								"<li><a href=\"/wiki/xenno-\" title=\"xenno-\">xenno-</a> <i>prefix</i></li>" + 
								"<li><a href=\"/wiki/xeno-\" title=\"xeno-\">xeno-</a> <i>prefix</i></li>" + 
								"<li><a href=\"/wiki/xenoandrogen\" title=\"xenoandrogen\">xenoandrogen</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenoantigen\" title=\"xenoantigen\">xenoantigen</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenoarchaeology\" title=\"xenoarchaeology\">xenoarchaeology</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/9/98/En-uk-xenoarchaeology.ogg\" class=\"internal\" title=\"en-uk-xenoarchaeology.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xenobiological\" title=\"xenobiological\">xenobiological</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenobiologist\" title=\"xenobiologist\">xenobiologist</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenobiology\" title=\"xenobiology\">xenobiology</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/2/2e/En-us-xenobiology.ogg\" class=\"internal\" title=\"en-us-xenobiology.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xenobiont\" title=\"xenobiont\">xenobiont</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenobiotic\" title=\"xenobiotic\">xenobiotic</a> <i>adj n</i></li>" + 
								"<li><a href=\"/wiki/xenobiotically\" title=\"xenobiotically\">xenobiotically</a> <i>adv</i></li>" + 
								"<li><a href=\"/wiki/xenoblast\" title=\"xenoblast\">xenoblast</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenocentric\" title=\"xenocentric\">xenocentric</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenocentricism\" title=\"xenocentricism\">xenocentricism</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenocide\" title=\"xenocide\">xenocide</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xenocrates\" title=\"Xenocrates\">Xenocrates</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xenocryst\" title=\"xenocryst\">xenocryst</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenodiagnosis\" title=\"xenodiagnosis\">xenodiagnosis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenodiagnostic\" title=\"xenodiagnostic\">xenodiagnostic</a> <i>adj</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/b/b0/En-uk-xenodiagnostic.ogg\" class=\"internal\" title=\"en-uk-xenodiagnostic.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xenodochial\" title=\"xenodochial\">xenodochial</a> <i>adj</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/a/aa/En-us-xenodochial.ogg\" class=\"internal\" title=\"en-us-xenodochial.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xenodochium\" title=\"xenodochium\">xenodochium</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/f/fd/En-us-xenodochium.ogg\" class=\"internal\" title=\"en-us-xenodochium.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xenodochy\" title=\"xenodochy\">xenodochy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenoestrogen\" title=\"xenoestrogen\">xenoestrogen</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenofree\" title=\"xenofree\">xenofree</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenogamy\" title=\"xenogamy\">xenogamy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenogeneic\" title=\"xenogeneic\">xenogeneic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenogenesis\" title=\"xenogenesis\">xenogenesis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenogenetic\" title=\"xenogenetic\">xenogenetic</a> <i>adj</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/8/83/En-us-xenogenetic.ogg\" class=\"internal\" title=\"en-us-xenogenetic.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xenogenic\" title=\"xenogenic\">xenogenic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenogenous\" title=\"xenogenous\">xenogenous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenogeny\" title=\"xenogeny\">xenogeny</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenoglossophobia\" title=\"xenoglossophobia\">xenoglossophobia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenoglossy\" title=\"xenoglossy\">xenoglossy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenograft\" title=\"xenograft\">xenograft</a> <i>n v</i></li>" + 
								"<li><a href=\"/wiki/xenografted\" title=\"xenografted\">xenografted</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenographic\" title=\"xenographic\">xenographic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenography\" title=\"xenography\">xenography</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenohormone\" title=\"xenohormone\">xenohormone</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenolalia\" title=\"xenolalia\">xenolalia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenolinguistics\" title=\"xenolinguistics\">xenolinguistics</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenolith\" title=\"xenolith\">xenolith</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenolithic\" title=\"xenolithic\">xenolithic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenolog\" title=\"xenolog\">xenolog</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenologous\" title=\"xenologous\">xenologous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenology\" title=\"xenology\">xenology</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenomania\" title=\"xenomania\">xenomania</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenomorph\" title=\"xenomorph\">xenomorph</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenon\" title=\"xenon\">xenon</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/7/75/En-us-xenon.ogg\" class=\"internal\" title=\"en-us-xenon.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xenon_difluoride\" title=\"xenon difluoride\">xenon difluoride</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenon_flash_lamp\" title=\"xenon flash lamp\">xenon flash lamp</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenon_hexafluoroplatinate\" title=\"xenon hexafluoroplatinate\">xenon hexafluoroplatinate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenonym\" title=\"xenonym\">xenonym</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenoparasitic\" title=\"xenoparasitic\">xenoparasitic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/Xenophanean\" title=\"Xenophanean\">Xenophanean</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/Xenophanes\" title=\"Xenophanes\">Xenophanes</a> <i>proper n</i></li>" + 
								"<li><a href=\"/wiki/xenophile\" title=\"xenophile\">xenophile</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenophilia\" title=\"xenophilia\">xenophilia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenophilic\" title=\"xenophilic\">xenophilic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenophobe\" title=\"xenophobe\">xenophobe</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenophobia\" title=\"xenophobia\">xenophobia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenophobic\" title=\"xenophobic\">xenophobic</a> <i>adj n</i></li>" + 
								"<li><a href=\"/wiki/xenophoby\" title=\"xenophoby\">xenophoby</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xenophon\" title=\"Xenophon\">Xenophon</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xenophone\" title=\"xenophone\">xenophone</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xenophontean\" title=\"Xenophontean\">Xenophontean</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenophora\" title=\"xenophora\">xenophora</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenophthalmia\" title=\"xenophthalmia\">xenophthalmia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenophyte\" title=\"xenophyte\">xenophyte</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenopid\" title=\"xenopid\">xenopid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenoplastic\" title=\"xenoplastic\">xenoplastic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenoplastically\" title=\"xenoplastically\">xenoplastically</a> <i>adv</i></li>" + 
								"<li><a href=\"/wiki/xenoplasty\" title=\"xenoplasty\">xenoplasty</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenoreactive\" title=\"xenoreactive\">xenoreactive</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenoreactivity\" title=\"xenoreactivity\">xenoreactivity</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenotime\" title=\"xenotime\">xenotime</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenotite\" title=\"xenotite\">xenotite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenotransplant\" title=\"xenotransplant\">xenotransplant</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenotransplantable\" title=\"xenotransplantable\">xenotransplantable</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenotransplantation\" title=\"xenotransplantation\">xenotransplantation</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenotransplanted\" title=\"xenotransplanted\">xenotransplanted</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenotropic\" title=\"xenotropic\">xenotropic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xenotropism\" title=\"xenotropism\">xenotropism</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenovenine\" title=\"xenovenine\">xenovenine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenozoonosis\" title=\"xenozoonosis\">xenozoonosis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenthiorate\" title=\"xenthiorate\">xenthiorate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xenu\" title=\"Xenu\">Xenu</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/-xeny\" title=\"-xeny\">-xeny</a> <i>suffix</i></li>" + 
								"<li><a href=\"/wiki/xenygloxal\" title=\"xenygloxal\">xenygloxal</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenyhexenic_acid\" title=\"xenyhexenic acid\">xenyhexenic acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xenyl\" title=\"xenyl\">xenyl</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xer\" title=\"Xer\">Xer</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeranthemum\" title=\"xeranthemum\">xeranthemum</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeraphim\" title=\"xeraphim\">xeraphim</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerarch\" title=\"xerarch\">xerarch</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerclod\" title=\"xerclod\">xerclod</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeric\" title=\"xeric\">xeric</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerically\" title=\"xerically\">xerically</a> <i>adv</i></li>" + 
								"<li><a href=\"/wiki/xeriff\" title=\"xeriff\">xeriff</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeriscape\" title=\"xeriscape\">xeriscape</a> <i>n v</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/b/bd/En-us-xeriscape.ogg\" class=\"internal\" title=\"en-us-xeriscape.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xeriscaper\" title=\"xeriscaper\">xeriscaper</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeriscaping\" title=\"xeriscaping\">xeriscaping</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xero-\" title=\"xero-\">xero-</a> <i>prefix</i></li>" + 
								"<li><a href=\"/wiki/xerocolous\" title=\"xerocolous\">xerocolous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerocracy\" title=\"xerocracy\">xerocracy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroderma\" title=\"xeroderma\">xeroderma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroderma_pigmentosum\" title=\"xeroderma pigmentosum\">xeroderma pigmentosum</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerodermia\" title=\"xerodermia\">xerodermia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroform\" title=\"xeroform\">xeroform</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerogel\" title=\"xerogel\">xerogel</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerograph\" title=\"xerograph\">xerograph</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerographic\" title=\"xerographic\">xerographic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerographically\" title=\"xerographically\">xerographically</a> <i>adv</i></li>" + 
								"<li><a href=\"/wiki/xerography\" title=\"xerography\">xerography</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroma\" title=\"xeroma\">xeroma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeromammogram\" title=\"xeromammogram\">xeromammogram</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeromammographic\" title=\"xeromammographic\">xeromammographic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xeromammography\" title=\"xeromammography\">xeromammography</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeromorph\" title=\"xeromorph\">xeromorph</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeromorphic\" title=\"xeromorphic\">xeromorphic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xeronate\" title=\"xeronate\">xeronate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeronic_acid\" title=\"xeronic acid\">xeronic acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerophagy\" title=\"xerophagy\">xerophagy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerophile\" title=\"xerophile\">xerophile</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerophilic\" title=\"xerophilic\">xerophilic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerophilous\" title=\"xerophilous\">xerophilous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerophobia\" title=\"xerophobia\">xerophobia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerophthalmia\" title=\"xerophthalmia\">xerophthalmia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerophthalmic\" title=\"xerophthalmic\">xerophthalmic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerophthalmy\" title=\"xerophthalmy\">xerophthalmy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerophyte\" title=\"xerophyte\">xerophyte</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerophytic\" title=\"xerophytic\">xerophytic</a> <i>adj n</i></li>" + 
								"<li><a href=\"/wiki/xeropthalmia\" title=\"xeropthalmia\">xeropthalmia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroradiogram\" title=\"xeroradiogram\">xeroradiogram</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroradiograph\" title=\"xeroradiograph\">xeroradiograph</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroradiography\" title=\"xeroradiography\">xeroradiography</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroseral\" title=\"xeroseral\">xeroseral</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerosere\" title=\"xerosere\">xerosere</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerosis\" title=\"xerosis\">xerosis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerostoma\" title=\"xerostoma\">xerostoma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerostomia\" title=\"xerostomia\">xerostomia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerostomic\" title=\"xerostomic\">xerostomic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerothermic\" title=\"xerothermic\">xerothermic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerothermic_period\" title=\"xerothermic period\">xerothermic period</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerotic\" title=\"xerotic\">xerotic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerox\" title=\"xerox\">xerox</a> <i>n v</i></li>" + 
								"<li><a href=\"/wiki/Xerox\" title=\"Xerox\">Xerox</a> <i>proper n</i></li>" + 
								"<li><a href=\"/wiki/xeroxable\" title=\"xeroxable\">xeroxable</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xerox_copy\" title=\"xerox copy\">xerox copy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroxer\" title=\"xeroxer\">xeroxer</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xeroxlore\" title=\"xeroxlore\">xeroxlore</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xerulin\" title=\"xerulin\">xerulin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xerxean\" title=\"Xerxean\">Xerxean</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/Xerxes\" title=\"Xerxes\">Xerxes</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xestospongin\" title=\"xestospongin\">xestospongin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xesturgy\" title=\"xesturgy\">xesturgy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xevsurian\" title=\"Xevsurian\">Xevsurian</a> <i>proper</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xf\">xf</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/X_factor\" title=\"X factor\">X factor</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XFF\" title=\"XFF\">XFF</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XFL\" title=\"XFL\">XFL</a> <i>init</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xg\">xg</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/X-gal\" title=\"X-gal\">X-gal</a> <i>n</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xh\">xh</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/x-height\" title=\"x-height\">x-height</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xhosa\" title=\"Xhosa\">Xhosa</a> <i>n proper</i></li>" + 
								"<li><a href=\"/wiki/Xhosan\" title=\"Xhosan\">Xhosan</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/XHR\" title=\"XHR\">XHR</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XHTML\" title=\"XHTML\">XHTML</a> <i>init</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xi\">xi</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/-xi-\" title=\"-xi-\">-xi-</a> <i>infix</i></li>" + 
								"<li><a href=\"/wiki/xi\" title=\"xi\">xi</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/d/dd/En-us-xi.ogg\" class=\"internal\" title=\"en-us-xi.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/Xi\" title=\"Xi\">Xi</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xiamen\" title=\"Xiamen\">Xiamen</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xi%27an\" title=\"Xi'an\">Xi'an</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xian\" title=\"Xian\">Xian</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xiang\" title=\"Xiang\">Xiang</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xiangjiangite\" title=\"xiangjiangite\">xiangjiangite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiangqi\" title=\"xiangqi\">xiangqi</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xiao%27erjing\" title=\"Xiao'erjing\">Xiao'erjing</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xiaolongbao\" title=\"xiaolongbao\">xiaolongbao</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xi_baryon\" title=\"xi baryon\">xi baryon</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xibenolol\" title=\"xibenolol\">xibenolol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xibornol\" title=\"xibornol\">xibornol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xifengite\" title=\"xifengite\">xifengite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xilingolite\" title=\"xilingolite\">xilingolite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xilobam\" title=\"xilobam\">xilobam</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xilokastro\" title=\"Xilokastro\">Xilokastro</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xilokastron\" title=\"Xilokastron\">Xilokastron</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/ximelagatran\" title=\"ximelagatran\">ximelagatran</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Ximenean\" title=\"Ximenean\">Ximenean</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/ximengite\" title=\"ximengite\">ximengite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/ximoprofen\" title=\"ximoprofen\">ximoprofen</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xinafoate\" title=\"xinafoate\">xinafoate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xinca\" title=\"Xinca\">Xinca</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xing\" title=\"xing\">xing</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/xingshu\" title=\"xingshu\">xingshu</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xingu\" title=\"Xingu\">Xingu</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xingzhongite\" title=\"xingzhongite\">xingzhongite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xinidamine\" title=\"xinidamine\">xinidamine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xining\" title=\"Xining\">Xining</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xinjiang\" title=\"Xinjiang\">Xinjiang</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xinomiline\" title=\"xinomiline\">xinomiline</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xinyang\" title=\"Xinyang\">Xinyang</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xinzhu\" title=\"Xinzhu\">Xinzhu</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xipamide\" title=\"xipamide\">xipamide</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xipaya\" title=\"Xipaya\">Xipaya</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xiphias\" title=\"xiphias\">xiphias</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphidiocercaria\" title=\"xiphidiocercaria\">xiphidiocercaria</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphihumeralis\" title=\"xiphihumeralis\">xiphihumeralis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphioid\" title=\"xiphioid\">xiphioid</a> <i>adj n</i></li>" + 
								"<li><a href=\"/wiki/xiphiplastron\" title=\"xiphiplastron\">xiphiplastron</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphisternal\" title=\"xiphisternal\">xiphisternal</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xiphisternum\" title=\"xiphisternum\">xiphisternum</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphocostal\" title=\"xiphocostal\">xiphocostal</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xiphodynia\" title=\"xiphodynia\">xiphodynia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphoid\" title=\"xiphoid\">xiphoid</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xiphoidalgia\" title=\"xiphoidalgia\">xiphoidalgia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphoidian\" title=\"xiphoidian\">xiphoidian</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xiphoiditis\" title=\"xiphoiditis\">xiphoiditis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphoid_process\" title=\"xiphoid process\">xiphoid process</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphonite\" title=\"xiphonite\">xiphonite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphopagus\" title=\"xiphopagus\">xiphopagus</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphophyllous\" title=\"xiphophyllous\">xiphophyllous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xiphosauran\" title=\"xiphosauran\">xiphosauran</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphosternum\" title=\"xiphosternum\">xiphosternum</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphosuran\" title=\"xiphosuran\">xiphosuran</a> <i>n adj</i></li>" + 
								"<li><a href=\"/wiki/xiphosure\" title=\"xiphosure\">xiphosure</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphosurid\" title=\"xiphosurid\">xiphosurid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xiphosurous\" title=\"xiphosurous\">xiphosurous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xipranolol\" title=\"xipranolol\">xipranolol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xiri\" title=\"Xiri\">Xiri</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xitieshanite\" title=\"xitieshanite\">xitieshanite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xizang\" title=\"Xizang\">Xizang</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xizang_Autonomous_Region\" title=\"Xizang Autonomous Region\">Xizang Autonomous Region</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xizang_Zizhiqu\" title=\"Xizang Zizhiqu\">Xizang Zizhiqu</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/-xizu-\" title=\"-xizu-\">-xizu-</a> <i>infix</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xj\">xj</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/X-junction\" title=\"X-junction\">X-junction</a> <i>n</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xl\">xl</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/X-linked\" title=\"X-linked\">X-linked</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/X-linked_gene\" title=\"X-linked gene\">X-linked gene</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-linked_trait\" title=\"X-linked trait\">X-linked trait</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xlnt\" title=\"xlnt\">xlnt</a> <i>adj</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xm\">xm</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XM#English\" title=\"XM\">XM</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/XMA\" title=\"XMA\">XMA</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/X_mark\" title=\"X mark\">X mark</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X_marks_the_spot\" title=\"X marks the spot\">X marks the spot</a> <i>phrase</i></li>" + 
								"<li><a href=\"/wiki/XML\" title=\"XML\">XML</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XML_Path_Language\" title=\"XML Path Language\">XML Path Language</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XMM\" title=\"XMM\">XMM</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XMP\" title=\"XMP\">XMP</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XMRV\" title=\"XMRV\">XMRV</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/XMS\" title=\"XMS\">XMS</a> <i>init</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xn\">xn</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XNA\" title=\"XNA\">XNA</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XNAY\" title=\"XNAY\">XNAY</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/XNOR\" title=\"XNOR\">XNOR</a> <i>n</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xo\">xo</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XO\" title=\"XO\">XO</a> <i>acronym</i></li>" + 
								"<li><a href=\"/wiki/xoanon\" title=\"xoanon\">xoanon</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xochinacaztli\" title=\"xochinacaztli\">xochinacaztli</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xocomecatlite\" title=\"xocomecatlite\">xocomecatlite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xocomil\" title=\"Xocomil\">Xocomil</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xolo\" title=\"Xolo\">Xolo</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xoloitzcuintli\" title=\"Xoloitzcuintli\">Xoloitzcuintli</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xonaltite\" title=\"xonaltite\">xonaltite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xonotlite\" title=\"xonotlite\">xonotlite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/!X%C3%B3%C3%B5\" title=\"!Xóõ\" class=\"mw-redirect\">!Xóõ</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/-xor\" title=\"-xor\">-xor</a> <i>suffix</i></li>" + 
								"<li><a href=\"/wiki/xor\" title=\"xor\">xor</a> <i>n conj</i></li>" + 
								"<li><a href=\"/wiki/XOR\" title=\"XOR\">XOR</a> <i>n v</i></li>" + 
								"<li><a href=\"/wiki/xorphanol\" title=\"xorphanol\">xorphanol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X_out\" title=\"X out\">X out</a> <i>v</i></li>" + 
								"<li><a href=\"/wiki/xoxo\" title=\"xoxo\">xoxo</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/xoxoxo\" title=\"xoxoxo\">xoxoxo</a> <i>abbr</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xp\">xp</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XP\" title=\"XP\">XP</a> <i>init abbr</i></li>" + 
								"<li><a href=\"/wiki/XPCOM\" title=\"XPCOM\">XPCOM</a> <i>acronym</i></li>" + 
								"<li><a href=\"/wiki/XPDL\" title=\"XPDL\">XPDL</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XPer\" title=\"XPer\">XPer</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-Phile\" title=\"X-Phile\">X-Phile</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X_Prize\" title=\"X Prize\">X Prize</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XPS\" title=\"XPS\">XPS</a> <i>init</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xq\">xq</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XQuery\" title=\"XQuery\">XQuery</a> <i>proper</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xr\">xr</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XR\" title=\"XR\">XR</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XR9576\" title=\"XR9576\">XR9576</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-radiation\" title=\"X-radiation\">X-radiation</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-rated\" title=\"X-rated\">X-rated</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/X-ray#English\" title=\"X-ray\">X-ray</a> <i>n v adj</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/d/da/En-us-X-ray.ogg\" class=\"internal\" title=\"en-us-X-ray.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/X-ray_absorbing_glass\" title=\"X-ray absorbing glass\">X-ray absorbing glass</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_astronomy\" title=\"X-ray astronomy\">X-ray astronomy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_binary\" title=\"X-ray binary\">X-ray binary</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_crystallography\" title=\"X-ray crystallography\">X-ray crystallography</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_diffraction\" title=\"X-ray diffraction\">X-ray diffraction</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_fluorescence\" title=\"X-ray fluorescence\">X-ray fluorescence</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_microscope\" title=\"X-ray microscope\">X-ray microscope</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_radiation\" title=\"X-ray radiation\">X-ray radiation</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_spectrometer\" title=\"X-ray spectrometer\">X-ray spectrometer</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_spectroscopy\" title=\"X-ray spectroscopy\">X-ray spectroscopy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_telescope\" title=\"X-ray telescope\">X-ray telescope</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_therapy\" title=\"X-ray therapy\">X-ray therapy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_tube\" title=\"X-ray tube\">X-ray tube</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-ray_vision\" title=\"X-ray vision\">X-ray vision</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XRCD\" title=\"XRCD\">XRCD</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XRD\" title=\"XRD\">XRD</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XRF\" title=\"XRF\">XRF</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/X-ring\" title=\"X-ring\">X-ring</a> <i>n</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xs\">xs</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/x%27s\" title=\"x's\">x's</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X%27s\" title=\"X's\">X's</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XS\" title=\"XS\">XS</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/X-SAMPA\" title=\"X-SAMPA\">X-SAMPA</a> <i>acronym</i></li>" + 
								"<li><a href=\"/wiki/X%27s_and_O%27s\" title=\"X's and O's\">X's and O's</a> <i>n abbr</i></li>" + 
								"<li><a href=\"/wiki/XSL\" title=\"XSL\">XSL</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XSS\" title=\"XSS\">XSS</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/X-stool\" title=\"X-stool\">X-stool</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/X-stretcher\" title=\"X-stretcher\">X-stretcher</a> <i>n</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xt\">xt</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XT\" title=\"XT\">XT</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/xtal\" title=\"xtal\">xtal</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/XTC\" title=\"XTC\">XTC</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/Xty\" title=\"Xty\">Xty</a> <i>abbr</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xu\">xu</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/xu\" title=\"xu\">xu</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/!X%C5%A9\" title=\"!Xu\" class=\"mw-redirect\">!Xu</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xuereb\" title=\"Xuereb\">Xuereb</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xueta\" title=\"Xueta\">Xueta</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XUL\" title=\"XUL\">XUL</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xuzhou\" title=\"Xuzhou\">Xuzhou</a> <i>n</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xv\">xv</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/X-Verse\" title=\"X-Verse\">X-Verse</a> <i>proper</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xx\">xx</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/XXL#English\" title=\"XXL\">XXL</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/XXS\" title=\"XXS\">XXS</a> <i>init</i></li>" + 
								"<li><a href=\"/wiki/xxx#English\" title=\"xxx\">xxx</a> <i>abbr</i></li>" + 
								"<li><a href=\"/wiki/XXX#English\" title=\"XXX\">XXX</a> <i>symbol adj v</i></li>" + 
								"<li><a href=\"/wiki/XXXX#English\" title=\"XXXX\">XXXX</a> <i>proper adj</i></li>" + 
								"</ol>" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"<h3><span class=\"mw-headline\" id=\"xy\">xy</span></h3>" + 
								"<ol>" + 
								"<li><a href=\"/wiki/xylamide\" title=\"xylamide\">xylamide</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylan\" title=\"xylan\">xylan</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylanase\" title=\"xylanase\">xylanase</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylanohydrolase\" title=\"xylanohydrolase\">xylanohydrolase</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylanolysis\" title=\"xylanolysis\">xylanolysis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylanolytic\" title=\"xylanolytic\">xylanolytic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylanthrax\" title=\"xylanthrax\">xylanthrax</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylaric_acid\" title=\"xylaric acid\">xylaric acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylary\" title=\"xylary\">xylary</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylate\" title=\"xylate\">xylate</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylazine\" title=\"xylazine\">xylazine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylem\" title=\"xylem\">xylem</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylemic\" title=\"xylemic\">xylemic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylemless\" title=\"xylemless\">xylemless</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylemlike\" title=\"xylemlike\">xylemlike</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylene\" title=\"xylene\">xylene</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylenol\" title=\"xylenol\">xylenol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylenol_orange\" title=\"xylenol orange\">xylenol orange</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylenyl\" title=\"xylenyl\">xylenyl</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylic\" title=\"xylic\">xylic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylidic\" title=\"xylidic\">xylidic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylidine\" title=\"xylidine\">xylidine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylindein\" title=\"xylindein\">xylindein</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylite\" title=\"xylite\">xylite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylitol\" title=\"xylitol\">xylitol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylitone\" title=\"xylitone\">xylitone</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylo\" title=\"xylo\">xylo</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylo-\" title=\"xylo-\">xylo-</a> <i>prefix</i></li>" + 
								"<li><a href=\"/wiki/xylobalsamum\" title=\"xylobalsamum\">xylobalsamum</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylobiose\" title=\"xylobiose\">xylobiose</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylocaine\" title=\"xylocaine\">xylocaine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylocarpous\" title=\"xylocarpous\">xylocarpous</a> <i>adj</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/2/2e/En-uk-xylocarpous.ogg\" class=\"internal\" title=\"en-uk-xylocarpous.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xylocopine\" title=\"xylocopine\">xylocopine</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylocoumarol\" title=\"xylocoumarol\">xylocoumarol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylofuranoside\" title=\"xylofuranoside\">xylofuranoside</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylogen\" title=\"xylogen\">xylogen</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylogenesis\" title=\"xylogenesis\">xylogenesis</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyloglucan\" title=\"xyloglucan\">xyloglucan</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyloglyphy\" title=\"xyloglyphy\">xyloglyphy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylograph\" title=\"xylograph\">xylograph</a> <i>n v</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/4/45/En-us-xylograph.ogg\" class=\"internal\" title=\"en-us-xylograph.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xylographer\" title=\"xylographer\">xylographer</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylographic\" title=\"xylographic\">xylographic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylographical\" title=\"xylographical\">xylographical</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylography\" title=\"xylography\">xylography</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyloid\" title=\"xyloid\">xyloid</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xyloidin\" title=\"xyloidin\">xyloidin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyloid_jasper\" title=\"xyloid jasper\">xyloid jasper</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/Xylokastro\" title=\"Xylokastro\">Xylokastro</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/Xylokastron\" title=\"Xylokastron\">Xylokastron</a> <i>proper</i></li>" + 
								"<li><a href=\"/wiki/xyloketal\" title=\"xyloketal\">xyloketal</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyloketose\" title=\"xyloketose\">xyloketose</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylol\" title=\"xylol\">xylol</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylology\" title=\"xylology\">xylology</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylomancy\" title=\"xylomancy\">xylomancy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylo-marimba\" title=\"xylo-marimba\">xylo-marimba</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylometazoline\" title=\"xylometazoline\">xylometazoline</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylometer\" title=\"xylometer\">xylometer</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylonic_acid\" title=\"xylonic acid\">xylonic acid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylonite\" title=\"xylonite\">xylonite</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylophage\" title=\"xylophage\">xylophage</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylophagous\" title=\"xylophagous\">xylophagous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylophagy\" title=\"xylophagy\">xylophagy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylophilous\" title=\"xylophilous\">xylophilous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylophobia\" title=\"xylophobia\">xylophobia</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylophone\" title=\"xylophone\">xylophone</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/3/37/En-us-xylophone.ogg\" class=\"internal\" title=\"En-us-xylophone.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xylophonelike\" title=\"xylophonelike\">xylophonelike</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylophonic\" title=\"xylophonic\">xylophonic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylophonically\" title=\"xylophonically\">xylophonically</a> <i>adv</i></li>" + 
								"<li><a href=\"/wiki/xylophonist\" title=\"xylophonist\">xylophonist</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyloplastic\" title=\"xyloplastic\">xyloplastic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylopyranose\" title=\"xylopyranose\">xylopyranose</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylopyranoside\" title=\"xylopyranoside\">xylopyranoside</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylopyranosyl\" title=\"xylopyranosyl\">xylopyranosyl</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylopyrography\" title=\"xylopyrography\">xylopyrography</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyloquinone\" title=\"xyloquinone\">xyloquinone</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylorcin\" title=\"xylorcin\">xylorcin</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylorimba\" title=\"xylorimba\">xylorimba</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/c/c4/En-uk-xylorimba.ogg\" class=\"internal\" title=\"en-uk-xylorimba.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xylose\" title=\"xylose\">xylose</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylosidase\" title=\"xylosidase\">xylosidase</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyloside\" title=\"xyloside\">xyloside</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylosma\" title=\"xylosma\">xylosma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylostroma\" title=\"xylostroma\">xylostroma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylosyl\" title=\"xylosyl\">xylosyl</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylosylprotein\" title=\"xylosylprotein\">xylosylprotein</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylosyltransferase\" title=\"xylosyltransferase\">xylosyltransferase</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylotomist\" title=\"xylotomist\">xylotomist</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylotomous\" title=\"xylotomous\">xylotomous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xylotomy\" title=\"xylotomy\">xylotomy</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylotypographic\" title=\"xylotypographic\">xylotypographic</a> <i>adj</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/b/b4/En-uk-xylotypographic.ogg\" class=\"internal\" title=\"en-uk-xylotypographic.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xylotypography\" title=\"xylotypography\">xylotypography</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/0/05/En-uk-xylotypography.ogg\" class=\"internal\" title=\"en-uk-xylotypography.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xyloxemine\" title=\"xyloxemine\">xyloxemine</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylulose\" title=\"xylulose\">xylulose</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/8/80/En-uk-xylulose.ogg\" class=\"internal\" title=\"en-uk-xylulose.ogg\">?</a></span></li>" + 
								"<li><a href=\"/wiki/xylyl\" title=\"xylyl\">xylyl</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xylylene\" title=\"xylylene\">xylylene</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xynisteri\" title=\"xynisteri\">xynisteri</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyr\" title=\"xyr\">xyr</a> <i>pronoun</i></li>" + 
								"<li><a href=\"/wiki/xyr-\" title=\"xyr-\">xyr-</a> <i>prefix</i></li>" + 
								"<li><a href=\"/wiki/xyrid\" title=\"xyrid\">xyrid</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyridaceous\" title=\"xyridaceous\">xyridaceous</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xyris\" title=\"xyris\">xyris</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyrophilic\" title=\"xyrophilic\">xyrophilic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xyrophobic\" title=\"xyrophobic\">xyrophobic</a> <i>adj</i></li>" + 
								"<li><a href=\"/wiki/xyrospasm\" title=\"xyrospasm\">xyrospasm</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyrself\" title=\"xyrself\">xyrself</a> <i>pronoun</i></li>" + 
								"<li><a href=\"/wiki/xysma\" title=\"xysma\">xysma</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyst\" title=\"xyst\">xyst</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xystarch\" title=\"xystarch\">xystarch</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyster\" title=\"xyster\">xyster</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xyston\" title=\"xyston\">xyston</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/xystus\" title=\"xystus\">xystus</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XYY_syndrome\" title=\"XYY syndrome\">XYY syndrome</a> <i>n</i></li>" + 
								"<li><a href=\"/wiki/XYZ\" title=\"XYZ\">XYZ</a> <i>n init</i></li>" + 
								"<li><a href=\"/wiki/xyzzy\" title=\"xyzzy\">xyzzy</a> <i>n</i> <span class=\"unicode\"><a href=\"//upload.wikimedia.org/wikipedia/commons/4/46/En-uk-xyzzy.ogg\" class=\"internal\" title=\"en-uk-xyzzy.ogg\">?</a></span></li>" + 
								"</ol>" + 
								"</div>" + 
								"<div style=\"display: none\">" + 
								"<div style=\"width:100%;clear:both;border-top:1px solid #AAAAAA;border-bottom:1px solid #AAAAAA\"><a href=\"/wiki/Index:English/x#globalWrapper\" title=\"Index:English/x\">?</a> <a href=\"#x\">x</a> <a href=\"#xa\">xa</a> <a href=\"#xb\">xb</a> <a href=\"#xc\">xc</a> <a href=\"#xd\">xd</a> <a href=\"#xe\">xe</a> <a href=\"#xf\">xf</a> <a href=\"#xg\">xg</a> <a href=\"#xh\">xh</a> <a href=\"#xi\">xi</a> <a href=\"#xj\">xj</a> <a href=\"#xl\">xl</a> <a href=\"#xm\">xm</a> <a href=\"#xn\">xn</a> <a href=\"#xo\">xo</a> <a href=\"#xp\">xp</a> <a href=\"#xq\">xq</a> <a href=\"#xr\">xr</a> <a href=\"#xs\">xs</a> <a href=\"#xt\">xt</a> <a href=\"#xu\">xu</a> <a href=\"#xv\">xv</a> <a href=\"#xx\">xx</a> <a href=\"#xy\">xy</a></div>" + 
								"</div>" + 
								"" + 
								"" + 
								"<!-- " + 
								"NewPP limit report" + 
								"Preprocessor visited node count: 548/1000000" + 
								"Preprocessor generated node count: 1658/1500000" + 
								"Post-expand include size: 12576/2048000 bytes" + 
								"Template argument size: 467/2048000 bytes" + 
								"Highest expansion depth: 3/40" + 
								"Expensive parser function count: 0/500" + 
								"-->" + 
								"" + 
								"<!-- Saved in parser cache with key enwiktionary:pcache:idhash:2836-0!*!0!!*!*!* and timestamp 20130518202531 -->" + 
								"</div>								<div class=\"printfooter\">" + 
								"				Retrieved from \"<a href=\"http://en.wiktionary.org/w/index.php?title=Index:English/x&amp;oldid=16756295\">http://en.wiktionary.org/w/index.php?title=Index:English/x&amp;oldid=16756295</a>\"				</div>" + 
								"												<div id='catlinks' class='catlinks catlinks-allhidden'></div>												<div class=\"visualClear\"></div>" + 
								"							</div>" + 
								"		</div>" + 
								"		<div id=\"mw-navigation\">" + 
								"			<h2>Navigation menu</h2>" + 
								"			<div id=\"mw-head\">" + 
								"				<div id=\"p-personal\" role=\"navigation\" class=\"\">" + 
								"	<h3>Personal tools</h3>" + 
								"	<ul>" + 
								"<li id=\"pt-createaccount\"><a href=\"/w/index.php?title=Special:UserLogin&amp;returnto=Index%3AEnglish%2Fx&amp;type=signup\">Create account</a></li><li id=\"pt-login\"><a href=\"/w/index.php?title=Special:UserLogin&amp;returnto=Index%3AEnglish%2Fx\" title=\"You are encouraged to log in; however, it is not mandatory [o]\" accesskey=\"o\">Log in</a></li>	</ul>" + 
								"</div>" + 
								"				<div id=\"left-navigation\">" + 
								"					<div id=\"p-namespaces\" role=\"navigation\" class=\"vectorTabs\">" + 
								"	<h3>Namespaces</h3>" + 
								"	<ul>" + 
								"					<li  id=\"ca-nstab-index\" class=\"selected\"><span><a href=\"/wiki/Index:English/x\" >Index</a></span></li>" + 
								"					<li  id=\"ca-talk\" class=\"new\"><span><a href=\"/w/index.php?title=Index_talk:English/x&amp;action=edit&amp;redlink=1\"  title=\"Discussion about the content page [t]\" accesskey=\"t\">Discussion</a></span></li>" + 
								"			</ul>" + 
								"</div>" + 
								"<div id=\"p-variants\" role=\"navigation\" class=\"vectorMenu emptyPortlet\">" + 
								"	<h3 id=\"mw-vector-current-variant\">" + 
								"		</h3>" + 
								"	<h3><span>Variants</span><a href=\"#\"></a></h3>" + 
								"	<div class=\"menu\">" + 
								"		<ul>" + 
								"					</ul>" + 
								"	</div>" + 
								"</div>" + 
								"				</div>" + 
								"				<div id=\"right-navigation\">" + 
								"					<div id=\"p-views\" role=\"navigation\" class=\"vectorTabs\">" + 
								"	<h3>Views</h3>" + 
								"	<ul>" + 
								"					<li id=\"ca-view\" class=\"selected\"><span><a href=\"/wiki/Index:English/x\" >Read</a></span></li>" + 
								"					<li id=\"ca-edit\"><span><a href=\"/w/index.php?title=Index:English/x&amp;action=edit\"  title=\"You can edit this page. Please use the preview button before saving [e]\" accesskey=\"e\">Edit</a></span></li>" + 
								"					<li id=\"ca-history\" class=\"collapsible\"><span><a href=\"/w/index.php?title=Index:English/x&amp;action=history\"  title=\"Past revisions of this page [h]\" accesskey=\"h\">History</a></span></li>" + 
								"			</ul>" + 
								"</div>" + 
								"<div id=\"p-cactions\" role=\"navigation\" class=\"vectorMenu emptyPortlet\">" + 
								"	<h3><span>Actions</span><a href=\"#\"></a></h3>" + 
								"	<div class=\"menu\">" + 
								"		<ul>" + 
								"					</ul>" + 
								"	</div>" + 
								"</div>" + 
								"<div id=\"p-search\" role=\"search\">" + 
								"	<h3><label for=\"searchInput\">Search</label></h3>" + 
								"	<form action=\"/w/index.php\" id=\"searchform\">" + 
								"				<div id=\"simpleSearch\">" + 
								"						<input name=\"search\" placeholder=\"Search\" title=\"Search Wiktionary [f]\" accesskey=\"f\" id=\"searchInput\" />						<button type=\"submit\" name=\"button\" title=\"Search the pages for this text\" id=\"searchButton\"><img src=\"//bits.wikimedia.org/static-1.22wmf4/skins/vector/images/search-ltr.png?303-4\" alt=\"Search\" width=\"12\" height=\"13\" /></button>								<input type='hidden' name=\"title\" value=\"Special:Search\"/>" + 
								"		</div>" + 
								"	</form>" + 
								"</div>" + 
								"				</div>" + 
								"			</div>" + 
								"			<div id=\"mw-panel\">" + 
								"					<div id=\"p-logo\" role=\"banner\"><a style=\"background-image: url(//upload.wikimedia.org/wiktionary/en/b/bc/Wiki.png);\" href=\"/wiki/Wiktionary:Main_Page\"  title=\"Visit the main page\"></a></div>" + 
								"				<div class=\"portal\" role=\"navigation\" id='p-navigation'>" + 
								"	<h3>Navigation</h3>" + 
								"	<div class=\"body\">" + 
								"		<ul>" + 
								"			<li id=\"n-mainpage-text\"><a href=\"/wiki/Wiktionary:Main_Page\">Main Page</a></li>" + 
								"			<li id=\"n-portal\"><a href=\"/wiki/Wiktionary:Community_portal\" title=\"About the project, what you can do, where to find things\">Community portal</a></li>" + 
								"			<li id=\"n-wiktprefs\"><a href=\"/wiki/Wiktionary:Per-browser_preferences\">Preferences</a></li>" + 
								"			<li id=\"n-requestedarticles\"><a href=\"/wiki/Wiktionary:Requested_entries\">Requested entries</a></li>" + 
								"			<li id=\"n-recentchanges\"><a href=\"/wiki/Special:RecentChanges\" title=\"A list of recent changes in the wiki [r]\" accesskey=\"r\">Recent changes</a></li>" + 
								"			<li id=\"n-randompage\"><a href=\"/wiki/Special:Random\" title=\"Load a random page [x]\" accesskey=\"x\">Random entry</a></li>" + 
								"			<li id=\"n-randompagebylanguage\"><a href=\"/wiki/Wiktionary:Random_page\">(by language)</a></li>" + 
								"			<li id=\"n-help\"><a href=\"/wiki/Help:Contents\" title=\"The place to find out\">Help</a></li>" + 
								"			<li id=\"n-sitesupport\"><a href=\"//donate.wikimedia.org/wiki/Special:FundraiserRedirector?utm_source=donate&amp;utm_medium=sidebar&amp;utm_campaign=C13_en.wiktionary.org&amp;uselang=en\" title=\"Support us\">Donations</a></li>" + 
								"			<li id=\"n-contact\"><a href=\"/wiki/Wiktionary:Contact_us\">Contact us</a></li>" + 
								"		</ul>" + 
								"	</div>" + 
								"</div>" + 
								"<div class=\"portal\" role=\"navigation\" id='p-tb'>" + 
								"	<h3>Toolbox</h3>" + 
								"	<div class=\"body\">" + 
								"		<ul>" + 
								"			<li id=\"t-whatlinkshere\"><a href=\"/wiki/Special:WhatLinksHere/Index:English/x\" title=\"A list of all wiki pages that link here [j]\" accesskey=\"j\">What links here</a></li>" + 
								"			<li id=\"t-recentchangeslinked\"><a href=\"/wiki/Special:RecentChangesLinked/Index:English/x\" title=\"Recent changes in pages linked from this page [k]\" accesskey=\"k\">Related changes</a></li>" + 
								"			<li id=\"t-upload\"><a href=\"//commons.wikimedia.org/wiki/Special:Upload\" title=\"Upload files [u]\" accesskey=\"u\">Upload file</a></li>" + 
								"			<li id=\"t-specialpages\"><a href=\"/wiki/Special:SpecialPages\" title=\"A list of all special pages [q]\" accesskey=\"q\">Special pages</a></li>" + 
								"			<li id=\"t-print\"><a href=\"/w/index.php?title=Index:English/x&amp;printable=yes\" rel=\"alternate\" title=\"Printable version of this page [p]\" accesskey=\"p\">Printable version</a></li>" + 
								"			<li id=\"t-permalink\"><a href=\"/w/index.php?title=Index:English/x&amp;oldid=16756295\" title=\"Permanent link to this revision of the page\">Permanent link</a></li>" + 
								"			<li id=\"t-info\"><a href=\"/w/index.php?title=Index:English/x&amp;action=info\">Page information</a></li>" + 
								"		</ul>" + 
								"	</div>" + 
								"</div>" + 
								"			</div>" + 
								"		</div>" + 
								"		<div id=\"footer\" role=\"contentinfo\">" + 
								"							<ul id=\"footer-info\">" + 
								"											<li id=\"footer-info-lastmod\"> This page was last modified on 2 May 2012, at 09:06.</li>" + 
								"											<li id=\"footer-info-copyright\">Text is available under the <a href=\"//creativecommons.org/licenses/by-sa/3.0/\">Creative Commons Attribution/Share-Alike License</a>; additional terms may apply.  By using this site, you agree to the <a href=\"//wikimediafoundation.org/wiki/Terms_of_Use\">Terms of Use</a> and <a href=\"//wikimediafoundation.org/wiki/Privacy_policy\">Privacy Policy.</a></li>" + 
								"									</ul>" + 
								"							<ul id=\"footer-places\">" + 
								"											<li id=\"footer-places-privacy\"><a href=\"//wikimediafoundation.org/wiki/Privacy_policy\" title=\"wikimedia:Privacy policy\">Privacy policy</a></li>" + 
								"											<li id=\"footer-places-about\"><a href=\"/wiki/Wiktionary:About\" title=\"Wiktionary:About\">About Wiktionary</a></li>" + 
								"											<li id=\"footer-places-disclaimer\"><a href=\"/wiki/Wiktionary:General_disclaimer\" title=\"Wiktionary:General disclaimer\">Disclaimers</a></li>" + 
								"											<li id=\"footer-places-mobileview\"><a href=\"http://en.m.wiktionary.org/wiki/Index:English/x\" class=\"noprint stopMobileRedirectToggle\">Mobile view</a></li>" + 
								"									</ul>" + 
								"										<ul id=\"footer-icons\" class=\"noprint\">" + 
								"					<li id=\"footer-copyrightico\">" + 
								"						<a href=\"//wikimediafoundation.org/\"><img src=\"//bits.wikimedia.org/images/wikimedia-button.png\" width=\"88\" height=\"31\" alt=\"Wikimedia Foundation\"/></a>" + 
								"					</li>" + 
								"					<li id=\"footer-poweredbyico\">" + 
								"						<a href=\"//www.mediawiki.org/\"><img src=\"//bits.wikimedia.org/static-1.22wmf4/skins/common/images/poweredby_mediawiki_88x31.png\" alt=\"Powered by MediaWiki\" width=\"88\" height=\"31\" /></a>" + 
								"					</li>" + 
								"				</ul>" + 
								"						<div style=\"clear:both\"></div>" + 
								"		</div>" + 
								"		<script>jQuery.ready();</script><script>if(window.mw){" + 
								"mw.loader.state({\"site\":\"loading\",\"user\":\"ready\",\"user.groups\":\"ready\"});" + 
								"}</script>" + 
								"<script>if(window.mw){" + 
								"mw.loader.load([\"mediawiki.action.view.postEdit\",\"mediawiki.user\",\"mediawiki.page.ready\",\"mediawiki.searchSuggest\",\"mediawiki.hidpi\",\"mobile.desktop\",\"ext.rtlcite\",\"mw.MwEmbedSupport.style\",\"ext.vector.collapsibleNav\",\"ext.vector.collapsibleTabs\",\"ext.navigationTiming\",\"mw.PopUpMediaTransform\",\"skins.vector.js\"],null,true);" + 
								"}</script>" + 
								"<script src=\"//bits.wikimedia.org/en.wiktionary.org/load.php?debug=false&amp;lang=en&amp;modules=site&amp;only=scripts&amp;skin=vector&amp;*\"></script>" + 
								"<!-- Served by mw1161 in 1.559 secs. -->" + 
								"	</body>" + 
								"</html>";
					#endregion
					break;
			}
			return wikiPage;
		}
	}
}
