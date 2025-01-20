using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OddOneOut.Web.Pages;

/// <summary />
public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;


    /// <summary />
    public PrivacyModel( ILogger<PrivacyModel> logger )
    {
        _logger = logger;
    }


    /// <summary />
    public void OnGet()
    {
    }
}