using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyShowEntity
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }




        [ForeignKey("ShowTiming")]
        public int ShowTimingId { get; set; }
        public ShowTiming showTiming { get; set; }



        public int BookingQuantity { get; set; }
    }
}
