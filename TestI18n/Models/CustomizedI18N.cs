using System.Collections.Generic;

namespace TestI18n.Models
{
    public class CustomizedI18N
    {
        /*
         * 符合 public static string { get; } 即可
         */

        public static string Hi
        {
            get
            {
                return GetI18N("Hi");
            }
        }

        public static string Name
        {
            get
            {
                return GetI18N("Name");
            }
        }

        public static string Required
        {
            get
            {
                return GetI18N("Required");
            }
        }

        private static string GetI18N(string key)
        {
            var dictionary = GetDictionary();

            string value;

            var hasValue = dictionary.TryGetValue(key, out value);

            return value;
        }

        private static Dictionary<string, string> GetDictionary()
        {
            var lang = System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToLower();

            switch (lang)
            {
                case "zh-tw":
                    return zh_tw;

                case "zh-cn":
                    return zh_tw;

                case "en-us":
                    return zh_tw;

                case "ja-jp":
                    return zh_tw;

                default:
                    return zh_tw;
            }
        }

        /*
         * 如果擔心執行緒 就使用 ConcurrentDictionary 吧
         */

        private static Dictionary<string, string> zh_tw = new Dictionary<string, string>
        {
            { "Hi", "嗨_Customized" },
            { "Name", "小名_Customized" },
            { "Required", "必要_Customized" }
        };

        private static Dictionary<string, string> zh_cn = new Dictionary<string, string>
        {
            { "Hi", "这是你好_Customized" },
            { "Name", "这是姓名_Customized" },
            { "Required", "这是需要_Customized" }
        };

        private static Dictionary<string, string> en_us = new Dictionary<string, string>
        {
            { "Hi", "Hi_Customized" },
            { "Name", "Name_Customized" },
            { "Required", "Required_Customized" }
        };

        private static Dictionary<string, string> ja_jp = new Dictionary<string, string>
        {
            { "Hi", "ハイ_Customized" },
            { "Name", "ネーム_Customized" },
            { "Required", "必須_Customized" }
        };
    }
}