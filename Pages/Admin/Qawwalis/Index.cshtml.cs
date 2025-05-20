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
    public class IndexModel : PageModel
    {
        private readonly SUFEEASP.Data.SUFEEASPContext _context;

        public IndexModel(SUFEEASP.Data.SUFEEASPContext context)
        {
            _context = context;
        }

        public IList<Qawwali> Qawwali { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Qawwali = await _context.Qawwali.ToListAsync();
        }
    }
}
