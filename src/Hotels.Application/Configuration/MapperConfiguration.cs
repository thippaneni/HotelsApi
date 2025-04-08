using Hotels.Application.Dtos;
using Hotels.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Configuration
{
    public static class MapperConfiguration
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Hotel, HotelDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.Stars, src => src.Stars)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Reviews, src => src.Reviews)
                .Map(dest => dest.CreateAt, src => src.CreateAt)
                .Map(dest => dest.LastModified, src => src.LastModified)
                .Map(dest => dest.CreatedBy, src => src.CreatedBy)
                .Map(dest => dest.LastUdpatedBy, src => src.LastUdpatedBy);

            TypeAdapterConfig<Review, ReviewDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.ReviewerName, src => src.ReviewerName)
                .Map(dest => dest.Comment, src => src.Comment)
                .Map(dest => dest.Rating, src => src.Rating)
                .Map(dest => dest.HotelId, src => src.HotelId)
                .Map(dest => dest.CreateAt, src => src.CreateAt)
                .Map(dest => dest.LastModified, src => src.LastModified)
                .Map(dest => dest.CreatedBy, src => src.CreatedBy)
                .Map(dest => dest.LastUdpatedBy, src => src.LastUdpatedBy);

        }
    }
}
