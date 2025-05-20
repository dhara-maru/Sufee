using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUFEEASP.Data;
using SUFEEASP.Model;

namespace SUFEEASP.Pages.Admin.Qawwalis
{
    public class DetailsModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public DetailsModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        public Qawwali Qawwali { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qawwali = await _context.Qawwali.FirstOrDefaultAsync(m => m.ID == id);
            if (qawwali == null)
            {
                return NotFound();
            }
            else
            {
                Qawwali = qawwali;
            }
            return Page();
        }
    }
}
