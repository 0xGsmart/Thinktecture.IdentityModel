﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Thinktecture.IdentityModel.Client
{
    public class UserInfoClient
    {
        private readonly HttpClient _client;

        public UserInfoClient(Uri endpoint, string token)
            : this(endpoint, token, new HttpClientHandler())
        { }

        public UserInfoClient(Uri endpoint, string token, HttpClientHandler inneHttpClientHandler)
        {
            if (endpoint == null)
                throw new ArgumentNullException("endpoint");

            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException("token");

            if (inneHttpClientHandler == null)
                throw new ArgumentNullException("inneHttpClientHandler");

            _client = new HttpClient(inneHttpClientHandler)
            {
                BaseAddress = endpoint
            };

            _client.SetBearerToken(token);
        }

        public async Task<UserInfoResponse> GetAsync()
        {
            var response = await _client.GetAsync("");

            if (response.StatusCode != HttpStatusCode.OK)
                return new UserInfoResponse(response.StatusCode, response.ReasonPhrase);

            var content = await response.Content.ReadAsStringAsync();
            return new UserInfoResponse(content);
        }
    }
}
