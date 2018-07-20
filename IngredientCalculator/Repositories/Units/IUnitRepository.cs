using System.Collections.Generic;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.Units
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetUnits();
        void AddUnit(Unit unit);
        void UpdateUnit(Unit unit);
        void DeleteUnit(int id);
    }
}