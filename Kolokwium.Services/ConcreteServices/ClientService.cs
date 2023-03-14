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
    public class ClientService : BaseService, IClientService
    {
        public ClientService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public void AddCheckInToClient(AddCheckInToClientVm addCheckInToClientVm)
        {
            try
            {
                var client = DbContext.Users.OfType<Client>().FirstOrDefault(x => x.Id == addCheckInToClientVm.ClientId);
                var checkIn = DbContext.CheckIns.FirstOrDefault(x => x.Id == addCheckInToClientVm.CheckInId);
                checkIn.ClientId = client.Id;
                client.CheckIns.Add(checkIn);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public void AddClient(ClientVm clientVm)
        {
            try
            {
                if (clientVm is null)
                    throw new ArgumentNullException(nameof(clientVm));
                DbContext.Users.Add(Mapper.Map<Client>(clientVm));
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void DeleteClient(int Id)
        {
            try
            {
                var client = DbContext.Users.OfType<Client>().FirstOrDefault(x => x.Id == Id);
                if (client == null)
                    throw new ArgumentNullException(nameof(client));
                
                DbContext.Users.Remove(client);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public ClientVm GetClient(Expression<Func<Client, bool>> filterPredicate)
        {
            try
            {
                var client = DbContext.Users.OfType<Client>().FirstOrDefault(filterPredicate);
                if (client == null)
                    throw new Exception("Client is null");

                return Mapper.Map<ClientVm>(client);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IList<ClientVm> GetClients(Expression<Func<Client, bool>> filterPredicate = null)
        {
            try
            {
                if (filterPredicate == null)
                    return Mapper.Map<IList<ClientVm>>(DbContext.Users.OfType<Client>().ToList());
                return Mapper.Map<IList<ClientVm>>(DbContext.Users.OfType<Client>().Where(filterPredicate).ToList());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void UpdateClient(int Id, ClientVm clientVm)
        {
            try
            {
                var client = DbContext.Users.OfType<Client>().FirstOrDefault(x => x.Id == Id);
                if (client == null)
                    throw new ArgumentNullException(nameof(client));
                client.FirstName = clientVm.FirstName;
                client.LastName = clientVm.LastName;
                client.Adress = clientVm.Adress;
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        
    }
}
