using System;
using IngredientCalculator.Repositories.Ingredients;
using IngredientCalculator.Repositories.RecipeCosts;
using IngredientCalculator.Repositories.RecipeIngredients;
using IngredientCalculator.Repositories.Recipes;

namespace IngredientCalculator.Factories
{
    public static class RepositoryFactory
    {
        public static IIngredientRepository GetIngredientRepository(string repo)
        {
            switch (repo)
            {
                case "Sql":
                    return new IngredientSqlRepository();
                case "Fake":
                    return new FakeIngredientRepository();
                default:
                    throw new ArgumentException("Not a valid repository");
            }
        }

        public static IRecipeRepository GetRecipeRepository(string repo)
        {
            switch (repo)
            {
                case "Sql":
                    return new RecipeSqlRepository();
                case "Fake":
                    return new FakeRecipeRepository();
                default:
                    throw new ArgumentException("Not a valid repository");
            }
        }

        public static IRecipeIngredientsRepository GetRecipeIngredientsRepository(string repo)
        {
            switch (repo)
            {
                case "Sql":
                    return new RecipeIngredientsSqlRepository();
                case "Fake":
                    return new FakeRecipeIngredientsRepository();
                default:
                    throw new ArgumentException("Not a valid repository");
            }
        }

        public static IRecipeCostsRepository GetRecipeCostsRepository(string repo)
        {
            switch (repo)
            {
                case "Sql":
                    return new RecipeCostSqlRepository();
                case "Fake":
                    return new FakeRecipeCostRepository();
                default:
                    throw new ArgumentException("Not a valid repository");
            }
        }
    }
}

/* 
 * Alternate to this is by configuration
 * 
 *      public static IPersonRepository GetRepository()
        {
            string typeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(typeName);
            object repoInstance = Activator.CreateInstance(repoType);
            IPersonRepository repo = repoInstance as IPersonRepository;
            return repo;
        }
 * 
 * 
 * 
 */
