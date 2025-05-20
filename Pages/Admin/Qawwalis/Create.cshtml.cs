using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUFEEASP.Data;
using SUFEEASP.Model;

namespace SUFEEASP.Pages.Admin.Qawwalis
{
    public class CreateModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public CreateModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Qawwali Qawwali { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Qawwali.Add(Qawwali);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
