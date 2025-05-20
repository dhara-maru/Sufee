using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUFEEASP.Data;
using SUFEEASP.Model;

namespace SUFEEASP.Pages.Admin.Writers
{
    public class DetailsModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public DetailsModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        public Writer Writer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writer.FirstOrDefaultAsync(m => m.ID == id);
            if (writer == null)
            {
                return NotFound();
            }
            else
            {
                Writer = writer;
            }
            return Page();
        }
    }
}
