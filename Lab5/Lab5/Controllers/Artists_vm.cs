using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class ArtistAddForm
    {
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
        public SelectList Genre { get; set; }

    }

    public class ArtistList
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }

    public class ArtistAdd
    {
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

    }

    public class ArtistBase : ArtistAdd
    {
        public int Id { get; set; }
    }
}