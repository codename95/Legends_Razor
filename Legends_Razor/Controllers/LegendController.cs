using Legends_Razor.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legends_Razor.Controllers
{
    [Route("api/Legend")]
    [ApiController]
    public class LegendController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LegendController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Legends.ToListAsync() });
        }

        [HttpDelete]
        public  async Task<IActionResult> Delete(Guid id)
        {
            var objfromDb = await _db.Legends.FirstOrDefaultAsync(u => u.Id == id);
            if(objfromDb == null)
            {
                return Json(new { success = false, message = "Error occured while deleting" });
            }

            _db.Legends.Remove(objfromDb);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete completed successfully" });
        }
    }
}
