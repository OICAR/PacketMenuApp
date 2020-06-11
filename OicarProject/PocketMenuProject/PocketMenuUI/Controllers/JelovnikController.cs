﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PocketMenuUI.Models;

namespace PocketMenuUI.Controllers
{
    public class JelovnikController : Controller
    {
        // GET
        private readonly IJelovnikRepository
            _employeeRepository;

        private readonly UserManager<ApplicationUser>
            _userManager;

        public JelovnikController(
            IJelovnikRepository employeeRepository,
            UserManager<ApplicationUser> userManager)
        {
            _employeeRepository = employeeRepository;
            _userManager = userManager;
        }
        public bool SaladFilter { get; set; }

        [HttpPost]
        public async Task<IActionResult> Index(
            bool searchQuery)

        {
            /*List<Meal> meals = new List<Meal> {
            new Meal("Spaghetti bolognes","Spaghetti, bolognese sauce, meat",35.00),
            new Meal("Salad", "Onions, tomatoes, turnips",18.00),
            new Meal("Pizza", "Cheese, ham, tomato sauce",18.00) };

             meals.Where(b =>
                    b.Title.Equals("Salad"));
            
            List<Beverage> drinks = new List<Beverage> {
            new Beverage("Coca-Cola",15.00),
            new Beverage("Water",10.00),
            new Beverage("Sprite",15.00) };*/

            var user =
                await _userManager.GetUserAsync(User);
            if (searchQuery != user.SaladFilter)
            {
                user.SaladFilter = searchQuery;
            }

            await _userManager.UpdateAsync(user);

            var model = _employeeRepository.fa
                (searchQuery);
          
            return View(model);
        }
        private async Task LoadAsync(ApplicationUser 
        user,bool query)
        {

           
 
            query = user.SaladFilter;
    
        }
        
       
        [HttpGet]
        public async Task<IActionResult> Index()
        {   
            var user =
                await _userManager.GetUserAsync(User);
        
        
            bool searchQuery = user.SaladFilter;
            
            
            await LoadAsync(user,searchQuery);
            var model = _employeeRepository.fa
                (searchQuery);

            return View(model);
        }
    }
}