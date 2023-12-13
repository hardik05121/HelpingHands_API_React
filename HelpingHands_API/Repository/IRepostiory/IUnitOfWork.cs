
using HelpingHands_API.Models;
using HelpingHands_API.Repository.IRepostiory;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory{    public interface IUnitOfWork    {
        //ICategoryRepository Category { get; }
        IAmenityRepository Amenity { get; }        ICityRepository City { get; }        ICompanyImageRepository CompanyImage { get; }        ICompanyRepository Company { get; }        ICompanyXAmenityRepository CompanyXAmenity { get; }        ICompanyXPaymentRepository CompanyXPayment { get; }        ICompanyXServiceRepository CompanyXService { get; }        ICountryRepository Country { get; }        IEnquiryRepository Enquiry { get; }        IFirstCategoryRepository FirstCategory { get; }        IPaymentRepository Payment { get; }

        ISecondCategoryRepository SecondCategory { get; }
        IServiceRepository Service { get; }        IReviewRepository Review { get; }        IReviewXCommentRepository ReviewXComment { get; }        IStateRepository State { get; }
        IThirdCategoryRepository ThirdCategory { get; }

        IApplicationUserRepository ApplicationUser { get; }
        IApplicationRoleRepository ApplicationRole { get; }
        IApplicationUserRoleRepository ApplicationUserRole { get; }
        IUserRepository User { get; }


        void Save();    }}
