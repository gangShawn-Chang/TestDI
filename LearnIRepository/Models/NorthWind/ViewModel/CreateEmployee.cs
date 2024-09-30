using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearnIRepository.Models.NorthWind.ViewModel
{
    public class CreateEmployee
    {
        [Required]
        [Display(Name = "姓氏")]
        public required string LastName { get; set; }
        [Required]
        [Display(Name = "名字")]
        public required string FirstName { get; set; }
        [Required]
        [Display(Name = "職稱")]
        public required string Title { get; set; }

        [Display(Name = "生日")]
        public DateTime? BirthDate { get; set; }
        [Required]
        [Display(Name = "到職日")]
        public DateTime? HireDate { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "城市")]
        public string City { get; set; }

        [Display(Name = "地區")]
        public string Region { get; set; }

        [Display(Name = "郵件編號")]
        public string PostalCode { get; set; }

        [Display(Name = "國家")]
        public string Country { get; set; }

        [Display(Name = "家電")]
        public string HomePhone { get; set; }

        [Display(Name = "分機")]
        public string Extension { get; set; }

        [Display(Name = "手機")]
        [Phone(ErrorMessage = "錯誤的格式.")]
        public string Phone { get; set; }
    }
}
