using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;
using HtmlAgilityPack;

public class Program
{
    public static void Main()
    {
        //ScrapeOtoDom();
        ScrapeTrojmiasto();


        Console.ReadKey();

    }


    static void ScrapeTrojmiasto()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load("https://ogloszenia.trojmiasto.pl/nieruchomosci-mam-do-wynajecia/");

        foreach (HtmlNode node in document.DocumentNode.SelectNodes("//div[contains(@class,'list__item list--item')]"))
        {
            var item_title = node.SelectSingleNode("div/div/h2/a");
            var item_price = node.SelectSingleNode("div/div/div/p[@class='list__item__price__value']").InnerHtml;
            var item_link = item_title.Attributes["href"].Value;

            Console.WriteLine(item_title.Attributes["title"].Value);
            Console.WriteLine(item_price);
            Console.WriteLine(item_link);

            Console.WriteLine("-------------------------");
        }

    }


    static void ScrapeOtoDom()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load("https://www.otodom.pl/wynajem/mieszkanie/gdansk/?search%5Bdescription%5D=1&search%5Bdist%5D=15&search%5Bsubregion_id%5D=439&search%5Bcity_id%5D=40#form");

        //OtoDom Scrape Prototype

        foreach (HtmlNode node in document.DocumentNode.SelectNodes("//article[contains(@class,'offer-item')]"))
        {

            var item_details = node.SelectSingleNode("div[@class='offer-item-details']");

            var item_price = item_details.SelectSingleNode("ul/li[@class='offer-item-price']").InnerHtml.Trim();

            var item_header = item_details.SelectSingleNode("header");

            var metraz = item_header.SelectSingleNode("h3/a/strong").InnerHtml;

            var title = item_header.SelectSingleNode("h3/a/span/span[@class='offer-item-title']").InnerHtml;

            var littleTitle = item_header.SelectSingleNode("p").InnerHtml;

            Console.WriteLine(title);
            Console.WriteLine(littleTitle);
            Console.WriteLine(metraz);
            Console.WriteLine(item_price);

            Console.WriteLine("-------------------------");

        }
    }

}