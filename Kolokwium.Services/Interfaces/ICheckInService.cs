using Kolokwium.Model;
using Kolokwium.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Interfaces
{
    public interface ICheckInService
    {
        public IList<CheckInVm> GetCheckIns(Expression<Func<CheckIn, bool>> filterPredicate = null);
        public CheckInVm GetCheckIn(Expression<Func<CheckIn, bool>> filterPredicate);
        public void AddCheckIn(CheckInVm clientVm);
    }
}
