using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySouthKoreaSiteMVC.Models
{
    public class Cosmetic
    {
        public int Id { get; set; }
        [Display(Name = "Название товара")]
        public string Name { get; set; }
        [Display(Name = "Путь к картинке товара")]
        public string Img { get; set; }
        [Display(Name = "Брэнд")]
        public string Brand { get; set; }
        [Display(Name = "Цена")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Price { get; set; }
        [Display(Name = "Описания")]
        public string Description { get; set; }
        [Display(Name = "Преназначение")]
        public string PurposeFor { get; set; } //Преназначение для (Глаз, губ и т.д.)
        [Display(Name = "Вид средства")]
        public string Means { get; set; } //Средство/Вид (тональный крем, тени, блески и т.д.)
        [Display(Name = "Цвет")]
        public string Color { get; set; }
        [Display(Name = "Объем")]
        public int Volume { get; set; } //Объем
        [Display(Name = "Состав товара")]
        public string CompositionGoods { get; set; } //Состав товара
        [Display(Name = "Показывать товар на главной странице?")]
        public bool ShowMainScreen { get; set; }//Показывать на главной странице или нет.
    }
}
