using AutoMapper;
using SaltpayBank.Api.ApiContracts.Responses;
using SaltpayBank.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaltpayBank.Api.Mappers
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<AccountDTO, Balance>(); //TODO: Might be imporved
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
