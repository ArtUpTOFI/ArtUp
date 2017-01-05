using ArtUp.BankMockServer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtUp.BankMockUI.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер счета")]
        public string Nubmer { get; set; }

        [Display(Name = "Тип")]
        public AccountType Type { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string PatronomicName { get; set; }

        [Display(Name = "Адресс")]
        public string Adress { get; set; }

        [Display(Name = "Сумма")]
        public float Money { get; set; }
    }
}