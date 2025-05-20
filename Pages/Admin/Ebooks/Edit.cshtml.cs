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

namespace SUFEEASP.Pages.Admin.Ebooks
{
    public class EditModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public EditModel(SUFEEASP.Data.SUFEEASPContext context)
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

            var ebook =  await _context.Ebook.FirstOrDefaultAsync(m => m.ID == id);
            if (ebook == null)
            {
                return NotFound();
            }
            Ebook = ebook;
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

            _context.Attach(Ebook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EbookExists(Ebook.ID))
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

        private bool EbookExists(int id)
        {
            return _context.Ebook.Any(e => e.ID == id);
        }
    }
}
