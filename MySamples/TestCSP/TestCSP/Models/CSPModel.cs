using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestCSP.Models
{
    public class CspModel : PageModel
    {
        public void OnGet()
        {
            var cspHeader =
                "default-src 'self'; img-src 'self' https://www.manning.com/assets/; style-src 'self' https://cdn.jsdelivr.net 'unsafe-hashes' 'sha256-yckz1zrIL2HgQwm7x1ins99s5jndZE3XnmgOAkJvDOg='; script-src 'self' https://cdn.jsdelivr.net 'sha256-Nri3mDGBJy3LCT+AxvP4dtbCPf6tkg4QIcqNisVrRZw=' 'unsafe-eval'";
            HttpContext.Response.Headers.Add("Content-Security-Policy", cspHeader);
        }
    }
}
