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

        public static string ValidationNumber
        {
            get
            {
                return GetI18N("ValidationNumber");
            }
        }

        public static string ValidationDate
        {
            get
            {
                return GetI18N("ValidationDate");
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
                    return zh_cn;

                case "en-us":
                    return en_us;

                case "ja-jp":
                    return ja_jp;

                default:
                    return zh_tw;
            }
        }

        /*
         * 如果擔心執行緒 就使用 ConcurrentDictionary 吧
         */

        private static Dictionary<string, string> zh_tw = new Dictionary<string, string>
        {
            { "Hi", "嗨" },
            { "Name", "小名" },
            { "Required", "必要" },
            { "ValidationNumber", "跪求數字" },
            { "ValidationDate", "跪求日期" }
        };

        private static Dictionary<string, string> zh_cn = new Dictionary<string, string>
        {
            { "Hi", "这是你好" },
            { "Name", "这是姓名" },
            { "Required", "这是需要" },
            { "ValidationNumber", "跪求數字" },
            { "ValidationDate", "跪求日期" }
        };

        private static Dictionary<string, string> en_us = new Dictionary<string, string>
        {
            { "Hi", "Hi" },
            { "Name", "Name" },
            { "Required", "Required" },
            { "ValidationNumber", "Not a Number" },
            { "ValidationDate", "Not a Date" }
        };

        private static Dictionary<string, string> ja_jp = new Dictionary<string, string>
        {
            { "Hi", "ハイ" },
            { "Name", "ネーム" },
            { "Required", "必須" },
            { "ValidationNumber", "数字ではない" },
            { "ValidationDate", "日付ではない" }
        };
    }
}