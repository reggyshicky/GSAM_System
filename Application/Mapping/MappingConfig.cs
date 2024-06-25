using Application.CaseManagement.Commands;
using Application.CaseManagement.Dto;
using Application.CaseManagement.Dto.RecoverDtos;
using Application.CaseManagement.RecoverCommands;
using Application.ClaimManagement.ExternalClaim.Commands;
using Application.ClaimManagement.ExternalClaim.Dto;
using Application.ClaimManagement.InternalClaim.Commands;
using Application.ClaimManagement.InternalClaim.Dto;
using Application.CsseManagement.Dtos;
using Application.DocumentManagement.Commands;
using Application.FileManagement.Dtos;
using Application.RefinanceMngt.Commands;
using Application.RefinanceMngt.Dto;
using Application.RestructureManagement.Commands;
using Application.RestructureManagement.Dtos;
using Application.ServiceManagement.Commands;
using Application.ServiceManagement.Dto;
using Application.UserManagement.Dto;
using AutoMapper;
using Domain.Entities.CaseMgnt;
using Domain.Entities.ClaimMngt;
using Domain.Entities.DocumentMngt;
using Domain.Entities.RecoverMngt;
using Domain.Entities.RefinanceMngt;
using Domain.Entities.RestructureMgnt;
using Domain.Entities.ServiceMngt;
using Domain.Entities.UserMngt;
using System.Reflection.Metadata;

namespace Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Case, AddCaseCommand>().ReverseMap();
            CreateMap<Case, CaseResponseDto>().ReverseMap();
            CreateMap<Case, UpdateDto>().ReverseMap();
            CreateMap<Restructure, AddRestructureCommand>().ReverseMap();
            CreateMap<Recover, AddRecoverCommand>().ReverseMap();
            CreateMap<Restructure, RestructureResponseDto>().ReverseMap();
            CreateMap<Recover, RecoverResponseDto>().ReverseMap();

            CreateMap<Service, AddServiceCommand>().ReverseMap();
            CreateMap<Service, ServiceResponseDto>().ReverseMap();
            CreateMap<Region, RegionResponseDto>().ReverseMap();
            CreateMap<Region, AddRegionCommand>().ReverseMap();
            CreateMap<ServiceProvider, ServiceProviderResponseDto>().ReverseMap();
            CreateMap<ServiceProvider, AddServiceProviderCommand>().ReverseMap();
            CreateMap<ServiceBooking, AddServiceBookingCommand>().ReverseMap();
            CreateMap<ApplicationUser, GetUserDto>().ReverseMap();

            CreateMap<Documents, DocumentResponseDto>().ReverseMap();
            CreateMap<Documents, UploadDocumentCommand>().ReverseMap();

            CreateMap<Refinance, AddRefinanceCommand>().ReverseMap();
            CreateMap<Refinance, RefinanceDto>().ReverseMap();
            CreateMap<Internal, InternalResponseDto>().ReverseMap();
            CreateMap<Internal, AddInternalCommand>().ReverseMap();
            CreateMap<External, ExternalResponseDto>().ReverseMap();
            CreateMap<External, AddExternalCommand>().ReverseMap();
            CreateMap<ServiceBooking, BookingResponse>().ReverseMap();
            CreateMap<ServiceBooking, ServiceBookingDto>().ReverseMap();
        }
    }
}
