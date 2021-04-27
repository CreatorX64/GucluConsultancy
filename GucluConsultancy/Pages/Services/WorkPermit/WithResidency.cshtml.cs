﻿using GucluConsultancy.Static;
using GucluConsultancy.Utility.Interfaces;
using GucluConsultancy.ViewModels.WorkPermit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GucluConsultancy.Pages.Services.WorkPermit
{
  public class WithResidencyModel : PageModel
  {
    private readonly IEmailSender _emailSender;
    private readonly IEmailBuilder _emailBuilder;

    public WithResidencyModel(IEmailSender emailSender, IEmailBuilder emailBuilder)
    {
      _emailSender = emailSender;
      _emailBuilder = emailBuilder;
    }

    [BindProperty]
    public WithResidencyViewModel WithResidencyVM { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    public void OnGet()
    {
      WithResidencyVM = new WithResidencyViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      IFormFileCollection formFileCollection = HttpContext.Request.Form.Files;
      string htmlMessage = _emailBuilder.GetHtmlString(EmailConstants.SubjectWorkWithResidency, WithResidencyVM);

      await _emailSender.SendEmailAsync(EmailConstants.SubjectWorkWithResidency, htmlMessage, formFileCollection);

      StatusMessage = "Form başarıyla gönderildi!";

      return RedirectToPage("/Index");
    }
  }
}