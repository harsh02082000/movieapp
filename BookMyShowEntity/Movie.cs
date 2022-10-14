using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowEntity
{
    public class Movie
    {
        [Key] //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto generated col
        public int Id { get; set; }
        public string Name { get; set; }
        public string MovieDesc { get; set; }
        public string MovieType { get; set; }
    }
}
