using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUFEEASP.Data;
using SUFEEASP.Model;

namespace SUFEEASP.Pages.Admin.Ebooks
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
        public Ebook Ebook { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ebook.Add(Ebook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
