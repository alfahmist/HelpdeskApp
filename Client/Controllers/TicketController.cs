﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Context;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class TicketController : Controller
    {

        private MyContext myContext = new MyContext();
        HttpClientHandler clientHandler = new HttpClientHandler();

        OpenedTicketVM ticket = new OpenedTicketVM();
        ClosedTicketVM closedTicket = new ClosedTicketVM();

        List<OpenedTicketVM> tickets = new List<OpenedTicketVM>();
        List<ClosedTicketVM> closedTickets = new List<ClosedTicketVM>();
        public IActionResult OpenedTicket()
        {
            return View();
        }
        
        public IActionResult ClosedTicket()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InProgressTicket()
        {
            return View();
        }
        //public TicketController()
        //{
        //    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        //}

        [HttpGet]
        public async Task<List<OpenedTicketVM>> GetOpenedTicket()
        {
            tickets = new List<OpenedTicketVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44397/api/Tickets/GetOpenTickets"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tickets = JsonConvert.DeserializeObject<List<OpenedTicketVM>>(apiResponse);
                }
            }
            return tickets;
        }
        
        [HttpGet]
        public async Task<List<ClosedTicketVM>> GetClosedTicket()
        {
            closedTickets = new List<ClosedTicketVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44397/api/Tickets/GetResponsedTickets"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    closedTickets = JsonConvert.DeserializeObject<List<ClosedTicketVM>>(apiResponse);
                }
            }
            return closedTickets;
        }
    }
}

