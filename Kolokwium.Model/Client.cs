using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model
{
    public class Client : User
    {
        public virtual CareTaker CareTaker { get; set; }
        [ForeignKey("CareTaker")]
        public int? CareTakerId { get; set; }
        public virtual IList<CheckIn> CheckIns { get; set; }
        [NotMapped]
        public double CheckInSum => CheckIns.Sum(x => (double)x.Cost);
    }
}
