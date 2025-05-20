using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SUFEEASP.Model;

namespace SUFEEASP.Data
{
    public class SUFEEASPContext : DbContext
    {
        public SUFEEASPContext (DbContextOptions<SUFEEASPContext> options)
            : base(options)
        {
        }

        public DbSet<SUFEEASP.Model.Blog> Blog { get; set; } = default!;
        public DbSet<SUFEEASP.Model.Ebook> Ebook { get; set; } = default!;

        public DbSet<SUFEEASP.Model.Myusers> Myusers { get; set; } = default!;
        public DbSet<SUFEEASP.Model.Qawwali> Qawwali { get; set; } = default!;
        public DbSet<SUFEEASP.Model.Writer> Writer { get; set; } = default!;

    }
}
