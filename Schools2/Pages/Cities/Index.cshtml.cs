using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schools2.Data;
using Schools2.Models;

namespace Schools2.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly Schools2.Data.Schools2Context _context;

        public IndexModel(Schools2.Data.Schools2Context context)
        {
            _context = context;
        }

        public IList<City> City { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.City != null)
            {
                City = await _context.City
                .Include(c => c.County).ToListAsync();
            }
        }
    }
}
