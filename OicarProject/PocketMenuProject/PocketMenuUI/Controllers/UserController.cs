using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocketMenuUI.Models;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.Services;

namespace PocketMenuUI.Controllers
{
    public class UserController : Controller
    {

        private  new readonly User User;
        private readonly IMapper _mapper;
        private readonly IUsers _service;

        public UserController(IMapper mapper, IUsers service)
        {


            User = new User();
            User.EatingHabits = new Dictionary<string, bool>();
            User.EatingHabits.Add("SVE", false);
            User.EatingHabits.Add("VEGETARIAN", false);
            User.EatingHabits.Add("VEGAN", true);
            User.EatingHabits.Add("CHRON ", false);
            User.EatingHabits.Add("DIJABETES", false);
            User.EatingHabits.Add("CELIJAKIJA  ", false);

            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

            _service = service;


        }
        

        [HttpGet]
        public IActionResult Create()
        {


            return View(User);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            UserDTO userDto = _mapper.Map<UserDTO>(user);

            _service.PostUser(userDto);

            return RedirectToAction("Index",
                "Home");
        }


        //[HttpPost]
        //public IActionResult AddEatingHabit(UserDTO user)
        //{

        //    User.EatingHabits.Add(user.newEatingHabbit, true);

        //    return RedirectToAction("Create", User);
             
        //}




    }
}