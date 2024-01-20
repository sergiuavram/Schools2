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
    public class IndexModel : PageModel
    {
        private readonly Schools2.Data.Schools2Context _context;

        public IndexModel(Schools2.Data.Schools2Context context)
        {
            _context = context;
        }

        public IList<School> School { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.School != null)
            {
                School = await _context.School
                .Include(s => s.City).ThenInclude(c => c.County).ThenInclude(c => c.Country).ToListAsync();
            }
        }
    }
}
