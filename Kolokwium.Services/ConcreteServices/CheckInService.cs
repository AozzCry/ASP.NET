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
    public class CheckInService : BaseService, ICheckInService
    {
        public CheckInService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public void AddCheckIn(CheckInVm checkInVm)
        {
            try
            {
                if (checkInVm is null)
                    throw new ArgumentNullException(nameof(checkInVm));
                DbContext.CheckIns.Add(Mapper.Map<CheckIn>(checkInVm));
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IList<CheckInVm> GetCheckIns(Expression<Func<CheckIn, bool>> filterPredicate)
        {
            try
            {
                if (filterPredicate == null)
                    return Mapper.Map<IList<CheckInVm>>(DbContext.CheckIns.ToList());
                return Mapper.Map<IList<CheckInVm>>(DbContext.CheckIns.Where(filterPredicate).ToList());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public CheckInVm GetCheckIn(Expression<Func<CheckIn, bool>> filterPredicate)
        {
            try
            {
                var checkIn = DbContext.Users.OfType<CheckIn>().FirstOrDefault(filterPredicate);
                if (checkIn == null)
                    throw new Exception("Client in null");

                return Mapper.Map<CheckInVm>(checkIn);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
