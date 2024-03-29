using FastFood.Models;
using FastFood.Repository;
using FastFood.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FastFood.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoriesController : Controller
	{
		private readonly ApplicationDBContext _context;
		public CategoriesController(ApplicationDBContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var categories = _context.Categories.ToList().Select(
				x => new CategoryViewModel()
				{
					Id = x.Id,
					Title = x.Title
				}
				).ToList();
			return View();
		}

		[HttpGet]
		public IActionResult Create() 
		{
			var categoryViewModel = new CategoryViewModel();
			return View(categoryViewModel);
		}
        [HttpPost]
        public IActionResult Create(CategoryViewModel vm)
        {
            Category category = new Category();
			category.Title=vm.Title;
			_context.Categories.Add(category);
			_context.SaveChanges();
			return RedirectToAction("Index");
        }

        [HttpPatch]
        public IActionResult Edit(int id)
        {
			var viewModel= _context.Categories.Where(x => x.Id==id).Select(
				x=>new CategoryViewModel() {Id=x.Id, Title=x.Title }
				).FirstOrDefault();
            return View(viewModel);
        }
        [HttpPatch]
        public IActionResult Edit(CategoryViewModel vm)
        {
			if (ModelState.IsValid) {
				var category = _context.Categories.FirstOrDefault(x => x.Id == vm.Id);
                if (category !=null)
                {
					category.Title=vm.Title;
					_context.Categories.Update(category);
					_context.SaveChanges();
                }
            }
			return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var viewModel = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
			if (viewModel != null) { 
			_context.Categories.Remove(viewModel);	
			_context.SaveChanges();
			}
			return RedirectToAction("Index");
        }
    }
}
