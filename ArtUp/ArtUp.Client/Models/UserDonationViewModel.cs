using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class UserDonationViewModel
    {
        public string Email { get; set; }

        public DateTime DonationDate { get; set; }

        [Required(ErrorMessage = "Сумма пожертвования является обязательным полем")]
        [Display(Name = "Сумма пожертвования")]
        [Range(1, 1000000, ErrorMessage = "Некорректная сумма пожертвования")]
        public decimal Amount { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public int? GiftId { get; set; }

        [Required(ErrorMessage = "Держатель карты является обязательным полем")]
        [Display(Name = "Держатель карты")]
        [StringLength(30, ErrorMessage = "{0} должен быть длинной в пределах от {1} до {2} символов", MinimumLength = 5)]
        [RegularExpression(@"[A-Za-z]+ [A-Za-z]+", ErrorMessage = "Уберите цифры, знаки или лишние пробелы")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "Номер карты является обязательным полем")]
        [Display(Name = "Номер карты")]
        //[StringLength(16, MinimumLength = 16, ErrorMessage = "{0} должен быть длинной в {1} символов и содержать только цифры")]
        [RegularExpression(@"([0-9]{16})", ErrorMessage = "Номер карты должен быть длинной в 16 символов и содержать только цифры")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Срок действия является обязательным полем")]
        [Display(Name = "Срок действия")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Некорректный срок действия карты, пример: 09/20")]
        [RegularExpression(@"([0-1]{1}[0-9]{1})/([1-9]{1}[0-9]{1})", ErrorMessage = "Некорректная дата (пример: 09/20)")]
        public string CardDate { get; set; }

        [Required(ErrorMessage = "CVV код является обязательным полем")]
        [Display(Name = "CVV код")]
        [Range(100, 999, ErrorMessage = "Некорректный код")]
        public int CVV { get; set; }
    }
}