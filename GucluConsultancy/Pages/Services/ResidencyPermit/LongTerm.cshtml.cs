using GucluConsultancy.Static;
using GucluConsultancy.Utility.Interfaces;
using GucluConsultancy.ViewModels.ResidencyPermit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GucluConsultancy.Pages.Services.ResidencyPermit
{
  public class LongTermModel : PageModel
  {
    private readonly IEmailSender _emailSender;
    private readonly IEmailBuilder _emailBuilder;

    public LongTermModel(IEmailSender emailSender, IEmailBuilder emailBuilder)
    {
      _emailSender = emailSender;
      _emailBuilder = emailBuilder;
    }

    [BindProperty]
    public LongTermViewModel LongTermVM { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    public void OnGet()
    {
      LongTermVM = new LongTermViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      IFormFileCollection formFileCollection = HttpContext.Request.Form.Files;
      string htmlMessage = _emailBuilder.GetHtmlString(EmailConstants.SubjectResidencyLongTerm, LongTermVM);
      await _emailSender.SendEmailAsync(EmailConstants.SubjectResidencyLongTerm, htmlMessage, formFileCollection);

      StatusMessage = "Form başarıyla gönderildi!";

      return RedirectToPage("/Index");
    }
  }
}