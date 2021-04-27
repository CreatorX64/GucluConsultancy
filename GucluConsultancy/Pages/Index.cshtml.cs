using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GucluConsultancy.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
      _logger = logger;
      _logger.LogDebug(1, "NLog injected into IndexModel.");
    }

    [TempData]
    public string StatusMessage { get; set; }

    public void OnGet()
    {
      _logger.LogInformation("Hello, this is the Index!");
    }
  }
}