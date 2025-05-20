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
    public class DeleteModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public DeleteModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writer.FindAsync(id);
            if (writer != null)
            {
                Writer = writer;
                _context.Writer.Remove(Writer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
