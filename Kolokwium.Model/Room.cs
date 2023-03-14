using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int RoomNr { get; set; }
        public int MaxPeople { get; set; }
        public virtual IList<RoomCheckIn> RoomCheckIns { set; get; }

    }
}
