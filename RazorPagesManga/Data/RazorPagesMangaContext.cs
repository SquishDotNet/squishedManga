using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesManga.Models;

namespace RazorPagesManga.Data
{
    public class RazorPagesMangaContext : DbContext
    {
        public RazorPagesMangaContext (DbContextOptions<RazorPagesMangaContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesManga.Models.Manga> Manga { get; set; } = default!;
    }
}
