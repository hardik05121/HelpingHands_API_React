using AutoMapper;
using HelpingHands_API.Models;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHands_API.Controllers.v1
{
    public class HomeAPIController : Controller
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeAPIController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = new();
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
