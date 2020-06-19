﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PocketMenuUI.ViewModel;

namespace PocketMenuUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController
        (RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        // GET
       
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole 
        role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}