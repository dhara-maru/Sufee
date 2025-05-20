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
    public class DeleteModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public DeleteModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qawwali = await _context.Qawwali.FindAsync(id);
            if (qawwali != null)
            {
                Qawwali = qawwali;
                _context.Qawwali.Remove(Qawwali);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
