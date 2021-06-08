using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legends_Razor.Model;
using Legends_Razor.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Legends_Razor.Pages.LegendList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Legend Legend { get; set; }
        public async Task<IActionResult> OnGet(Guid? id)
        {
            Legend = new Legend();
            if(id == null)
            {
                return Page();
            }
            Legend = await _db.Legends.FirstOrDefaultAsync(u => u.Id == id);
            if(Legend == null) { return NotFound(); }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
               if(Legend.Id == Guid.Empty)
                {
                    _db.Legends.Add(Legend);
                }
               else
                {
                    _db.Legends.Update(Legend);
                }
                /* var objFromDb = await _db.Legends.FindAsync(legend.Id);
                objFromDb.Name = legend.Name;
                objFromDb.Country = legend.Country;
                objFromDb.SuperPower = legend.SuperPower;
                await _db.SaveChangesAsync(); */
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
