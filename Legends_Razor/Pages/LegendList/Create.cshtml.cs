using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legends_Razor.Model;
using Legends_Razor.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Legends_Razor.Pages.LegendList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Legend Legend { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Legend legend)
        {
            if(ModelState.IsValid)
            {
                await _db.Legends.AddAsync(legend);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
