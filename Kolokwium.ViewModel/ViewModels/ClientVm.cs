using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.ViewModel.ViewModels
{
    public class ClientVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public double CheckInSum { set; get; }
        public IList<CheckInVm> CheckIns { get; set; }

    }
}
