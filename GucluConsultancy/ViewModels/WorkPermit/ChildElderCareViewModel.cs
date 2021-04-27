using System.ComponentModel.DataAnnotations;

namespace GucluConsultancy.ViewModels.WorkPermit
{
	public class ChildElderCareViewModel
	{
		[Required(ErrorMessage = "Lütfen işveren telefon no giriniz")]
		[Display(Name = "İşverenin telefon numarası")]
		public string EmployerPhoneNumber { get; set; }

		[Required(ErrorMessage = "Lütfen işveren email adresi giriniz")]
		[Display(Name = "İşverenin email adresi")]
		public string EmployerEmailAddress { get; set; }

		[Required(ErrorMessage = "Lütfen işveren ev adresi giriniz")]
		[Display(Name = "İşveren ev adresi")]
		public string EmployerHomeAddress { get; set; }

		[Required(ErrorMessage = "Lütfen görev detayı giriniz")]
		[Display(Name = "Yabancının görevi hakkında detaylı bilgi")]
		public string ForeignerJobDetails { get; set; }

		[Required(ErrorMessage = "Lütfen istihdam gerekçesi giriniz")]
		[Display(Name = "Türk vatandaşı yerine yabancı istihdam talebinin gerekçesi")]
		public string ReasonToHireForeigner { get; set; }

		[Required(ErrorMessage = "Lütfen yabancının çalışacağı adresi giriniz")]
		[Display(Name = "Yabancının çalışacağı adres")]
		public string ForeignerWorkAddress { get; set; }

		[Display(Name = "Eşinin adı soyadı")]
		public string ForeignerSpouseFullName { get; set; }

		[Display(Name = "Eşinin uyruğu")]
		public string ForeignerSpouseNationality { get; set; }

		[Required(ErrorMessage = "Lütfen baba adı giriniz")]
		[Display(Name = "Baba adı")]
		public string ForeignerFatherName { get; set; }

		[Required(ErrorMessage = "Lütfen telefon no giriniz")]
		[Display(Name = "Telefon no")]
		public string ForeignerPhoneNumber { get; set; }

		[Display(Name = "Email adresi")]
		public string ForeignerEmailAddress { get; set; }

		[Required(ErrorMessage = "Lütfen ülkesindeki adresi giriniz")]
		[Display(Name = "Ülkesindeki adresi")]
		public string ForeignerAbroadAddress { get; set; }

		[Required(ErrorMessage = "Lütfen ana dili giriniz")]
		[Display(Name = "Ana dili")]
		public string ForeignerMotherLanguage { get; set; }

		[Required(ErrorMessage = "Lütfen Türkçe düzeyi seçiniz")]
		[Display(Name = "Türkçe düzeyi")]
		public string ForeignerTurkishLevel { get; set; }

		[Display(Name = "Bildiği diğer diller")]
		public string ForeignerOtherLanguages { get; set; }

		[Required(ErrorMessage = "Lütfen eğitim durumu giriniz")]
		[Display(Name = "Eğitim durumu")]
		public string ForeignerEducationStatus { get; set; }

		[Required(ErrorMessage = "Lütfen okul adı ve yeri giriniz")]
		[Display(Name = "Son mezun olduğu okulun adı ve yeri")]
		public string ForeignerLastGraduatedSchoolAndPlace { get; set; }
	}
}