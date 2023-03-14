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
    public interface IClientService
    {
        public IList<ClientVm> GetClients(Expression<Func<Client, bool>> filterPredicate = null);
        public ClientVm GetClient(Expression<Func<Client, bool>> filterPredicate);
        public void AddClient(ClientVm clientVm);
        public void UpdateClient(int Id, ClientVm clientVm);
        public void DeleteClient(int Id);
        public void AddCheckInToClient(AddCheckInToClientVm addCheckInToClientVm);
    }
}
