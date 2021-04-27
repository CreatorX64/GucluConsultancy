using System;
using System.ComponentModel.DataAnnotations;

namespace GucluConsultancy.ViewModels.ResidencyPermit
{
  public class StudentViewModel
  {
    [Display(Name = "Yabancı kimlik no")]
    public string ForeignersId { get; set; }

    [Required(ErrorMessage = "Lütfen baba adı giriniz")]
    [Display(Name = "Baba adı")]
    public string FatherName { get; set; }

    [Required(ErrorMessage = "Lütfen anne adı giriniz")]
    [Display(Name = "Anne adı")]
    public string MotherName { get; set; }

    [Required(ErrorMessage = "Lütfen medeni durum seçiniz")]
    [Display(Name = "Medeni hali")]
    public string MaritalStatus { get; set; }

    [Required(ErrorMessage = "Lütfen doğum yeri ülkesi giriniz")]
    [Display(Name = "Doğum yeri ülkesi")]
    public string BirthCountry { get; set; }

    [Required(ErrorMessage = "Lütfen doğumdaki uyruğu giriniz")]
    [Display(Name = "Doğumdaki uyruğu")]
    public string BirthNationality { get; set; }

    [Required(ErrorMessage = "Lütfen telefon no giriniz")]
    [Display(Name = "Telefon no")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Email adresi")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Lütfen yurtdışı adresi giriniz")]
    [Display(Name = "Yurtdışı adresi")]
    public string AddressAbroad { get; set; }

    [Required(ErrorMessage = "Lütfen Türkiye adresi giriniz")]
    [Display(Name = "Türkiye adresi")]
    public string AddressTurkey { get; set; }

    [Required(ErrorMessage = "Lütfen aylık gelir giriniz")]
    [Display(Name = "Aylık gelir")]
    public string MonthlyIncome { get; set; }

    [Required(ErrorMessage = "Lütfen ikamet izni süresi giriniz")]
    [Display(Name = "İstenilen ikamet izni süresi")]
    public string DesiredResidencyDuration { get; set; }

    [Required(ErrorMessage = "Lütfen öğrenim başlangıç tarihi giriniz")]
    [Display(Name = "Öğrenim başlangıç tarihi")]
    public DateTime? EducationBeginDate { get; set; }

    [Required(ErrorMessage = "Lütfen öğrenim bitiş tarihi giriniz")]
    [Display(Name = "Öğrenim bitiş tarihi")]
    public DateTime? EducationEndDate { get; set; }

    [Required(ErrorMessage = "Lütfen sınıf giriniz")]
    [Display(Name = "Sınıfı")]
    public int? GradeLevel { get; set; }

    [Required(ErrorMessage = "Lütfen okul adresi giriniz")]
    [Display(Name = "Okul adresi")]
    public string SchoolAddress { get; set; }
  }
}