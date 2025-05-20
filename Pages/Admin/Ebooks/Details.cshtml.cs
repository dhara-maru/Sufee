using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUFEEASP.Data;
using SUFEEASP.Model;

namespace SUFEEASP.Pages.Admin.Ebooks
{
    public class DetailsModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public DetailsModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        public Ebook Ebook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ebook = await _context.Ebook.FirstOrDefaultAsync(m => m.ID == id);
            if (ebook == null)
            {
                return NotFound();
            }
            else
            {
                Ebook = ebook;
            }
            return Page();
        }
    }
}
