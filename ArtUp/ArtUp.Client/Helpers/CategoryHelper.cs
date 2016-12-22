using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtUp.Client.Helpers
{
    public static class CategoryHelper
    {
        public static MvcHtmlString ToRusName(this HtmlHelper helper, string category)
        {
            string result = string.Empty;
            switch (category)
            {
                case "music":
                    result = "Музыка";
                    break;
                case "literature":
                    result = "Литература";
                    break;
                case "movie":
                    result = "Кино и видео";
                    break;
                case "photo":
                    result = "Фотография";
                    break;
                case "art":
                    result = "Живопись";
                    break;
                case "new":
                    result = "Новые проекты";
                    break;
                case "all":
                    result = "Все проекты";
                    break;
                case "best":
                    result = "Успешные проекты";
                    break;
            }
            return new MvcHtmlString(result);
        }
    }
}