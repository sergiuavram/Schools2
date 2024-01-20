using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schools2.Data;
using Schools2.Models;

namespace Schools2.Pages.Counties
{
    public class DeleteModel : PageModel
    {
        private readonly Schools2.Data.Schools2Context _context;

        public DeleteModel(Schools2.Data.Schools2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public County County { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.County == null)
            {
                return NotFound();
            }

            var county = await _context.County.Include(c => c.Country).FirstOrDefaultAsync(m => m.ID == id);

            if (county == null)
            {
                return NotFound();
            }
            else 
            {
                County = county;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.County == null)
            {
                return NotFound();
            }
            var county = await _context.County.FindAsync(id);

            if (county != null)
            {
                County = county;
                _context.County.Remove(County);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
