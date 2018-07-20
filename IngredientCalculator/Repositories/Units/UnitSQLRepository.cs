using System.Collections.Generic;
using IngredientCalculator.Models;
using IngredientCalculator.Services.Units;

namespace IngredientCalculator.Repositories.Units
{
    public class UnitSqlRepository : IUnitRepository
    {
        public IEnumerable<Unit> GetUnits()
        {
            return UnitDataService.GetUnits();
        }

        public void AddUnit(Unit unit)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUnit(Unit unit)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUnit(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}