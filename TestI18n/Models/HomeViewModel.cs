using System.ComponentModel.DataAnnotations;
using TestI18n.App_GlobalResources;

namespace TestI18n.Models
{
    public class HomeViewModel
    {
        [Display(Name = "Hi", ResourceType = typeof(I18N))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(I18N))]
        public string Hi { get; set; }

        [Display(Name = "Name", ResourceType = typeof(I18N))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(I18N))]
        public string Name { get; set; }
    }
}