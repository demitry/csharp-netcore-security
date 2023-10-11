using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestCSP.Models
{
    public class CspModel : PageModel
    {
        public void OnGet()
        {
            var cspHeader = "default-src 'self'";
            HttpContext.Response.Headers.Add("Content-Security-Policy", cspHeader);
        }
    }
}