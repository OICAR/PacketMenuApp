using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PocketMenuUI.Models;
using PocketMenuUI.ViewModel;

namespace PocketMenuUI.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser>
            _userManager;

        private readonly SignInManager<ApplicationUser>
            _signInManager;

        private readonly IWebHostEnvironment _hostEnvironment;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
             IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostEnvironment = hostEnvironment;
        }

        public string Username { get; set; }
        public string PhotoPath { get; set; }

        [TempData] public string StatusMessage { get; set; }

        [BindProperty] public InputModel Input { get; set; }

        public class InputModel
        {        

            [Display(Name = "Photo")]
            public IFormFile Photo { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
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
            Username = userName;
            PhotoPath = user.PhotoPath;
            
            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName= firstName,
                LastName = lastName,
       
               
            };
        }

        public async Task<IActionResult> OnGetAsync()
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
        }

        public async Task<IActionResult> OnPostAsync
        ( )
        {
            var user =
                await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(
                    $"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber =
                await _userManager
                    .GetPhoneNumberAsync(user);
            var file = Input.Photo;
            //nacin na koji se podaci editaju
            if (file !=null && file.Length>0)
            {
                var uploadPath =Path.Combine(
                    _hostEnvironment.WebRootPath ,"img");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var uniqeFileName =
                    Guid.NewGuid().ToString() + "_"+ file.FileName;

                var filePath = Path.Combine
                                   (uploadPath, uniqeFileName);
                file.CopyTo(new FileStream(filePath,FileMode.Create));
   
                user.PhotoPath = uniqeFileName;
            }
          
            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }
            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }

            await _userManager.UpdateAsync(user);
            if (Input.PhoneNumber != phoneNumber )
            {
                var setPhoneResult =
                    await _userManager.SetPhoneNumberAsync(
                        user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage =
                        "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            

            await _signInManager.RefreshSignInAsync(
                    user);
                //StatusMessage =
                //    "Your profile has been updated";
                return RedirectToPage();
            }
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
        }
    }