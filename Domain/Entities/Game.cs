using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите описание")]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Укажите цену")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public int CategoryID {  get; set; }
        public virtual Category Category {  get; set; }
    }
}
