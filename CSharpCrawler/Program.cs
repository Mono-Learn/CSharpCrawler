using CSharpCrawler.Repositories;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CSharpCrawler.Models;
using ScrapySharp.Core;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace CSharpCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var websitesLinks = new List<string>()
            {
               "http://www.google.com",
               "http://www.microsoft.com",
               "http://www.apple.com",
            };

            foreach (var link in websitesLinks)
            {
                StartCrawlerAsync(link).Wait();
            }


            var documentRepository = new DocumentRepository();
            var doc = documentRepository.GetById(1);

            Console.WriteLine(doc.Body);

            Console.ReadLine();
        }

        private static async Task StartCrawlerAsync(string url)
        {
            var httpClient = new HttpClient();
            try
            {
                var html = await httpClient.GetStringAsync(url);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var documentRepository = new DocumentRepository();
                var document = new Document()
                {
                    Title = htmlDocument.DocumentNode.SelectSingleNode("//title").InnerText,
                    Body = htmlDocument.Text
                };

                //TODO : Get data with css selectors
                //htmlDocument.DocumentNode.CssSelect(".hello");

                documentRepository.Create(document);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
