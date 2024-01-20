using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schools2.Data;
using Schools2.Models;

namespace Schools2.Pages.Cities
{
    public class CreateModel : PageModel
    {
        private readonly Schools2.Data.Schools2Context _context;

        public CreateModel(Schools2.Data.Schools2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountyID"] = new SelectList(_context.Set<County>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public City City { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.City == null || City == null)
            {
                return Page();
            }

            _context.City.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
