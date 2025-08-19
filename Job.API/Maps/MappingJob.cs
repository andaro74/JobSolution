using AutoMapper;
using Job.API.DTOs;
using Job.API.Models;

namespace Job.API.Maps
{
   
    public class MappingJob: Profile
    {
        public MappingJob()
        {
            // Map JobItemRequestDTO to JobItem
            /*
            cfg.CreateMap<JobItemRequestDTO, JobItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "New"))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => "Normal"));
            */
            // Map JobItem to JobItemDTO
            CreateMap<JobItem, JobItemDTO>();
        }   
    }
}
