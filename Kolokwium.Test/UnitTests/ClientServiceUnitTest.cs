using Kolokwium.DAL;
using Kolokwium.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kolokwium.Test.UnitTests
{
    public class ClientServiceUnitTest : BaseUnitTests
    {
        private readonly IClientService _clientService;
        public ClientServiceUnitTest(ApplicationDbContext dbContext, IClientService clientService) : base(dbContext)
        {
            _clientService = clientService;
        }
        [Fact]
        public void GetClient()
        {
            var client = _clientService.GetClient(s => s.Id == 1);
            Assert.NotNull(client);
        }
        [Fact]
        public void GetClients()
        {
            var clients = _clientService.GetClients();
            DbContext.Users.Count();
            Assert.NotNull(clients);
            Assert.NotEmpty(clients);
            Assert.Equal(3, DbContext.Users.Count());
        }
    }
}
