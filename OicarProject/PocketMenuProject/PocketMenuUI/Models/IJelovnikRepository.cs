using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public interface IJelovnikRepository
    {
        IEnumerable<Meal> GetAllMeals();
        IEnumerable<Beverage> GetAllBeverages();
        IEnumerable<Meal> f(bool query,bool search);
        IEnumerable<Meal> fa(bool query);
    }
}