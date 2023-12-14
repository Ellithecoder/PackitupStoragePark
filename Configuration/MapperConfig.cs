using AutoMapper;
using PackitupStoragePark.Data;
using PackitupStoragePark.Models;

namespace PackitupStoragePark.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<StorageUnit, StorageUnitVM>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();
        }
    }
}
