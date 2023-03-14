using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Model
{
    public class CheckIn
    {
        [Key]
        public int Id { get; set; }
        public double Cost { get; set; }
        public DateTime Data { get; set; }
        public virtual Client Client { get; set; }
        public int? ClientId { get; set; }
        public virtual IList<RoomCheckIn> RoomCheckIns { set; get; }
    }
}