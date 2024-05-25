// ConoverHomeInspections
// ServiceProfile.cs
//  2024
// Oliver Conover
// Modified: 19-05-2024
using AutoMapper;
using ConoverHomeInspections.Shared;

namespace ConoverHomeInspections
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<SiteGroup, ServiceGroupDTO>();
            CreateMap<ServiceGroupDTO, SiteGroup>();
            CreateMap<SiteService, ServiceDTO>();
            CreateMap<ServiceDTO, SiteService>();
            CreateMap<ServiceDetail, ServiceDetailDTO>();
            CreateMap<ServiceDetailDTO, ServiceDetail>();
            CreateMap<ClientContactDTO, ClientContact>()
                .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName.ToUpperInvariant()))
                .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.LastName.ToUpperInvariant()))
                .ForMember(dest => dest.EmailAddress, o => o.MapFrom(src => src.EmailAddress.ToUpperInvariant()))
                .ForMember(dest => dest.RealtorFirstName, o => o.MapFrom(src => src.RealtorFirstName.ToUpperInvariant()))
                .ForMember(dest => dest.RealtorLastName, o => o.MapFrom(src => src.RealtorLastName.ToUpperInvariant()))
                .ForMember(dest => dest.RealtorEmail, o => o.MapFrom(src => src.RealtorEmail.ToUpperInvariant()))
                .ForMember(dest => dest.MiddleInitial, o => o.MapFrom(src => src.MiddleInitial.ToUpperInvariant().FirstOrDefault()))
                .ForMember(dest => dest.MailingAddress, o => o.MapFrom(src => src.MailingAddress.ToString()))
                .ForMember(dest => dest.PreferredStart, o => o.MapFrom(src => src.InspectionDateRange.Start))
                .ForMember(dest => dest.PreferredEnd, o => o.MapFrom(src => src.InspectionDateRange.End))
                .ForMember(dest => dest.Notes, o => o.MapFrom(src => src.Message))
                .ForMember(dest => dest.InspectionAddress, o => o.MapFrom(src => src.InspectionPropertyAddress.ToString()));
            // CreateMap<ClientContact, ClientContactDTO>()
            //     .ForMember(dest => dest.InspectionDateRange.Start, o => o.MapFrom(src => src.PreferredStart))
            //     .ForMember(dest => dest.InspectionDateRange.End, o => o.MapFrom(src => src.PreferredEnd))
            //     .;
        }
    }
}