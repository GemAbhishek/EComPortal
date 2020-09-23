﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EComPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EComPortal.Controllers
{
    public class CheckController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44388/api");
        HttpClient client;
        public CheckController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            string token = TokenInfo.StringToken;           
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response;
            try
            {
                response = client.GetAsync(client.BaseAddress + "/check").Result;
            }
            catch
            {
                return Content("Unauthorize");
            }
            if (response.IsSuccessStatusCode)
            {
                string s = response.Content.ReadAsStringAsync().Result;

                return Content("Ok checked with stored token"+"----"+s);
                
            }

            return Content("Unauthorize");

        }
    }
}