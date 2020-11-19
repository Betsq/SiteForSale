using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySouthKoreaSiteMVC.Models
{
    public class Cosmetic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public string PurposeFor { get; set; } //Преназначение для (Глаз, губ и т.д.)
        public string Means { get; set; } //Средство (тональный крем, тени, блески и т.д.) 


    }
}
