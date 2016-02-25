using System;
using System.ComponentModel.DataAnnotations;

namespace TestI18n.Models
{
    public class HomeViewModel
    {
        [Display(Name = "Hi", ResourceType = typeof(CustomizedI18N))]
        [I18nRequired]
        public string Hi { get; set; }

        [Display(Name = "Name", ResourceType = typeof(CustomizedI18N))]
        [I18nRequired]
        public string Name { get; set; }

        /*
         * 你以為有 ValidationAttribute 世界就很和平的時候
         * 大魔王就登場了 int DateTime
         */

        public int Point { get; set; }

        public DateTime Someday { get; set; }
    }
}