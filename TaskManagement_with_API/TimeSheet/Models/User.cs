using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class User
    {

        /*------------------ Error Message ları validasyon mesajları olarak girin , asp-validation-for da kullanacağız size bırakıyorum bu tarafı veya client-side validation
         yapılabilir FluentValidation vs ------------------*/

        [Key]
        public string username { get; set; }
        [MaxLength(110)]
        public string mail { get; set; }
        [MaxLength(200)]
        public string password { get; set; }
    }
}
