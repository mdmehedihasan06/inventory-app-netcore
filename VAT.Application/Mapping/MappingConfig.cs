using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Domain.Dtos;
using VAT.Domain.Entities.Account;

namespace VAT.Application.Mapping
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<User, UserDto>.NewConfig();

            //TypeAdapterConfig<User, UserDto>.NewConfig()
            //    .Map(dest => dest.UserId, src => src.UserId)
            //    .Map(dest => dest.Password, src => src.Password);
        }
    }
}
