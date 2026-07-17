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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesManga.Data.RazorPagesMangaContext _context;

        public DetailsModel(RazorPagesManga.Data.RazorPagesMangaContext context)
        {
            _context = context;
        }

        public Manga Manga { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga.FirstOrDefaultAsync(m => m.Id == id);

            if (manga is not null)
            {
                Manga = manga;

                return Page();
            }

            return NotFound();
        }
    }
}
