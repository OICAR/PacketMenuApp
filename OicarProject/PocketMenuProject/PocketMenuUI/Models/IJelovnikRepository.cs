using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public interface IJelovnikRepository
    {
        IEnumerable<Article> GetAllMeals();
        IEnumerable<Beverage> GetAllBeverages();
        IEnumerable<Article> f(bool query,bool search);
        IEnumerable<Article> fa(bool query);
    }
}