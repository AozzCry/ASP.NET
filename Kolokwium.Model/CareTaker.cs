using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model
{
    public class CareTaker : User
    {
        public virtual IList<Room> Rooms { get; set; }
        public virtual IList<Client> Clients { get; set; }
    }
}