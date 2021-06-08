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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Legend Legend { get; set; }
        public async Task OnGet(Guid id)
        {
            Legend = await _db.Legends.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(Legend legend)
        {
            if(ModelState.IsValid)
            {
                var objFromDb = await _db.Legends.FindAsync(legend.Id);
                objFromDb.Name = legend.Name;
                objFromDb.Country = legend.Country;
                objFromDb.SuperPower = legend.SuperPower;

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
