using AutoMapper;
using HelpingHands_Web.Models.DTO;

namespace HelpingHands_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<AmenityDTO, AmenityCreateDTO>().ReverseMap();
            CreateMap<AmenityDTO, AmenityUpdateDTO>().ReverseMap();

            CreateMap<CityDTO, CityCreateDTO>().ReverseMap();
            CreateMap<CityDTO, CityUpdateDTO>().ReverseMap();

            CreateMap<CompanyImageDTO, CompanyImageCreateDTO>().ReverseMap();
            CreateMap<CompanyImageDTO, CompanyImageUpdateDTO>().ReverseMap();

            CreateMap<CompanyDTO, CompanyCreateDTO>().ReverseMap();
            CreateMap<CompanyDTO, CompanyUpdateDTO>().ReverseMap();

            CreateMap<CompanyXAmenityDTO, CompanyXAmenityCreateDTO>().ReverseMap();
            CreateMap<CompanyXAmenityDTO, CompanyXAmenityUpdateDTO>().ReverseMap();

            CreateMap<CompanyXPaymentDTO, CompanyXPaymentCreateDTO>().ReverseMap();
            CreateMap<CompanyXPaymentDTO, CompanyXPaymentUpdateDTO>().ReverseMap();

            CreateMap<CompanyXServiceDTO, CompanyXServiceCreateDTO>().ReverseMap();
            CreateMap<CompanyXServiceDTO, CompanyXServiceUpdateDTO>().ReverseMap();

            CreateMap<CountryDTO, CountryCreateDTO>().ReverseMap();
            CreateMap<CountryDTO, CountryUpdateDTO>().ReverseMap();

           
            CreateMap<FirstCategoryDTO, FirstCategoryCreateDTO>().ReverseMap();
            CreateMap<FirstCategoryDTO, FirstCategoryUpdateDTO>().ReverseMap();

            CreateMap<PaymentDTO, PaymentCreateDTO>().ReverseMap();
            CreateMap<PaymentDTO, PaymentUpdateDTO>().ReverseMap();

            CreateMap<ReviewDTO, ReviewCreateDTO>().ReverseMap();
            CreateMap<ReviewDTO, ReviewUpdateDTO>().ReverseMap();

            CreateMap<SecondCategoryDTO, SecondCategoryCreateDTO>().ReverseMap();
            CreateMap<SecondCategoryDTO, SecondCategoryUpdateDTO>().ReverseMap();

            CreateMap<ReviewXCommentDTO, ReviewXCommentCreateDTO>().ReverseMap();
            CreateMap<ReviewXCommentDTO, ReviewXCommentUpdateDTO>().ReverseMap();

            CreateMap<ServiceDTO, ServiceCreateDTO>().ReverseMap();
            CreateMap<ServiceDTO, ServiceUpdateDTO>().ReverseMap();

            CreateMap<StateDTO, StateCreateDTO>().ReverseMap();
            CreateMap<StateDTO, StateUpdateDTO>().ReverseMap();

            CreateMap<ThirdCategoryDTO, ThirdCategoryCreateDTO>().ReverseMap();
            CreateMap<ThirdCategoryDTO, ThirdCategoryUpdateDTO>().ReverseMap();

        }
    }
}
