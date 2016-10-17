using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class SongAddForm
    {
        [Required]
        [StringLength(30)]
        public String Name { get; set; }

        [Required]
        [StringLength(30)]
        public String Composer { get; set; }

        [Required]
        [StringLength(20)]
        public SelectList Genre { get; set; }

        public DateTime? ReleaseDateAsSingle { get; set; }

        [Required]
        public int TrackNumber { get; set; }
        public String AlbumId { get; set; }
        public SelectList Albums { get; set; }

    }

    public class SongList
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }

    public class SongAdd
    {

        [Required]
        [StringLength(30)]
        public String Name { get; set; }

        [Required]
        [StringLength(30)]
        public String Composer { get; set; }

        [Required]
        [StringLength(20)]
        public String Genre { get; set; }

        public DateTime? ReleaseDateAsSingle { get; set; }

        [Required]
        public int TrackNumber { get; set; }
        public int AlbumId { get; set; }

    }

    public class SongBase : SongAdd
    {
        public int Id { get; set; }
        public String AlbumName { get; set; }
    }
}