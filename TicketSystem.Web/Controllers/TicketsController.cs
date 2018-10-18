using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business;
using TicketSystem.Entities;
using TicketSystem.Web.Models;

namespace TicketSystem.Web.Controllers
{
    [Route("api/[Controller]")]
    public class TicketsController : Controller
    {
        private readonly TicketService _ticketService;
        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            return Ok(_ticketService.GetAllTickets());
        }

        [HttpGet("{id}")]
        public IActionResult GetTicketById(int id)
        {
            return Ok(_ticketService.GetTicketById(id));
        }

        [HttpPost("close")]
        public IActionResult CloseTicket([FromBody]Ticket ticket)
        {
            _ticketService.CloseTicket(ticket, DateTimeOffset.Now);
            return Ok();
        }
    }
}
