﻿
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Service.IService;

namespace HelpingHands_Web.Service
	public class AuthService : BaseService, IAuthService
		private readonly IHttpClientFactory _clientFactory;
		private string categoryUrl;

		public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
		{
			_clientFactory = clientFactory;
			categoryUrl = configuration.GetValue<string>("ServiceUrls:HelpingHandAPI");

		}

		public Task<T> LoginAsync<T>(LoginRequestDTO obj)