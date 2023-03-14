using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.Model;
using Kolokwium.ViewModel.ViewModels;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            //AutoMapper maps
            CreateMap<Client, ClientVm>().ReverseMap();
            CreateMap<Room, RoomVm>().ReverseMap();
            CreateMap<CheckIn, CheckInVm>().ReverseMap();
        }
    }
}
