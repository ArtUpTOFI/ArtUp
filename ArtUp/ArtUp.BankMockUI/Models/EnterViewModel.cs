using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtUp.BankMockUI.Models
{
    public class EnterViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите номер счета")]
        [Display(Name = "Номер счета")]
        [RegularExpression(@"([0-9]{13})", ErrorMessage = "Некорректный номер. Счет должен содержать 13 символом и содержать только цифры")]
        public string Number { get; set; }
    }
}