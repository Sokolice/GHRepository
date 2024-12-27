using HtmlAgilityPack;
using System;
using System.Xml.Linq;

namespace API_Recipes
{
    public class ApetiteParser
    {
        public static List<Recipe> GetRecipesByIngredient(string aIngredient)
        {

            var recipes= new List<Recipe>();

            var url = "https://www.apetitonline.cz/vyhledavani?keys=" + aIngredient;

            

            HttpClient client = new HttpClient();
            var html = client.GetStringAsync(url);

            var htmldoc = new HtmlDocument();
            htmldoc.LoadHtml(html.Result);

            var liElements = htmldoc.DocumentNode.Descendants("article").Where(a=> a.HasClass("content_recipe")).ToList(); //.Where(x => x.Attributes["data-testid"].Value == "recipe-block-item").ToList();

            foreach ( var liElement in liElements )
            {
               var name = liElement.Descendants("a").FirstOrDefault(a => a.HasClass("a-teaser__link")).Attributes["title"].Value;
               var urlLi = liElement.Descendants("a").FirstOrDefault(a => a.HasClass("a-teaser__link")).Attributes["href"].Value;
               var imgSrc = liElement.Descendants("img").FirstOrDefault().Attributes["src"].Value;

                recipes.Add(new Recipe
                {
                    ImageSrc = "https://www.apetitonline.cz" + imgSrc,
                    Name = name,
                    Url = "https://www.apetitonline.cz" +urlLi
                });

            }


            return recipes;
        }


    }
}