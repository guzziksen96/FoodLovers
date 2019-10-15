using System.Collections.Generic;
using RecipeScarper.Models;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace RecipeScarper.Scrapers
{
    public class AllRecipesScraper
    {
        private readonly string allRecipesUrl = @"https://www.allrecipes.com/recipes/";
        private HtmlWeb web = new HtmlWeb();
        public List<RecipeModel> ScrapRecipe()
        {
            var result = new List<RecipeModel>();
          
            var htmlDoc = web.Load(allRecipesUrl);

            var css = @"#insideScroll  > ul li a"; 

            var recipesPerCategory = htmlDoc.DocumentNode.QuerySelectorAll(css);

            var allUrlsPerCategory = new List<string>();
            foreach (var recipe in recipesPerCategory)
            {
                var hrefValue = recipe.GetAttributeValue("href", string.Empty);
                allUrlsPerCategory.Add(hrefValue);
            }

            var allRecipeUrls = new List<string>();

            foreach (var url in allUrlsPerCategory)
            {
                var htmlCategoryDoc = web.Load(url);
                var anchor = @".fixed-recipe-card .grid-card-image-container a";
                var recipesPages = htmlCategoryDoc.DocumentNode.QuerySelectorAll(anchor);

                foreach (var recipePage in recipesPages)
                {
                    var hrefValue = recipePage.GetAttributeValue("href", string.Empty);
                    allRecipeUrls.Add(hrefValue);
                }
                
            }

            foreach (var recipeUrl in allRecipeUrls)
            {
                    var htmlRecipeDoc = web.Load(recipeUrl);

                    var idToGetTitle = "recipe-main-content";
                    var titleNode = htmlRecipeDoc.DocumentNode.SelectSingleNode("//h1[@id='" + idToGetTitle + "']");
                    if (titleNode==null)
                        continue;
                    var title = titleNode.InnerText;

                    var classToGetPrepTime = "prepTime__item--time";
                    var prepTimeNode = htmlRecipeDoc.DocumentNode.SelectSingleNode("//span[@class='" + classToGetPrepTime + "']");
                    if (prepTimeNode == null)
                        continue;
                    var prepTime = prepTimeNode.InnerText;

                    var ingredients = new List<IngredientModel>();
                    var classToIngredients = "recipe-ingred_txt added";
                    var ingredientNodes = htmlRecipeDoc.DocumentNode.SelectNodes("//span[@class='" + classToIngredients + "']");
                    if (ingredientNodes == null)
                        continue;
                    foreach (var node in ingredientNodes)
                    {
                        var ingredient = node.InnerText;
                        ingredients.Add(new IngredientModel
                        {
                            Name = ingredient
                        });
                    }

                    var directions = new System.Text.StringBuilder();
                    var classToGetDirections = "recipe-directions__list--item";
                    var directionsNodes = htmlRecipeDoc.DocumentNode.SelectNodes("//span[@class='" + classToGetDirections + "']");
                    if (directionsNodes == null)
                        continue;
                    foreach (var node in directionsNodes)
                    {
                        directions.Append(node.InnerText);
                    }

                    var recipeModel = new RecipeModel
                    {
                        Name = title,
                        PreparationTimeInMinutes = prepTime,
                        Ingredients = ingredients,
                        Directions = directions.ToString()

                    };

                    result.Add(recipeModel);
                
            }

            return result;
        }

    }
}
