using System.ComponentModel.DataAnnotations;

namespace GucluConsultancy.ViewModels.WorkPermit
{
	public class TemporaryProtectionViewModel
	{
		[Display(Name = "26 haneli SGK numarası")]
		public string SgkNumber { get; set; }

		[Display(Name = "Kayıtlı sermaye")]
		public decimal? RegisteredCapital { get; set; }

		[Display(Name = "Ödenmiş sermaye")]
		public decimal? PaidInCapital { get; set; }

		[Display(Name = "Şirket telefon numarası")]
		public string CompanyPhoneNumber { get; set; }

		[Display(Name = "Şirket email adresi")]
		public string CompanyEmailAddress { get; set; }

		[Display(Name = "Yabancının görevi hakkında detaylı bilgi")]
		public string ForeignerJobDetails { get; set; }

		[Display(Name = "Türk vatandaşı yerine yabancı istihdam talebinin gerekçesi")]
		public string ReasonToHireForeigner { get; set; }

		[Display(Name = "Eşinin adı soyadı")]
		public string ForeignerSpouseFullName { get; set; }

		[Display(Name = "Eşinin uyruğu")]
		public string ForeignerSpouseNationality { get; set; }

		[Required(ErrorMessage = "Lütfen telefon no giriniz")]
		[Display(Name = "Telefon no")]
		public string ForeignerPhoneNumber { get; set; }

		[Required(ErrorMessage = "Lütfen email adresi giriniz")]
		[Display(Name = "Email adresi")]
		public string ForeignerEmailAddress { get; set; }

		[Required(ErrorMessage = "Lütfen Türkiye adresi giriniz")]
		[Display(Name = "Türkiye adresi")]
		public string ForeignerTurkeyAddress { get; set; }

		[Required(ErrorMessage = "Lütfen Suriye adresi giriniz")]
		[Display(Name = "Suriye adresi")]
		public string ForeignerSyriaAddress { get; set; }

		[Required(ErrorMessage = "Lütfen eğitim durumu giriniz")]
		[Display(Name = "Eğitim durumu")]
		public string ForeignerEducationStatus { get; set; }

		[Required(ErrorMessage = "Lütfen Türkiye'de bulunma süresi giriniz")]
		[Display(Name = "Türkiye'de bulunma süresi")]
		public string ForeignerDurationInTurkey { get; set; }
	}
}