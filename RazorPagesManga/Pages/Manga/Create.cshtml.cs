using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesManga.Data;
using RazorPagesManga.Models;

namespace RazorPagesManga.Pages_Manga
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesManga.Data.RazorPagesMangaContext _context;

        public CreateModel(RazorPagesManga.Data.RazorPagesMangaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Manga Manga { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Manga.Add(Manga);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
