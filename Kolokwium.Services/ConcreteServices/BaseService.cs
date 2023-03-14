using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.DAL;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext DbContext;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        public BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        {
            DbContext = dbContext;
            Logger = logger;
            Mapper = mapper;
        }
    }
}
