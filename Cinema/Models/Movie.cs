using Cinema.EntityBases;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public List<Actor> Actors { get; set; }
        public int ActorId { get; set; }
    }
}