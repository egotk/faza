using AutoMapper;
using test_Faza.api.dto.entityDTO;
using test_Faza.database.entities;

namespace test_Faza.DI.mapper
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Interface, InterfaceDTO>().ReverseMap();
            CreateMap<Device, DeviceDTO>().ReverseMap();
            CreateMap<Register, RegisterDTO>().ReverseMap();
            CreateMap<RegisterValue, RegisterValueDTO>().ReverseMap();
        }
    }
}
