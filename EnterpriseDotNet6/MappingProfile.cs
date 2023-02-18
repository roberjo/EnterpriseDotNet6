using AutoMapper;
using EnterpriseDotNet6.Entities.DataTransferObjects;
using EnterpriseDotNet6.Entities.Models;

namespace EnterpriseDotNet6.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();

            CreateMap<Account, AccountDto>();

            CreateMap<OwnerForCreationDto, Owner>();

            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
