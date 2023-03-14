using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model
{
    public class RoomCheckIn
    {
        public virtual Room Room { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual CheckIn CheckIn { get; set; }
        [ForeignKey("CheckIn")]
        public int CheckInId { get; set; }
    }
}
