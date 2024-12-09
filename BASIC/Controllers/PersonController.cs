using BASIC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BASIC.Controllers
{
    public class PersonController : Controller
    {
        private readonly DataBaseContext _ctx;
        public PersonController(DataBaseContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            var person = _ctx.Person.ToList();
            return View(person);
        }
        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person p)
        {
            try 
            {
                _ctx.Person.Add(p);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex);
            }                                 
        }
        public IActionResult DeletePerson(string id)
        {
            var person=_ctx.Person.Find(id);
            _ctx.Person.Remove(person);
            _ctx.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
