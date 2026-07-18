using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesManga.Models;

    public class Manga
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Display(Name = "Volume Count")]
        public int VolumeCount { get; set; }
        public string Rating { get; set; } = string.Empty;
    }
