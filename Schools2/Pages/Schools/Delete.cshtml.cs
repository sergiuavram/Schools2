using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schools2.Data;
using Schools2.Models;

namespace Schools2.Pages.Schools
{
    public class DeleteModel : PageModel
    {
        private readonly Schools2.Data.Schools2Context _context;

        public DeleteModel(Schools2.Data.Schools2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public School School { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.School == null)
            {
                return NotFound();
            }

            var school = await _context.School.Include(c => c.City).FirstOrDefaultAsync(m => m.ID == id);

            if (school == null)
            {
                return NotFound();
            }
            else 
            {
                School = school;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.School == null)
            {
                return NotFound();
            }
            var school = await _context.School.FindAsync(id);

            if (school != null)
            {
                School = school;
                _context.School.Remove(School);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
