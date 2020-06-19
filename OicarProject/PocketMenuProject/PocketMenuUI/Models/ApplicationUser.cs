using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace PocketMenuUI.Models
{
    public  class ApplicationUser : IdentityUser
    {
        //Ode dodati ako nesto pri registraciji ili u profilu.
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public string PhotoPath { get; set; }
       
        [NotMapped]
        public IFormFile Photo { get; set; }
        
        public bool SaladFilter { get; set; }
        
      //  public string RoleName { get; set; }

    }
    
    
 
}