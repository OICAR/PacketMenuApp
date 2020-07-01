﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PocketMenuUI.Data;

namespace PocketMenuUI.Models
{
    public class SQLRepository : IJelovnikRepository
    {
        private readonly JelovnikDbContext _context;
        private readonly UserManager<ApplicationUser>
            _userManager;
        public SQLRepository(JelovnikDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public bool SaladFilter { get; set; }
        public IEnumerable<Article> GetAllMeals()
        {
            return _context.Meals;
        }

        public IEnumerable<Beverage> GetAllBeverages()
        {
            return _context.Beverages;
        }
        public IEnumerable<Article> f(bool query,bool search)
        {
            if (query==true )
            {
                var model = _context.Meals.Where(b =>
                    b.Title.Contains("Salad"));
                return model;
            }
            if  (search==true )
            {
                var model = _context.Meals.Where(b =>
                    b.Title.Contains("Pizza"));
                return model;
            }
            else
            {
                return _context.Meals;
            }
                
           
        }

        public IEnumerable<Article> fa(bool query)
        { 
           
            if (query==true )
            {
                var model = _context.Meals.Where(b =>
                    b.Title.Contains("Salad"));
                return model;
            }
            
            return _context.Meals;
        }
        private async Task LoadAsync(ApplicationUser user)
        {

           
            var userName =
                await _userManager.GetUserNameAsync(user);
            var phoneNumber =
                await _userManager
                    .GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
             SaladFilter= user.SaladFilter;
     
        }
/*        public async Task<IActionResult> OnGetAsync()
        {
            var user =
                await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(
                    $"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }*/
    }
}