using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GucluConsultancy.Pages
{
  public class IndexModel : PageModel
  {
    [TempData]
    public string StatusMessage { get; set; }

    public void OnGet()
    {
      // Empty block.
    }
  }
}