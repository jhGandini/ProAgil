using System;
using AutoMapper;
using ProAgil.Domain.Dtos;
using ProAgil.Domain.Entities;
using ProAgil.Domain.ValueObjects;

namespace ProAgil.Infra.CrossCutting
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dto => dto.Lots, map => map.MapFrom(m => m.Lots))

                .ForMember(dto => dto.LastUpdateDate, map => map.MapFrom(m => m.MaintenanceDate.LastUpdateDate))
                .ForMember(dto => dto.RegisterDate, map => map.MapFrom(m => m.MaintenanceDate.RegisterDate))

                .ForMember(dto => dto.Street, map => map.MapFrom(m => m.Address.Street))
                .ForMember(dto => dto.Number, map => map.MapFrom(m => m.Address.Number))
                .ForMember(dto => dto.Neigborhood, map => map.MapFrom(m => m.Address.Neigborhood))
                .ForMember(dto => dto.City, map => map.MapFrom(m => m.Address.City))
                .ForMember(dto => dto.State, map => map.MapFrom(m => m.Address.State))
                .ForMember(dto => dto.Country, map => map.MapFrom(m => m.Address.Country))
                .ForMember(dto => dto.ZipCode, map => map.MapFrom(m => m.Address.ZipCode))

                .ForMember(dto => dto.Active, map => map.MapFrom(m => m.Activater.Active))

                .ForMember(dto => dto.Notifications, map => map.MapFrom(m => m.Notifications))
                .ForMember(dto => dto.Invalid, map => map.MapFrom(m => m.Invalid))
                .ForMember(dto => dto.Valid, map => map.MapFrom(m => m.Valid))

                .ReverseMap()
                .ForMember(m => m.Lots, o => o.Ignore())
                .AfterMap((dto, m) =>
                    {
                        foreach (var LotDto in dto.Lots)
                        {
                            m.AddLot(new Lot(null, LotDto.Description, LotDto.CurrentEvent, m, new Activater(LotDto.Active)));
                        }
                    }
                );

            CreateMap<Lot, LotDto>()
                .ForMember(dto => dto.Active, map => map.MapFrom(m => m.Activater.Active))
                .ReverseMap();

            // CreateMap<ApplicationUser, UserViewModel>()
            //     .ForMember(dto => dto.Claims, map => map.MapFrom(m => m.Claims))
            //     .ForMember(dto => dto.name, map => map.MapFrom(m => m.Claims.Find(c => c.ClaimType.Equals("name")).ClaimValue)).ReverseMap();

            //CreateMap<IdentityClaim, IdentityClaimViewModel>().ReverseMap();
        }
    }
}
