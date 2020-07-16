using PocketMenuUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
  public interface IItem
    {

        Task<string> PostItem(List<Item> caterer);

    }
}
