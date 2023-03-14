using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.ConcreteServices
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public void AddRoom(RoomVm roomVm)
        {
            try
            {
                if (roomVm is null)
                    throw new ArgumentNullException(nameof(roomVm));
                DbContext.Rooms.Add(Mapper.Map<Room>(roomVm));
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public RoomVm GetRoom(Expression<Func<Room, bool>> filterPredicate)
        {
            try
            {
                var room = DbContext.Rooms.OfType<Room>().FirstOrDefault(filterPredicate);
                if (room == null)
                    throw new Exception("Client in null");

                return Mapper.Map<RoomVm>(room);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IList<RoomVm> GetRooms(Expression<Func<Room, bool>> filterPredicate = null)
        {
            try
            {
                if (filterPredicate == null)
                    return Mapper.Map<IList<RoomVm>>(DbContext.Rooms.ToList());
                return Mapper.Map<IList<RoomVm>>(DbContext.Rooms.Where(filterPredicate).ToList());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
