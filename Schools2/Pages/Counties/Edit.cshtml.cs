using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schools2.Data;
using Schools2.Models;

namespace Schools2.Pages.Counties
{
    public class EditModel : PageModel
    {
        private readonly Schools2.Data.Schools2Context _context;

        public EditModel(Schools2.Data.Schools2Context context)
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

            var county =  await _context.County.FirstOrDefaultAsync(m => m.ID == id);
            if (county == null)
            {
                return NotFound();
            }
            County = county;
           ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(County).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountyExists(County.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CountyExists(int id)
        {
          return (_context.County?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
