<nav>
    <ul>
        <li><a href="@Url.Action("Index", "Message")">Send Message</a></li>
        <li><a href="@Url.Action("ViewMessages", "Message")">View Messages</a></li>
    </ul>
</nav>

namespace YourProjectNamespace.Models
{
    public class Message
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using YourProjectNamespace.Models;
using System.Collections.Generic;

namespace YourProjectNamespace.Controllers
{
    public class MessageController : Controller
    {
        // Lista estática para armazenar as mensagens
        private static List<Message> messages = new List<Message>();

        // Action para exibir o formulário e mensagens recebidas
        [HttpGet]
        public IActionResult Index()
        {
            return View(messages);
        }

        // Action para processar o formulário de envio de mensagens
        [HttpPost]
        public IActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                message.DateSent = DateTime.Now; // Define a data e hora atual
                messages.Add(message);
                return RedirectToAction("Index");
            }
            return View(messages);
        }

        // Action para exibir apenas mensagens recebidas
        [HttpGet]
        public IActionResult ViewMessages()
        {
            return View(messages);
        }
    }
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Message}/{action=Index}/{id?}");
});
