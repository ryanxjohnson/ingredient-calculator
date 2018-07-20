using IngredientCalculator.Repositories.Ingredients;
using NUnit.Framework;
using Rhino.Mocks;

namespace IngredientCalculatorTests.RepositoryTests
{
    [TestFixture]
    public class IngredientRepositoryTests
    {
        [Test]
        public void TestMethod1()
        {
            var mock = MockRepository.GenerateStub<IIngredientRepository>();
        }
    }
}
