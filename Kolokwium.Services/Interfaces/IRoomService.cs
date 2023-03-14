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
    public interface IRoomService
    {
        public IList<RoomVm> GetRooms(Expression<Func<Room, bool>> filterPredicate = null);
        public RoomVm GetRoom(Expression<Func<Room, bool>> filterPredicate);
        public void AddRoom(RoomVm roomVm);
    }
}
