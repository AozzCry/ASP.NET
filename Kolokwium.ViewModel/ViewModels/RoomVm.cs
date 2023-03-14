using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.ViewModel.ViewModels
{
    public class RoomVm
    {
        public int Id { get; set; }
        public int RoomNr { get; set; }
        public int MaxPeople { get; set; }
        public IList<CheckInVm> CheckIns { set; get; }
    }
}
