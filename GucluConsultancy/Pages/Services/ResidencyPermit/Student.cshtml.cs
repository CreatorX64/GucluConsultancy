using GucluConsultancy.Static;
using GucluConsultancy.Utility.Interfaces;
using GucluConsultancy.ViewModels.ResidencyPermit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GucluConsultancy.Pages.Services.ResidencyPermit
{
	public class StudentModel : PageModel
	{
		private readonly IEmailSender _emailSender;
		private readonly IEmailBuilder _emailBuilder;

		public StudentModel(IEmailSender emailSender, IEmailBuilder emailBuilder)
		{
			_emailSender = emailSender;
			_emailBuilder = emailBuilder;
		}

		[BindProperty]
		public StudentViewModel StudentVM { get; set; }

		[TempData]
		public string StatusMessage { get; set; }

		public void OnGet()
		{
			StudentVM = new StudentViewModel();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			IFormFileCollection formFileCollection = HttpContext.Request.Form.Files;
			string htmlMessage = _emailBuilder.GetHtmlString(EmailConstants.SubjectResidencyStudent, StudentVM);

			await _emailSender.SendEmailAsync(EmailConstants.SubjectResidencyStudent, htmlMessage, formFileCollection);

			StatusMessage = "Form başarıyla gönderildi!";

			return RedirectToPage("/Index");
		}
	}
}