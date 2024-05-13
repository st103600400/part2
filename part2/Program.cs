using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeBook recipeBook = new RecipeBook();

            while (true)
            {
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display a recipe");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipeBook.EnterDetails();
                        break;
                    case 2:
                        recipeBook.DisplayAll();
                        break;
                    case 3:
                        recipeBook.DisplayRecipe();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    class RecipeBook
    {
        private List<Recipe> recipes = new List<Recipe>();

        public void EnterDetails()
        {
            Console.Write("Enter the recipe name: ");
            string recipeName = Console.ReadLine();
            Recipe recipe = new Recipe(recipeName);

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Calories: ");
                int calories = int.Parse(Console.ReadLine());
                Console.Write("Food group: ");
                string foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient(name, calories, foodGroup);
                recipe.AddIngredient(ingredient);
            }

            recipes.Add(recipe);
            Console.WriteLine("Recipe details entered successfully!");
        }

        public void DisplayAll()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("All Recipes:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        public void DisplayRecipe()
        {
            Console.Write("Enter the recipe name: ");
            string recipeName = Console.ReadLine();
            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                Console.WriteLine($"Recipe: {recipe.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
                }
            }
            else
            {
                Console.WriteLine($"Recipe '{recipeName}' not found.");
            }
        }
    }

    class Recipe
    {
        public string Name { get; private set; }
        public List<Ingredient> Ingredients { get; private set; } = new List<Ingredient>();

        public Recipe(string name)
        {
            Name = name;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }
    }

    class Ingredient
    {
        public string Name { get; private set; }
        public int Calories { get; private set; }
        public string FoodGroup { get; private set; }

        public Ingredient(string name, int calories, string foodGroup)
        {
            Name = name;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}