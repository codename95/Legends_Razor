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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Legend> Legends { get; set; }
        public async Task OnGet()
        {
            Legends = await _db.Legends.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            var objFromDb = await _db.Legends.FindAsync(id);
            if(objFromDb == null)
            {
                return NotFound();
            }
            _db.Legends.Remove(objFromDb);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
