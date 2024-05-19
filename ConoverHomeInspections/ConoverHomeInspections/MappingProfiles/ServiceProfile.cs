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
        }
    }
}