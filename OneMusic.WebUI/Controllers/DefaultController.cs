using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    public class DefaultController(IMessageService messageService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            messageService.TCreate(message);
            return NoContent();     //ındex sayfasında script tanımladığımız için dönüş tipinde birşey yapmasın ayarladık.
        }
    }
}
