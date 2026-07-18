 using Microsoft.EntityFrameworkCore;
 using RazorPagesManga.Data;

 namespace RazorPagesManga.Models;

 public static class SeedData
{
     public static void Initialize(IServiceProvider serviceProvider)
    {
     using (var context = new RazorPagesMangaContext(
         serviceProvider.GetRequiredService<
         DbContextOptions<RazorPagesMangaContext>>()))
{
    if (context == null || context.Manga == null)
    {
        throw new ArgumentNullException("Null RazorPagesMangaContext");
    }
    // Look for any manga.
    if (context.Manga.Any())
    {
        return;   // DB has been seeded
    }
    context.Manga.AddRange(
        new Manga
        {
        Title = "Sketchy",
        Author= "Makihirochi",
        Genre = "Slice of Life",
        VolumeCount = 6,
        Rating = "Teen",
        },

        new Manga
        {
        Title = "Don't Toy With Me, Miss Nagatoro",
        Author = "Nanashi",
        Genre = "Romantic Comedy",
        VolumeCount = 20,
        Rating = "Teen",
       },

        new Manga
        {
        Title = "Bloom Into You",
        Author = "Nanashi",
        Genre = "Yuri",
        VolumeCount = 8,
        Rating = "Teen",
        }
    );
    context.SaveChanges();
}
}
}
