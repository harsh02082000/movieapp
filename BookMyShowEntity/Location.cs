using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyShowEntity
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Theatre")]
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
        public string Place { get; set; }

       
    }
}
