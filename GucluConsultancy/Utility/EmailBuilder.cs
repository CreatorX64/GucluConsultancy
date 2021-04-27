using GucluConsultancy.Utility.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GucluConsultancy.Utility
{
	public class EmailBuilder : IEmailBuilder
	{
		private readonly IDictionary<string, string> _keyTitleMap = new Dictionary<string, string>
		{
			["ForeignersId"] = "Yabancı kimlik no",
			["FatherName"] = "Baba adı",
			["MotherName"] = "Anne adı",
			["MaritalStatus"] = "Medeni hali",
			["BirthCountry"] = "Doğum yeri ülkesi",
			["BirthNationality"] = "Doğumdaki uyruğu",
			["PhoneNumber"] = "Telefon no",
			["EmailAddress"] = "Email adresi",
			["AddressAbroad"] = "Yurtdışı adresi",
			["AddressTurkey"] = "Türkiye adresi",
			["MonthlyIncome"] = "Aylık gelir",
			["ReasonForResidency"] = "İkamet izni alış nedeni",
			["DesiredResidencyDuration"] = "İstenilen ikamet izni süresi",
			["EducationBeginDate"] = "Öğrenim başlangıç tarihi",
			["EducationEndDate"] = "Öğrenim bitiş tarihi",
			["GradeLevel"] = "Sınıfı",
			["SchoolAddress"] = "Okul adresi",
			["FamilyMemberEmailAddress"] = "Aile bireyi email adresi",
			["FamilyMemberPhoneNumber"] = "Aile bireyi telefon no",
			["FamilyMemberOccupation"] = "Aile bireyi mesleği",
			["FamilyMemberMonthlyIncome"] = "Aile bireyi aylık geliri",
			["FamilyMemberHomeAddress"] = "Aile bireyi ev adresi",
			["FamilyMemberFamilySize"] = "Aile bireyi kendisi dahil bakmakla yükümlü olduğu kişi sayısı",
			["SgkNumber"] = "26 haneli SGK numarası",
			["RegisteredCapital"] = "Kayıtlı sermaye",
			["PaidInCapital"] = "Ödenmiş sermaye",
			["CompanyPhoneNumber"] = "Şirket telefon numarası",
			["CompanyEmailAddress"] = "Şirket email adresi",
			["ForeignerJobDetails"] = "Yabancının görevi hakkında detaylı bilgi",
			["ReasonToHireForeigner"] = "Türk vatandaşı yerine yabancı istihdam talebinin gerekçesi",
			["ForeignerSpouseFullName"] = "Yabancının eşinin adı soyadı",
			["ForeignerSpouseNationality"] = "Yabancının eşinin uyruğu",
			["ForeignerFatherName"] = "Yabancının baba adı",
			["ForeignerPhoneNumber"] = "Yabancının telefon numarası",
			["ForeignerEmailAddress"] = "Yabancının email adresi",
			["ForeignerTurkeyAddress"] = "Yabancının Türkiye adresi",
			["ForeignerSyriaAddress"] = "Yabancının Suriye adresi",
			["ForeignerEducationStatus"] = "Yabancının eğitim durumu",
			["ForeignerDurationInTurkey"] = "Yabancının Türkiye'de bulunma süresi",
			["EmployerPhoneNumber"] = "İşveren telefon numarası",
			["EmployerEmailAddress"] = "İşveren email adresi",
			["EmployerHomeAddress"] = "İşveren ev adresi",
			["ForeignerWorkAddress"] = "Yabancının çalışacağı adres",
			["ForeignerAbroadAddress"] = "Yabancının ülkesindeki adresi",
			["ForeignerMotherLanguage"] = "Yabancının ana dili",
			["ForeignerTurkishLevel"] = "Yabancının Türkçe düzeyi",
			["ForeignerOtherLanguages"] = "Yabancının bildiği diğer diller",
			["ForeignerEducationStatus"] = "Yabancının eğitim durumu",
			["ForeignerLastGraduatedSchoolAndPlace"] = "Yabancının son mezun olduğu okulun adı ve yeri",
			["ForeignerProfessionalQualification"] = "Yabancının diploma mesleği",
			["ForeignerSpecializationSubject"] = "Yabancının ihtisas konusu"
		};

		public string GetHtmlString(string subject, object viewModel)
		{
			string htmlMessageStart = $@"
				<h1 style=""font-size: 24px; font-family: 'Trebuchet MS', sans-serif;"">{subject} Başvuru Formu</h1>
				<p>Bir müşteriniz {subject} başvuru formu doldurdu.</p>
				<h2 style=""font-size: 20px; font-family: 'Trebuchet MS', sans-serif; margin-top: 20px;"">Form Bilgileri</h2>
				<table style=""font-size: 15px; font-family: 'Trebuchet MS', sans-serif; border-collapse: collapse; border: 1px solid rgb(140, 140, 140);"">
			";
			string htmlMessageEnd = "</table>";

			// Convert the ViewModel into a Dictionary so that we can index the titles of each data item.
			Dictionary<string, string> modelKeyValuePairs = viewModel
				.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				.ToDictionary(prop => prop.Name, prop => prop.GetValue(viewModel, null)?.ToString());

			var emailHtml = "";

			foreach (KeyValuePair<string, string> entry in modelKeyValuePairs)
			{
				if (_keyTitleMap.ContainsKey(entry.Key))
				{
					emailHtml += $@"
						<tr>
							<th style=""font-size: 15px; background-color: rgb(245, 245, 245); text-align: right; padding: 10px; border: 1px solid rgb(140, 140, 140);"">
								{_keyTitleMap[entry.Key]}
							</th>
							<td style=""font-size: 15px; padding: 10px; border: 1px solid rgb(140, 140, 140);"">
								{entry.Value}
							</td>
						</tr>
						";
				}
			}

			return $"{htmlMessageStart}{emailHtml}{htmlMessageEnd}";
		}
	}
}