using GucluConsultancy.Static;
using GucluConsultancy.Utility.Interfaces;
using GucluConsultancy.ViewModels.ResidencyPermit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GucluConsultancy.Pages.Services.ResidencyPermit
{
  public class ShortTermModel : PageModel
  {
    private readonly IEmailSender _emailSender;
    private readonly IEmailBuilder _emailBuilder;

    public ShortTermModel(IEmailSender emailSender, IEmailBuilder emailBuilder)
    {
      _emailSender = emailSender;
      _emailBuilder = emailBuilder;
    }

    [BindProperty]
    public ShortTermViewModel ShortTermVM { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    public void OnGet()
    {
      ShortTermVM = new ShortTermViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      IFormFileCollection formFileCollection = HttpContext.Request.Form.Files;
      string htmlMessage = _emailBuilder.GetHtmlString(EmailConstants.SubjectResidencyShortTerm, ShortTermVM);

      await _emailSender.SendEmailAsync(EmailConstants.SubjectResidencyShortTerm, htmlMessage, formFileCollection);

      StatusMessage = "Form başarıyla gönderildi!";

      return RedirectToPage("/Index");
    }
  }
}