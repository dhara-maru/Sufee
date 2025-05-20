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
    public class DeleteModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public DeleteModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ebook = await _context.Ebook.FindAsync(id);
            if (ebook != null)
            {
                Ebook = ebook;
                _context.Ebook.Remove(Ebook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
