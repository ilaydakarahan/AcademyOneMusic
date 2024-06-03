using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{		
	[Authorize(Roles ="Admin")]
	public class AdminContactController(IContactService _contactService) : Controller
	{
		public IActionResult Index()
		{
			var value = _contactService.TGetList();
			return View(value);
		}

		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateContact(Contact contact)
		{
			_contactService.TCreate(contact);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteContact(int id)
		{
			_contactService.TDelete(id);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateContact(int id)
		{
			var values = _contactService.TGetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult UpdateContact(Contact contact)
		{
			_contactService.TUpdate(contact);
			return RedirectToAction("Index");

		}
	}
}
