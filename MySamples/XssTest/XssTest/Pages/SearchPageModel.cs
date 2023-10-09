using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XssTest.Pages;

public class SearchPageModel : PageModel
{
    public string Result { get; set; } = string.Empty;
    public void OnGet(string searchTerm)
    {
        Result = string.IsNullOrEmpty(searchTerm) ?
            string.Empty :
            $"Your search for <i>{searchTerm}</i> did not yield any results.";
    }
}