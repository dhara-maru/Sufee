using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUFEEASP.Data;
using SUFEEASP.Model;

namespace SUFEEASP.Pages.Admin.Qawwalis
{
    public class EditModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public EditModel(SUFEEASP.Data.SUFEEASPContext context)
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

            var qawwali =  await _context.Qawwali.FirstOrDefaultAsync(m => m.ID == id);
            if (qawwali == null)
            {
                return NotFound();
            }
            Qawwali = qawwali;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Qawwali).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QawwaliExists(Qawwali.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QawwaliExists(int id)
        {
            return _context.Qawwali.Any(e => e.ID == id);
        }
    }
}
