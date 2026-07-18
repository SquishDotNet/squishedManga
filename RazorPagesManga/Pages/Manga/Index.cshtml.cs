using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesManga.Data;
using RazorPagesManga.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
       
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? MangaGenre { get; set; }
        public async Task OnGetAsync()
        {
            // <snippet_search_linqQuery>
            IQueryable<string> genresQuery = from m in _context.Manga
                                            orderby m.Genre
                                            select m.Genre; 
            // </snippet_search_linqQuery>

           var mangas = from m in _context.Manga
                        select m;
                        
            if (!string.IsNullOrEmpty(SearchString))
            {
                mangas = mangas.Where(s => s.Title.Contains(SearchString));
            }
           
           if (!string.IsNullOrEmpty(MangaGenre))
            {
                mangas = mangas.Where(x => x.Genre == MangaGenre);
            }

            // <snippet_search_selectList>
            Genres = new SelectList(await genresQuery.Distinct().ToListAsync());
            // </snippet_search_selectList>
           Manga = await mangas.ToListAsync();
        }
}
}