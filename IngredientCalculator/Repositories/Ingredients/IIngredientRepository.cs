namespace IngredientCalculator.Repositories.Ingredients
{
    public interface IIngredientRepository : IIngredient
    {
        // perhaps add some statistics
        int GetNumberOfIngredients();
    }
}