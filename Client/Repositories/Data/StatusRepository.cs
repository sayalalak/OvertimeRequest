﻿using Client.Base.Urls;
using Newtonsoft.Json;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class StatusRepository : GeneralRepository<Request, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public StatusRepository(Address address, string request = "Requests/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<GetReqRequesterVM> GetById(string userId)
        {
            GetReqRequesterVM entity = new GetReqRequesterVM();

            using (var response = await httpClient.GetAsync(request + "GetRequest/" + userId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<GetReqRequesterVM>(apiResponse);
            }
            return entity;
        }
    }
}
