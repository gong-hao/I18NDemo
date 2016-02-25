using System.ComponentModel.DataAnnotations;

namespace TestI18n.Models
{
    public class I18nRequired : RequiredAttribute
    {
        public I18nRequired()
        {
            this.ErrorMessageResourceName = "Required";

            this.ErrorMessageResourceType = typeof(CustomizedI18N);
        }
    }
}