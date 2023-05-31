using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

/**
 * 2. AutoMapper
 * 3. Split project
 */
namespace WebApplication1.Controllers
{
    public class TodoController : Controller
    {
        public ApplicationContext Context { get; set; }

        public TodoController(ApplicationContext context)
        {
            Context = context;
        }

        [Authorize]
        public IActionResult List()
        {
            var todos = Context.TodoItems.ToList();
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoItemCreateBindingModel model)
        {
            var userName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var entity = new TodoItemViewModel()
                {
                    Id = 0,
                    Name = model.Name,
                    Description = model.Description,
                    HasDone = false,
                    OnDate = model.OnDate

                };
                Context.TodoItems.Add(entity);
                Context.SaveChanges();

                return RedirectToAction("List");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var entity = Context.TodoItems.Find(id);

            if (entity == null) { }

            return View(new TodoItemUpdateBindingModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                HasDone = entity.HasDone,
                OnDate = entity.OnDate
            });
        }

        [HttpPost]
        public IActionResult Edit(TodoItemUpdateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = Context.TodoItems.Find(model.Id);

                if(entity != null)
                {
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.HasDone = model.HasDone;
                    entity.OnDate = model.OnDate;

                    Context.SaveChanges();
                }

                return RedirectToAction("List");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var entity = Context.TodoItems.Find(id);

            if (entity != null)
            {
                Context.TodoItems.Remove(entity);
                Context.SaveChanges();
            }

            return RedirectToAction("List");
        }
    }
}
