using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesManga.Data;
using RazorPagesManga.Models;

namespace RazorPagesManga.Pages_Manga
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesManga.Data.RazorPagesMangaContext _context;

        public IndexModel(RazorPagesManga.Data.RazorPagesMangaContext context)
        {
            _context = context;
        }

        public IList<Manga> Manga { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Manga = await _context.Manga.ToListAsync();
        }
    }
}
