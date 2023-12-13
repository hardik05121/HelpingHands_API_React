﻿using HelpingHands_Utility;using HelpingHands_Web.Models;using HelpingHands_Web.Models.DTO;using HelpingHands_Web.Models.VM;using HelpingHands_Web.Service.IService;namespace HelpingHands_Web.Service{    public class ReviewXCommentService : BaseService, IReviewXCommentService    {        private readonly IHttpClientFactory _clientFactory;        private string categoryUrl;        public ReviewXCommentService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)        {            _clientFactory = clientFactory;            categoryUrl = configuration.GetValue<string>("ServiceUrls:HelpingHandAPI");        }        public Task<T> CreateAsync<T>(ReviewXCommentCreateDTO dto, string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.POST,                Data = dto,                Url = categoryUrl + "/api/v1/ReviewXCommentAPI",                Token = token            });        }        public Task<T> DeleteAsync<T>(int id, string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.DELETE,                Url = categoryUrl + "/api/v1/ReviewXCommentAPI/" + id,                Token = token            });        }        public Task<T> GetAllAsync<T>(string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.GET,                Url = categoryUrl + "/api/v1/ReviewXCommentAPI",                Token = token            });        }        public Task<T> GetAsync<T>(int id, string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.GET,                Url = categoryUrl + "/api/v1/ReviewXCommentAPI/" + id,                Token = token            });        }        public Task<T> UpdateAsync<T>(ReviewXCommentUpdateDTO dto, string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.PUT,                Data = dto,                Url = categoryUrl + "/api/v1/ReviewXCommentAPI/" + dto.Id,                Token = token            });        }    }}