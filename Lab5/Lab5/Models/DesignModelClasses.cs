using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Lab5.Models
{
    public class Artist
    {
        public Artist() {
            this.Albums = new List<Album>();
            this.BirthOrStartDate = DateTime.Today;
        }

        public int Id { get; set; }
        
        [Required]
        [StringLength(30)]
        public String Name { get; set; }

        [Required]
        [StringLength(30)]
        public String BirthName { get; set; }

        [Required]
        public DateTime BirthOrStartDate { get; set; }

        [Required]
        public int StartDecade { get; set; }

        [Required]
        [StringLength(10)]
        public String Genre { get; set; }
        public ICollection<Album> Albums { get; set; }
         
    }

    public class Album
    {
        public Album() {
            this.Songs = new List<Song>();
            this.ReleaseDate = DateTime.Today;
        }
        public int Id { get; set; }

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

        public ICollection<Song> Songs { get; set; }
        public Artist Artist { get; set; }

    }

    public class Song
    {
        public Song() {
            this.ReleaseDateAsSingle = DateTime.Today;
        }

        public int Id { get; set; }

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
        public int TrackNumber  { get; set; }
        public Album Album { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(20)]
        public String Name { get; set; }
    }


}