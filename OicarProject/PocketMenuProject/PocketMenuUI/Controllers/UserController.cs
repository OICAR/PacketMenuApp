using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PocketMenuUI.Models;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.Services;

namespace PocketMenuUI.Controllers
{
    public class UserController : Controller
    {

        private  new readonly User user;
        private readonly IMapper _mapper;
        private readonly IUsers _service;
        private readonly UserManager<ApplicationUser>
            _userManager;

        public UserController(IMapper mapper, IUsers service, UserManager<ApplicationUser> userManager)
        {


            user = new User();
            user.EatingHabits = new Dictionary<string, bool>();
            user.EatingHabits.Add("SVE", false);
            user.EatingHabits.Add("VEGETARIAN", false);
            user.EatingHabits.Add("VEGAN", true);
            user.EatingHabits.Add("CHRON ", false);
            user.EatingHabits.Add("DIJABETES", false);
            user.EatingHabits.Add("CELIJAKIJA  ", false);
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

            _service = service;
            _userManager = userManager;
        }
        

        [HttpGet]
        public  IActionResult Create()
        { 
            var users =
                _userManager.GetUserId(User);
            
            //Read Cookie
            //string key = users;
            //var cookieValue = JsonConvert
            //.DeserializeObject<UserDTO>(Request
            //.Cookies[key]);
            //cookieValue.EatingHabits.Add(cookieValue
            //    .ToString());
            //var userInfo = JsonConvert
            //    .DeserializeObject(HttpContext.Session
            //        .GetString("SessionUser"));
            return View(user);
        }

        [HttpPost]
        public  IActionResult Create(User users )
        {
            var user =
                 _userManager.GetUserId(User);
            /*
            HttpContext.Session.SetString("SessionUser",
            JsonConvert.SerializeObject(user));
            */
            HttpContext.Session.SetString("SessionUser",
                JsonConvert.SerializeObject(user));

            users.UserID = user;

            UserDTO userDto = _mapper.Map<UserDTO>(users);
            _service.PostUser(userDto);
            
            var value =
                JsonConvert.SerializeObject(userDto);
            string key = user;
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append(key, value,
            cookieOptions);
            ////spremiti ID korisnika u cookie/session, izbor korisnika

            return RedirectToAction("Index","Home");
        }





    }
}