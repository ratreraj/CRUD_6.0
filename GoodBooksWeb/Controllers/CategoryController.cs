using GoodBooksWeb.Data;
using GoodBooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoodBooksWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            IEnumerable<Category> objCategorylist = _dbContext.Categories.OrderBy(x => x.DisplayOrder);
            return View(objCategorylist);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category model)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(model);
                _dbContext.SaveChanges();
                TempData["success"]= "Successfully creted";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var category = _dbContext.Categories.Find(id);

            if (category==null)
                return NotFound();


            return View(category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category model)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(model);
                _dbContext.SaveChanges();
                TempData["success"]= "Successfully updated";
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult Delete(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var category = _dbContext.Categories.Find(id);

            if (category==null)
                return NotFound();


            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int ? id)
        {
            var category = _dbContext.Categories.Find(id);

            if (category==null)
                return NotFound();

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            TempData["success"]= "Successfully deleted";
            return RedirectToAction("Index");

        }
    }
}
