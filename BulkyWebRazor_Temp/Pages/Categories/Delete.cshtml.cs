using BulkyBookWebRazor_Temp.Data;
using BulkyBookWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BulkyBookWebRazor_Temp.Pages.Categories
{
    [BindProperties]  //process that takes values from HTTP requests and maps them to handler method parameters or PageModel properties. Model binding reduces the need for the developer to manually extract values from the request and then assign them, one by one, to variables or properties for later processing. 
    public class DeleteModel : PageModel
    {
        private readonly ApplicatiobDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicatiobDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
        
    }
}
