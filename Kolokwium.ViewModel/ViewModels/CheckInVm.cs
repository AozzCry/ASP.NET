using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.ViewModel.ViewModels
{
    public class CheckInVm
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public int RoomNr { get; set; }
        public DateTime Data { get; set; }
    }
}
