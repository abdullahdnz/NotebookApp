using Microsoft.AspNetCore.Mvc;
using MyNotebook.Data.Abstract;
using MyNotebook.Models;

namespace MyNotebook.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService _noteService)
        {
            this._noteService = _noteService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note note)
        {
            note.CreateDate = DateTime.Parse(DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm"));
            _noteService.Add(note);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var value = _noteService.GetAll();
            return View(value);
        }

        public IActionResult Delete(int id)
        {
            var value = _noteService.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _noteService.FindByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            if (!ModelState.IsValid)
            {
                return View(note);
            }

            var value = _noteService.Edit(note);
            if (value)
            {
                return RedirectToAction("GetAll");
            }

            TempData["msg"] = "Error has occured on server side";

            return View(note);
        }

        public IActionResult Detail(int id)
        {
            var value = _noteService.FindByID(id);
            return View(value);
        }
    }
}
