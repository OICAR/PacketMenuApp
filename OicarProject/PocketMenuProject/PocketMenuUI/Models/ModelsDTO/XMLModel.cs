using System.ComponentModel.DataAnnotations;

namespace PocketMenuUI.Models.ModelsDTO
{
    public class XMLModel
    {
        [Required]
        [MaxLength(50,ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Coordinates")]
        public string Coordinates { get; set; }

    }
}