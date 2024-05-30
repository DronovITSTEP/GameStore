using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите ваше имя")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Укажите первый адрес доставки")]
        [Display(Name = "Первый адрес доставки")]
        public string Line1 { get; set; }
        [Display(Name = "Второй адрес доставки")]
        public string Line2 { get; set; }
        [Display(Name = "Третий адрес доставки")]
        public string Line3 { get; set; }

        [Display(Name = "Город")]
        [Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Укажите страну")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
