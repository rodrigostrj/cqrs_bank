using AutoMapper;
using SaltpayBank.Application.Models;
using SaltpayBank.Domain.AccountAggregate;

namespace SaltpayBank.Application.Mappers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Account, CustomerDTO>();
            CreateMap<Account, AccountDTO>();
        }
    }
}
