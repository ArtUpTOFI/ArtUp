using ArtUp.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название проекта является обязательным полем")]
        [Display(Name="Название проекта")]
        [StringLength(50, ErrorMessage = "{0} должно быть длиной как минимум {2} символов и {1} символов максимум", MinimumLength = 4)]
        public string Title { get; set; }

        /// <summary>
        /// Main picture of the project
        /// </summary>
        public string Avatar { get; set; }
        
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Amount of collected money
        /// </summary>
        public decimal CurrentMoney { get; set; }

        public byte[] Image { get; set; }

        /// <summary>
        /// Required amount of money for success
        /// </summary>
        [Required(ErrorMessage = "Требуемая сумма является обязательным полем")]
        [Display(Name = "Требуемая сумма")]
        [Range(typeof(decimal), "20.00", "10000000000000.00", ErrorMessage = "Требуемая сумма должна быть в пределах от {1} до {2}")]
        public decimal RequiredMoney { get; set; }

        /// <summary>
        /// Duration of campaign to collect money
        /// </summary>
        [Required(ErrorMessage = "Длительность кампании по сбору средств является обязательным полем")]
        [Display(Name = "Длительность кампании по сбору средств")]
        [Range(1, 180, ErrorMessage = "Длительность кампании должна быть в пределах от {1} до {2} дней")]
        public long Duration { get; set; }

        /// <summary>
        /// Short description of the project
        /// </summary>
        [Required(ErrorMessage = "Краткое описание проекта является обязательным полем")]
        [Display(Name = "Краткое описание проекта")]
        [StringLength(160, ErrorMessage = "{0} должно быть длиной как минимум {2} символов и {1} символов максимум", MinimumLength = 20)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Full description of the project
        /// </summary>
        public string FullDescription { get; set; }

        public bool IsSuccessful { get; set; }

        public bool WasPaid { get; set; }

        [Required(ErrorMessage = "Имя организатора является обязательным полем")]
        [Display(Name = "Имя организатора")]
        [StringLength(20, ErrorMessage = "{0} должно быть длиной как минимум {2} символов и {1} символов максимум", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия организатора является обязательным полем")]
        [Display(Name = "Фамилия")]
        [StringLength(30, ErrorMessage = "{0} должно быть длиной как минимум {2} символов и {1} символов максимум", MinimumLength = 2)]
        public string Surname { get; set; }

        public string Category { get; set; }

        public int UserId { get; set; }

        public ProjectState ProjectState { get; set; }

        [Required(ErrorMessage = "Отчество организатора является обязательным полем")]
        [Display(Name = "Отчество")]
        [StringLength(25, ErrorMessage = "{0} должно быть длиной как минимум {2} символов и {1} символов максимум", MinimumLength = 3)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Дата рождения является обязательным полем")]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        public DocumentType DocumentType { get; set; }

        [Required(ErrorMessage = "Серия и номер паспорта являются обязательным полем")]
        [Display(Name = "Серия и номер паспорта")]
        [StringLength(9, ErrorMessage = "Серия и номер паспорта должны быть {2} символов длиной", MinimumLength = 9)]
        public string PasspotNumberSeries { get; set; }

        [Required(ErrorMessage = "Личный номер является обязательным полем")]
        [Display(Name = "Личный")]
        [StringLength(14, ErrorMessage = "Личный номер паспорта должен быть {2} символов длиной", MinimumLength = 14)]
        public string PersonalPassportNumber { get; set; }

        [Required(ErrorMessage = "Место и дата выдачи являются обязательным полем")]
        [Display(Name = "Место и дата выдачи")]
        [StringLength(50, ErrorMessage = "Место и дата выдачи должны быть не короче {2} символов", MinimumLength = 5)]
        public string WhoAndWhereIssued { get; set; }

        [Required(ErrorMessage = "Адрес регистрации является обязательным полем")]
        [Display(Name = "Адрес регистрации")]
        [StringLength(50, ErrorMessage = "Адрес регистрации должен быть не короче {2} символов", MinimumLength = 10)]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Номер телефона является обязательным полем")]
        [Display(Name = "Номер телефона")]
        //[RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Некорректный номер телефона")]
        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        [Required(ErrorMessage = "Номер счёта является обязательным полем")]
        [Display(Name = "Номер счёта")]
        [StringLength(13, ErrorMessage = "{0} должен быть длиной в {2} символов", MinimumLength = 13)]
        //[RegularExpression(@"/^\d+$/", ErrorMessage = "Некорректный номер счёта")]
        public string AccountNumber { get; set; }

        public GiftViewModel[] Gifts { get; set; }
    }
}