using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;

namespace SessionAttack.Models
{
    public class SessionWriteModel : PageModel
    {
        /*
            При загрузке страницы считывается идентификационная строка
            браузера, которую клиенты обычно отправляют как часть запроса.
            Код проверяет HTTP-заголовок User-Agent на наличие этой информации. 
            Затем эта строка сохраняется в сессию пользователя с помощью метода Session.SetString().
        */
        
        public string UserAgent { get; set; } = string.Empty;
        public void OnGet()
        {
            this.UserAgent = HttpContext.Request.Headers[HeaderNames.UserAgent];
            HttpContext.Session.SetString("browser", this.UserAgent);
        }
    }
}