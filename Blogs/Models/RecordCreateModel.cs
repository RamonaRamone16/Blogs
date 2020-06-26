using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class RecordCreateModel
    {
        [Required(ErrorMessage = "Введите заголовок поста")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Введите содержание поста")]
        [StringLength(2500, MinimumLength = 20, ErrorMessage = "Мин. количество символов - 20")]
        public string Content { get; set; }
    }
}
