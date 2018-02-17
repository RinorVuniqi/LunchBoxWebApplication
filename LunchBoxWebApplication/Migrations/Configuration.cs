using System.Collections.Generic;
using LunchBoxWebApplication.Models;
using Newtonsoft.Json;

namespace LunchBoxWebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LunchBoxWebApplication.Models.LunchBoxWebApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LunchBoxWebApplication.Models.LunchBoxWebApplicationContext context)
        {
            context.Categories.AddOrUpdate(
                new Category() {
                    CategoryId = new Constants().Category1Guid,
                    CategoryName = "Broodjes",
                    ImageUrl = "https://i.gyazo.com/53c9732d5d7ddd2c6930c280c0741d3d.png"
                },
                new Category() {
                    CategoryId = new Constants().Category2Guid,
                    CategoryName = "Salades, Pastas & Snacks",
                    ImageUrl = "https://i.gyazo.com/34588c393daf67de6d11b4e70813eaad.png"
                },
                new Category() {
                    CategoryId = new Constants().Category3Guid,
                    CategoryName = "Dessert & Ontbijt",
                    ImageUrl = "https://i.gyazo.com/bbbc74b660b2d6c61cd36959b8cb33bd.png"
                },
                new Category()
                {
                    CategoryId = new Constants().Category4Guid,
                    CategoryName = "Dranken",
                    ImageUrl = "https://i.gyazo.com/620cdf58213e034fda28cb102ae84430.png"
                });

            context.Subcategories.AddOrUpdate(
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory1Guid,
                    SubcategoryName = "Kaas",
                    CategoryId = new Constants().Category1Guid,
                    ImageUrl = "https://i.gyazo.com/dcb57ffbe1abcb79a1b041d051e73537.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory2Guid,
                    SubcategoryName = "Vis",
                    CategoryId = new Constants().Category1Guid,
                    ImageUrl = "https://i.gyazo.com/696e7727867ff08405bc6de8fbf79cf9.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory3Guid,
                    SubcategoryName = "Vlees",
                    CategoryId = new Constants().Category1Guid,
                    ImageUrl = "https://i.gyazo.com/42e96441e0073c3529fa601f53c1d190.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory4Guid,
                    SubcategoryName = "Kip",
                    CategoryId = new Constants().Category1Guid,
                    ImageUrl = "https://i.gyazo.com/ef7f85efe0561a167279a95dcff6a57c.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory5Guid,
                    SubcategoryName = "Panini's",
                    CategoryId = new Constants().Category2Guid,
                    ImageUrl = "https://i.gyazo.com/108f1afbe8b92fe3d4e63cc403138d75.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory6Guid,
                    SubcategoryName = "Salades",
                    CategoryId = new Constants().Category2Guid,
                    ImageUrl = "https://i.gyazo.com/cbd4c73d7e4f934334cde7f23110da86.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory7Guid,
                    SubcategoryName = "Pasta's",
                    CategoryId = new Constants().Category2Guid,
                    ImageUrl = "https://i.gyazo.com/75558717c726461ab7070fe03f2d5419.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory8Guid,
                    SubcategoryName = "Snacks",
                    CategoryId = new Constants().Category2Guid,
                    ImageUrl = "https://i.gyazo.com/50d9352a192bd73b0eac7389d58eaeae.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory9Guid,
                    SubcategoryName = "Dessert",
                    CategoryId = new Constants().Category3Guid,
                    ImageUrl = "https://i.gyazo.com/bbde00ac13f5a5a3aaeae7c1a628f0c8.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory10Guid,
                    SubcategoryName = "Ontbijt",
                    CategoryId = new Constants().Category3Guid,
                    ImageUrl = "https://i.gyazo.com/bbbc74b660b2d6c61cd36959b8cb33bd.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory11Guid,
                    SubcategoryName = "Warme dranken",
                    CategoryId = new Constants().Category4Guid,
                    ImageUrl = "https://i.gyazo.com/52e9e60f205c73e46149fcbd0eba0ffc.png"
                });

            context.Products.AddOrUpdate(
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kaas",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "kaas", "mayo", "sla", "ei", "komkommer", "wortel" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = "Eeaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    ProductPrice = 3.20m,
                    SubcategoryId = new Constants().Subcategory1Guid,
                    ProductOfTheWeek = true
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje brie",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "brie", "notenmengeling", "honing", "rucola" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.90m,
                    SubcategoryId = new Constants().Subcategory1Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje mozarella",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "mozarella", "tomaat", "zongedr. tomaat", "pesto", "rucola" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.70m,
                    SubcategoryId = new Constants().Subcategory1Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kruidenkaas",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "kruidenkaas", "rucola", "zongedr. tomaat" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.90m,
                    SubcategoryId = new Constants().Subcategory1Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje tonijn",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "tonijnsla", "sla", "wortel", "komkommer", "tomaat", "ei" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.40m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje tonijntino",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "tonijnsla", "martinosaus", "mosterd", "ansjovis", "sla", "tomaat", "komkommer", "ei" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.90m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje krab",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "krabsla", "sla", "komkommer", "tomaat", "ei" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.80m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje gerookte zalm",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "gerookte zalm", "ui", "sla", "mayo" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.50m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kruidenzalm",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "gerookte zalm", "kruidenkaas", "sla", "zongedr. tomaat" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.70m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kabeljauwsla",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "kabeljauwsla", "tomaat", "komkommer", "sla" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.60m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje ham",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "ham", "mayo", "sla", "tomaat", "ei", "komkommer", "wortel" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje smos",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "ham", "kaas", "mayo", "sla", "tomaat", "ei", "komkommer", "wortel" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.50m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje prepare",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "americain", "ui", "sla", "tomaat" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.10m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje martino",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "americain", "ui", "augurk", "martinosaus", "ansjovis", "mosterd" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.70m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje bicky",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "americain", "bickysaus", "geroosterde ui", "augurk", "sla", "tomaat" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.60m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje bacon pepper",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "americain", "verse ui", "pepersaus", "spek", "tomaat", "sla" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje salami",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "salami", "mayo", "sla", "tomaat", "wortel", "komkommer", "ei" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje serranoham",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "serranoham", "pesto", "permezaan", "rucola" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.00m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje pain de veau",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "vleesbrood", "sla", "tomaat", "komkommer", "mosterd" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.10m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje italiano",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "serranoham", "mozzarella", "pesto", "rucola", "zongedr. tomaat" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje vleessla",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "vleessla", "sla", "tomaat", "ei", "komkommer", "wortel" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje carrero",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "warme mexicano", "tomaat", "sla", "geroosterde ui", "bickysaus" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.50m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje vleesbrood spec.",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "vleesbrood", "spek", "kaas", "tomaat", "sla", "curryketchup", "mayo" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.60m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kip maison",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "gebakken kip", "spek", "sla", "tomaat", "geroosterde uitjes", "giantsaus" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 4.20m,
                    SubcategoryId = new Constants().Subcategory4Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kip curry",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "kip curry", "sla", "tomaat", "wortel", "komkommer" }),
                    ImageUrl = "https://i.gyazo.com/4a51fd5f473a09418ea1cbbe5c2d015c.png",
                    ProductDescription = null,
                    ProductPrice = 3.30m,
                    SubcategoryId = new Constants().Subcategory4Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Panini kaas & ham",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "ham", "kaas", "tomaat" }),
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.20m,
                    SubcategoryId = new Constants().Subcategory5Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Panini gerookte zalm",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "zalm", "kruidenkaas", "tomaat" }),
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory5Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Panini serranoham",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "serranoham", "pesto", "rucola", "mozarella", "zongedr. tomaat" }),
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.60m,
                    SubcategoryId = new Constants().Subcategory5Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Panini drie kazen",
                    IngredientsBlobbed = JsonConvert.SerializeObject(new List<string>() { "jonge kaas", "mozarella", "brie", "pesto", "tomaat", "zongedr. tomaat", "basilicum" }),
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.60m,
                    SubcategoryId = new Constants().Subcategory5Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Groentensalade",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.50m,
                    SubcategoryId = new Constants().Subcategory6Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Salade met kip",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 8.00m,
                    SubcategoryId = new Constants().Subcategory6Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Salade met gerookte zalm",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 9.00m,
                    SubcategoryId = new Constants().Subcategory6Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Salade met mozarella",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 8.00m,
                    SubcategoryId = new Constants().Subcategory6Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta bolognaise (S)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta bolognaise (M)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta bolognaise (L)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 7.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta carbonara (S)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta carbonara (M)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta carbonara (L)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 7.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta arrabiata (S)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta arrabiata (M)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta arrabiata (L)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 7.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta vier kazen (S)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta vier kazen (M)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta vier kazen (L)",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 7.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Worstenbroodje",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.20m,
                    SubcategoryId = new Constants().Subcategory8Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Droge worst",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 1.20m,
                    SubcategoryId = new Constants().Subcategory8Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Donut",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 1.40m,
                    SubcategoryId = new Constants().Subcategory9Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Rijsttaartje",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.00m,
                    SubcategoryId = new Constants().Subcategory9Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Chocoladekoek",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 1.20m,
                    SubcategoryId = new Constants().Subcategory10Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Croissant",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 1.20m,
                    SubcategoryId = new Constants().Subcategory10Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Ontbijt-Box",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory10Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Thee",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.20m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Koffie",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.20m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Deca koffie",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.20m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Cappuccino",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.50m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Macchiato",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.50m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Warme chocolademelk",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.50m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Take away dagsoep 1/2 l.",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.00m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Take away dagsoep 1 l.",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.80m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Take a seat dagsoep",
                    IngredientsBlobbed = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.00m,
                    SubcategoryId = new Constants().Subcategory11Guid
                });
        }
    }
}