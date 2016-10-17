using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class AlbumAddForm
    {
        [Required]
        [StringLength(30)]
        public String Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(20)]
        public SelectList Genre { get; set; }

        [Required]
        public double LengthInMinutes { get; set; }

        [Required]
        [StringLength(30)]
        public String Producer { get; set; }

        [Required]
        [StringLength(100)]
        public String AlbumCoverUrl { get; set; }
        public String ArtistId { get; set; }

        public SelectList Artists { get; set; }
    }

    public class AlbumList
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }

    public class AlbumAdd
    {
        [Required]
        [StringLength(30)]
        public String Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(20)]
        public String Genre { get; set; }

        [Required]
        public double LengthInMinutes { get; set; }

        [Required]
        [StringLength(30)]
        public String Producer { get; set; }

        [Required]
        [StringLength(100)]
        public String AlbumCoverUrl { get; set; }
        public int ArtistId { get; set; }

    }

    public class AlbumBase : AlbumAdd
    {
        public int Id { get; set; }
        public String ArtistName { get; set; }

    }
}