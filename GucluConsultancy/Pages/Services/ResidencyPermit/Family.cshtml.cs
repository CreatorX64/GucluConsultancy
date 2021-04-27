using GucluConsultancy.Static;
using GucluConsultancy.Utility.Interfaces;
using GucluConsultancy.ViewModels.ResidencyPermit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GucluConsultancy.Pages.Services.ResidencyPermit
{
	public class FamilyModel : PageModel
	{
		private readonly IEmailSender _emailSender;
		private readonly IEmailBuilder _emailBuilder;

		public FamilyModel(IEmailSender emailSender, IEmailBuilder emailBuilder)
		{
			_emailSender = emailSender;
			_emailBuilder = emailBuilder;
		}

		[BindProperty]
		public FamilyViewModel FamilyVM { get; set; }

		[TempData]
		public string StatusMessage { get; set; }

		public void OnGet()
		{
			FamilyVM = new FamilyViewModel();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			IFormFileCollection formFileCollection = HttpContext.Request.Form.Files;
			string htmlMessage = _emailBuilder.GetHtmlString(EmailConstants.SubjectResidencyFamily, FamilyVM);

			await _emailSender.SendEmailAsync(EmailConstants.SubjectResidencyFamily, htmlMessage, formFileCollection);

			StatusMessage = "Form başarıyla gönderildi!";

			return RedirectToPage("/Index");
		}
	}
}