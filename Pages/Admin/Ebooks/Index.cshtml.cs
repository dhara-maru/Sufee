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
    public class IndexModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public IndexModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        public IList<Ebook> Ebook { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Ebook = await _context.Ebook.ToListAsync();
        }
    }
}
