using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schools2.Data;
using Schools2.Models;

namespace Schools2.Pages.Schools
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
        ViewData["CityID"] = new SelectList(_context.City, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public School School { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.School == null || School == null)
            {
                return Page();
            }

            _context.School.Add(School);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
