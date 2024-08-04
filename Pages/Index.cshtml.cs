using DemoCapstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoCapstone.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyStoreContext _context;

        [BindProperty]
        public Staff Staff { get; set; } = default!;
        public IndexModel(MyStoreContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var data = _context.Staffs.Where(s => s.Name.Equals(Staff.Name) && s.Password.Equals(Staff.Password)).ToList();
                if (data.Count() > 0)
                {
                    return Redirect("/Home");
                }
                else
                {
                    TempData["error"] = "Login failed";
                    return RedirectToAction("/Index");
                }
            }
            return RedirectToAction("/Index");
        }
    }
}
