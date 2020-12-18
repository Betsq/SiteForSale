using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace BeautySouthKoreaSiteMVC.Util
{
    public class SelectListItemHelper
    {
        public static IEnumerable<SelectListItem> GetPurposeList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "SS", Value = "SS"},
                new SelectListItem{Text = "Глаз", Value = "Глаз"},
                new SelectListItem{Text = "Ногтей", Value = "Ногтей"},
                new SelectListItem{Text = "Губ", Value = "Губ"},
                new SelectListItem{Text = "Снятие макияжа", Value = "Снятие макияжа"}
            };
            return items;
        }

        public static IEnumerable<SelectListItem> GetMeansList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Тональный средство", Value = "Тональный средство"},
                new SelectListItem{Text = "Туши для рестниц", Value = "Туши для рестниц"},
                new SelectListItem{Text = "Подводки для глаз", Value = "Подводки для глаз"},
                new SelectListItem{Text = "Тени", Value = "Тени"},
                new SelectListItem{Text = "Помада", Value = "Помада"}
            };
            return items;
        }
    }
}
